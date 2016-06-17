using System.Collections.Generic;
using System.Windows.Media;

namespace Map
{
    public interface IHitTest
    {
        DrawingVisual HitTest(System.Windows.Point pt);
        List<DrawingVisual> HitTests(Geometry region);
        List<DrawingVisual> HitTests_Reverse(Geometry region);
        List<DrawingVisual> SelectedItems
        {
            get;
        }
        DrawingVisual SelectedItem
        {
            get;
        }
    }

}
