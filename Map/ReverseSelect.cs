using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Map
{
    public class ReverseSelect : MapTools
    {
        static public readonly ReverseSelect Instance = new ReverseSelect();
        static public List<DrawingVisual> SelectedItems = new List<DrawingVisual>();
        static public VisualHostType TargetType = VisualHostType.DEFAULT;

        ReverseSelect()
        {
            this.Cursor = new System.Windows.Input.Cursor(System.IO.Path.Combine(
                System.Environment.CurrentDirectory, "Cursors/drawgraphicline.cur"));
            this.m_CommandType = CommandType.ReverseSelect;
            this.DragShape = DragType.SoildRect;
        }

        public override void MouseLeftButtonUp()
        {
            SelectedItems.Clear();
            Rectangle rect = new Rectangle(Brushes.White, new Pen(Brushes.Yellow, 0.0), DragLine.m_DragSolidRect.Rect);
            switch (TargetType)
            {
                case VisualHostType.DEFAULT:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        IHitTest hitTest = item as IHitTest;
                        HitTest(hitTest, rect.Geometry);
                    }
                    break;

                case VisualHostType.POINT:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is PointVisualHost)
                        {
                            IHitTest hitTestPoint = item as IHitTest;
                            HitTest(hitTestPoint, rect.Geometry);
                        }
                    }
                    break;

                case VisualHostType.LINE:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is LineVisualHost)
                        {
                            IHitTest hitTestLine = item as IHitTest;
                            HitTest(hitTestLine, rect.Geometry);
                        }
                    }
                    break;

                case VisualHostType.POLYLINE:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is PolylineVisualHost)
                        {
                            IHitTest hitTestPolyline = item as IHitTest;
                            HitTest(hitTestPolyline, rect.Geometry);
                        }
                    }
                    break;

                case VisualHostType.POLYGON:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is Polygon)
                        {
                            IHitTest hitTestPolygon = item as IHitTest;
                            HitTest(hitTestPolygon, rect.Geometry);
                        }
                    }
                    break;
                case VisualHostType.TEXT:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is TextVisualHost)
                        {
                            IHitTest hitTestText = item as IHitTest;
                            HitTest(hitTestText, rect.Geometry);
                        }
                    }
                    break;
                case VisualHostType.IMAGE:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is ImageVisualHost)
                        {
                            IHitTest hitTestImage = item as IHitTest;
                            HitTest(hitTestImage, rect.Geometry);
                        }
                    }
                    break;
                case VisualHostType.VIDEO:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is VideoVisualHost)
                        {
                            IHitTest hitTestVideo = item as IHitTest;
                            HitTest(hitTestVideo, rect.Geometry);
                        }
                    }
                    break;
            }
            MessageBox.Show(SelectedItems.Count.ToString());
        }

        private void HitTest(IHitTest hitTest, Geometry geometry)
        {
            hitTest.HitTests_Reverse(geometry);
            if (hitTest.SelectedItems.Count != 0)
            {
                SelectedItems.AddRange(hitTest.SelectedItems);
            }
        }
    }
}
