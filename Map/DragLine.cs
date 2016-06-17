using System.Windows;
using System.Windows.Media;
namespace Map
{
    public enum DragType { None, Polyline, HollowRect, SoildRect }
    public class DragLine
    {
        static public DragLine CurrentDrag = new DragLine();

        static public VisualHost<DrawingVisual> m_ListDragline = new VisualHost<DrawingVisual>();
        static public Line m_DragPolyline;
        static public Rectangle m_DragSolidRect;
        static public Rectangle m_DragHollowRect;

        static System.Windows.Point pStartPoint;
        static System.Windows.Point pEndPoint;
        static System.Windows.Point pZeroPoint;

        bool hasEndPoint;
        bool hasStartPoint;

        DragLine()
        {
            pStartPoint = new System.Windows.Point();
            pEndPoint = new System.Windows.Point();
            pZeroPoint = new System.Windows.Point();
            hasEndPoint = false;
            hasStartPoint = false;

        }

        static DragLine()
        {

        }

        public System.Windows.Point DragLineStartPoint
        {
            get
            {
                return pStartPoint;
            }
        }

        public System.Windows.Point DragLineEndPoint
        {
            get
            {
                return pEndPoint;
            }
        }

        public void End()
        {
            hasStartPoint = false;
        }

        public void Purse(MainCanvas mainCanvas)
        {
            m_ListDragline.Clear();
            mainCanvas.Children.Remove(m_ListDragline);
            if (m_ListDragline != null && m_ListDragline.Count != 0)
            {
                hasStartPoint = false;
                m_DragPolyline.StartPoint = pZeroPoint;
                m_DragPolyline.EndPoint = pZeroPoint;
                m_DragSolidRect.Rect = new Rect(pZeroPoint, pZeroPoint);
                m_DragHollowRect.Rect = new Rect(pZeroPoint, pZeroPoint);
            }
        }

        public void SetStartPoint(System.Windows.Point pt)
        {
            pStartPoint = pt;
            hasStartPoint = true;
            hasEndPoint = false;
        }

        public void SetEndPoint(System.Windows.Point pt)
        {
            pEndPoint = pt;
            hasEndPoint = true;
        }

        public bool HasStartPoint
        {
            get { return hasStartPoint; }
        }

        public bool HasEndPoint
        {
            get { return hasEndPoint; }
        }

        public void Draw()
        {
            if (!hasStartPoint || !hasEndPoint) return;
            double thickness = 0.1 * Map.m_ScalarBar / Map.Scalar;
            if (thickness < 0.1 * Map.m_ScalarBar) thickness = 0.1 * Map.m_ScalarBar;
            if (MapTools.CurrentCommand != null)
            {
                switch (MapTools.CurrentCommand.DragShape)
                {
                    case DragType.None:
                        m_DragPolyline.Pen.DashStyle = DashStyles.Dot;
                        m_DragPolyline.Pen.Thickness = thickness;
                        m_DragPolyline.StartPoint = pStartPoint;
                        m_DragPolyline.EndPoint = pStartPoint;
                        break;
                    case DragType.Polyline:
                        m_DragPolyline.Pen.DashStyle = DashStyles.Dot;
                        m_DragPolyline.Pen.Thickness = thickness;
                        m_DragPolyline.StartPoint = pStartPoint;
                        m_DragPolyline.EndPoint = pEndPoint;
                        break;
                    case DragType.HollowRect:
                        m_DragHollowRect.Pen.DashStyle = DashStyles.Solid;
                        m_DragHollowRect.Pen.Thickness = thickness;
                        m_DragHollowRect.Rect = new Rect(pStartPoint, pEndPoint);
                        break;
                    case DragType.SoildRect:
                        m_DragSolidRect.Pen.DashStyle = DashStyles.DashDot;
                        m_DragSolidRect.Pen.Thickness = thickness;
                        m_DragSolidRect.Rect = new Rect(pStartPoint, pEndPoint);
                        break;
                }
            }
            else
            {
                m_DragPolyline.Pen.DashStyle = DashStyles.Dot;
                m_DragPolyline.Pen.Thickness = thickness;
                m_DragPolyline.StartPoint = pStartPoint;
                m_DragPolyline.EndPoint = pEndPoint;
            }
        }

        static public void OnMouseMove()
        {
            if (CurrentDrag.HasStartPoint)
            {
                if (MapTools.CurrentCommand == null || (MapTools.CurrentCommand != null && MapTools.CurrentCommand.DragShape != DragType.None))
                {
                    CurrentDrag.SetEndPoint(MapTools.CurrentMouseMapPosition);
                    CurrentDrag.Draw();
                }
            }
        }

        static public void OnMouseLeftButton(MainCanvas mainCanvas, System.Windows.Point pt)
        {
            Pen dragPen = new Pen(Brushes.White, 0.001 * Map.m_ScalarBar);
            dragPen.DashStyle = DashStyles.Dot;
            m_DragPolyline = new Line(null, dragPen, pt, pt);

            Brush solidBrush = new SolidColorBrush(Colors.Red);
            solidBrush.Opacity = 0.2;
            dragPen.DashStyle = DashStyles.DashDot; 
            m_DragSolidRect = new Rectangle(solidBrush, dragPen, new Rect(pt, pt));

            Brush hollowBrush = new SolidColorBrush(Colors.Green);
            hollowBrush.Opacity = 0.2;
            dragPen.DashStyle = DashStyles.Solid;
            m_DragHollowRect = new Rectangle(hollowBrush, dragPen, new Rect(pt, pt));

            m_ListDragline.RenderTransform = Map.m_TransformGroup;
            m_ListDragline.Add(m_DragPolyline);
            m_ListDragline.Add(m_DragHollowRect);
            m_ListDragline.Add(m_DragSolidRect);

            if (!mainCanvas.Children.Contains(m_ListDragline))
            {
                mainCanvas.Children.Add(m_ListDragline);
            }

            if (MapTools.CurrentCommand == null || (MapTools.CurrentCommand != null && MapTools.CurrentCommand.DragShape != DragType.None))
            {
                CurrentDrag.SetStartPoint(MapTools.MouseDownMapPosition);
            }
        }

        static public void PurseDraw(MainCanvas mainCanvas)
        {
            CurrentDrag.Purse(mainCanvas);
        }
    }
}
