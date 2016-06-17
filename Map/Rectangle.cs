using System.Windows;
using System.Windows.Media;

namespace Map
{
    public class Rectangle : DrawingVisual
    {
        private PathGeometry pGeometry;
        PathFigure pPathFigure;
        public Rectangle(Brush pBrush, Pen pPen, Rect pRect)
        {
            pPathFigure = new PathFigure();
            pPathFigure.IsClosed = true;
            if (pBrush != null)
            {
                pPathFigure.IsFilled = true;
            }
            else
            {
                pPathFigure.IsFilled = false;
            }
            pPathFigure.StartPoint = pRect.Location;
            pPathFigure.Segments.Add(new LineSegment(pRect.TopRight, true));
            pPathFigure.Segments.Add(new LineSegment(pRect.BottomRight, true));
            pPathFigure.Segments.Add(new LineSegment(pRect.BottomLeft, true));
            pGeometry = new PathGeometry();
            pGeometry.Figures.Add(pPathFigure);
            DrawingContext drawingContext = RenderOpen();
            drawingContext.DrawGeometry(pBrush, pPen, pGeometry);
            drawingContext.Close();

        }
        public Brush Brush
        {
            get
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                return pGeometryDrawing.Brush;
            }
            set
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                pGeometryDrawing.Brush = value;
            }
        }
        public Pen Pen
        {
            get
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                return pGeometryDrawing.Pen;
            }
            set
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                pGeometryDrawing.Pen = value;
            }
        }

        public Rect Rect
        {
            get
            {
                System.Windows.Point pStartPoint = pPathFigure.StartPoint;
                LineSegment pLineSegment = (LineSegment)pPathFigure.Segments[1];
                return new Rect(pStartPoint, pLineSegment.Point);
            }
            set
            {
                pPathFigure.StartPoint = value.Location;
                ((LineSegment)pPathFigure.Segments[0]).Point = value.TopRight;
                ((LineSegment)pPathFigure.Segments[1]).Point = value.BottomRight;
                ((LineSegment)pPathFigure.Segments[2]).Point = value.BottomLeft;
            }
        }

        public Geometry Geometry
        {
            get { return pGeometry; }
        }
    }
}
