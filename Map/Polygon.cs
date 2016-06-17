using System.Windows.Media;

namespace Map
{
    public class Polygon : Polyline
    {
        public Polygon(Brush pBrush, Pen pPen)
            : base(pBrush, pPen)
        {
            this.PathGeometry.FillRule = FillRule.EvenOdd;
        }
    }
}
