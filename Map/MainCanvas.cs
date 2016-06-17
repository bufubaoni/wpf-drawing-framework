using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Map
{
    public class MainCanvas : Canvas
    {
        public StringBuilder m_Coordinate;
        public MainCanvas()
        {
            m_Coordinate = new StringBuilder();
            this.MouseMove += MainCanvas_MouseMove;
            this.SizeChanged += MainCanvas_SizeChanged;
            this.MouseWheel += MainCanvas_MouseWheel;
            this.MouseLeftButtonDown += MainCanvas_MouseLeftButtonDown;
            this.MouseLeftButtonUp += MainCanvas_MouseLeftButtonUp;
            this.MouseRightButtonDown += MainCanvas_MouseRightButtonDown;
        }

        void MainCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                if (MapTools.CurrentCommand != null)
                {
                    MapTools.EndCommand();
                    MapTools.CurrentCommand = null;
                }
            }
            if (e.ClickCount == 2)
            {
                Map.FullExtent();
            }
        }

        void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MapTools.MouseUpScreenPosition = e.GetPosition((UIElement)sender);
            double x;
            double y;
            FromScreenToMapCoordinate(MapTools.MouseUpScreenPosition.X, MapTools.MouseUpScreenPosition.Y, out x, out y);
            MapTools.MouseUpMapPosition.X = x;
            MapTools.MouseUpMapPosition.Y = y;
            DragLine.PurseDraw(this);//先调用
            if (MapTools.CurrentCommand != null)
            {
                MapTools.OnMouseLeftButtonUp();
            }
            else
            {
                //如果从按下到释放有较大的鼠标移动，就平移地图
                double dx = MapTools.MouseUpScreenPosition.X - MapTools.MouseDownScreenPosition.X;
                double dy = MapTools.MouseUpScreenPosition.Y - MapTools.MouseDownScreenPosition.Y;
                if (Math.Abs(dx) > 50.0 || Math.Abs(dy) > 50.0)
                {
                    Map.SetTranslateDelta(-(MapTools.MouseUpMapPosition.X - MapTools.MouseDownMapPosition.X), -(MapTools.MouseUpMapPosition.Y - MapTools.MouseDownMapPosition.Y));
                }
            }

        }

        void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            MapTools.MouseDownScreenPosition = e.GetPosition((UIElement)sender);
            double x;
            double y;
            FromScreenToMapCoordinate(MapTools.MouseDownScreenPosition.X, MapTools.MouseDownScreenPosition.Y,
                out x, out y);
            MapTools.MouseDownMapPosition.X = x;
            MapTools.MouseDownMapPosition.Y = y;
            DragLine.OnMouseLeftButton(this, new System.Windows.Point(x, y));//先调用
            if (MapTools.CurrentCommand != null) MapTools.OnMouseLeftButtonDown();
        }

        //实时缩放
        void MainCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            MapTools.CurrentMouseScreenPosition = e.GetPosition((UIElement)sender);
            double scalar = 1.05;
            if (e.Delta < 0) scalar *= 0.90;
            Map.SetScalarDelta(scalar);
        }

        void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Map.SetCanvasSize(e.NewSize.Width, e.NewSize.Height);
        }

        void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            MapTools.CurrentMouseScreenPosition = e.GetPosition((UIElement)sender);
            FromScreenToMapCoordinate();
            m_Coordinate.Length = 0;
            double X = MapTools.CurrentMouseMapPosition.X;
            double Y = MapTools.CurrentMouseMapPosition.Y;
            m_Coordinate.AppendFormat("X={0:f3} Y={1:f3}", X, Y);
            DragLine.OnMouseMove();
            if (MapTools.CurrentCommand != null && e.LeftButton == MouseButtonState.Pressed)
            {
                MapTools.OnMouseMove();
            }

        }

        public void FromScreenToMapCoordinate()
        {
            MapTools.CurrentMouseMapPosition.X = (MapTools.CurrentMouseScreenPosition.X - Map.TranslateX) / Map.Scalar;
            MapTools.CurrentMouseMapPosition.Y = -(MapTools.CurrentMouseScreenPosition.Y - Map.TranslateY) / Map.Scalar;
        }

        public void FromScreenToMapCoordinate(double screenX, double screenY, out double mapX, out double mapY)
        {
            mapX = (screenX - Map.TranslateX) / Map.Scalar;
            mapY = -(screenY - Map.TranslateY) / Map.Scalar;
        }
    }

}
