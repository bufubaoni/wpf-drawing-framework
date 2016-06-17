using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Map
{
    public class Pick : MapTools
    {
        static public readonly Pick Instance = new Pick();
        static public List<DrawingVisual> SelectedItems = new List<DrawingVisual>();
        static public VisualHostType TargetType = VisualHostType.DEFAULT;
        Pick()
        {
            this.Cursor = Cursors.Hand;
            this.m_CommandType = CommandType.Pick;
        }

        public override void MouseLeftButtonUp()
        {
            SelectedItems.Clear();
            switch (TargetType)
            {
                case VisualHostType.DEFAULT:
                    IHitTest hitTest = MapTools.Canvas.Children[MapTools.Canvas.Children.Count - 1] as IHitTest;
                    HitTest(hitTest, MapTools.MouseUpMapPosition);
                    break;

                case VisualHostType.POINT:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is PointVisualHost)
                        {
                            IHitTest hitTestPoint = item as IHitTest;
                            HitTest(hitTestPoint, MapTools.MouseUpMapPosition);
                        }
                    }
                    break;

                case VisualHostType.LINE:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is LineVisualHost)
                        {
                            IHitTest hitTestLine = item as IHitTest;
                            HitTest(hitTestLine, MapTools.MouseUpMapPosition);
                        }
                    }
                    break;

                case VisualHostType.POLYLINE:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is PolylineVisualHost)
                        {
                            IHitTest hitTestPolyline = item as IHitTest;
                            HitTest(hitTestPolyline, MapTools.MouseUpMapPosition);
                        }
                    }
                    break;

                case VisualHostType.POLYGON:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is PolygonVisualHost)
                        {
                            IHitTest hitTestPolygon = item as IHitTest;
                            HitTest(hitTestPolygon, MapTools.MouseUpMapPosition);
                        }
                    }
                    break;

                case VisualHostType.TEXT:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is TextVisualHost)
                        {
                            IHitTest hitTestText = item as IHitTest;
                            HitTest(hitTestText, MapTools.MouseUpMapPosition);
                        }
                    }
                    break;

                case VisualHostType.IMAGE:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is ImageVisualHost)
                        {
                            IHitTest hitTestImage = item as IHitTest;
                            HitTest(hitTestImage, MapTools.MouseUpMapPosition);
                        }
                    }
                    break;

                case VisualHostType.VIDEO:
                    foreach (var item in MapTools.Canvas.Children)
                    {
                        if (item is VideoVisualHost)
                        {
                            IHitTest hitTestVideo = item as IHitTest;
                            HitTest(hitTestVideo, MapTools.MouseUpMapPosition);
                        }
                    }
                    break;
            }
            MessageBox.Show(SelectedItems.Count.ToString());
        }

        private void HitTest(IHitTest hitTest, System.Windows.Point point)
        {
            hitTest.HitTest(point);
            if (hitTest.SelectedItem != null)
            {
                SelectedItems.Add(hitTest.SelectedItem);
            }
        }
    }
}
