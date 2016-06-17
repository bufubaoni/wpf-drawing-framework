using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Map
{
    public class VisualHost<T> : FrameworkElement, IHitTest where T : DrawingVisual
    {
        // Create a collection of child visual objects.

        protected VisualCollection _children;
        public VisualHost()
        {
            _children = new VisualCollection(this);
            SelectedItems = new List<DrawingVisual>();
        }

        public List<DrawingVisual> SelectedItems
        {
            get;
            private set;
        }

        public DrawingVisual SelectedItem
        {
            get;
            private set;
        }

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get
            {
                return _children.Count;
            }
        }
        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _children[index];
        }

        public void Add(T child)
        {
            _children.Add(child);
        }

        public T this[int index]
        {
            get { return (T)GetVisualChild(index); }
        }

        public int Count
        {
            get
            {
                return _children.Count;
            }
        }

        public void Clear()
        {
            _children.Clear();
        }

        DrawingVisual IHitTest.HitTest(System.Windows.Point pt)
        {
            SelectedItem = null;
            HitTestResult result = VisualTreeHelper.HitTest(this, pt);
            DrawingVisual visual = null;
            if (result != null)
            {
                visual = result.VisualHit as DrawingVisual;
                SelectedItem = visual;
            }
            return visual;
        }

        List<DrawingVisual> IHitTest.HitTests(Geometry region)
        {
            SelectedItems.Clear();
            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback((result) =>
            {
                GeometryHitTestResult geometryResult = result as GeometryHitTestResult;
                DrawingVisual visual = result.VisualHit as DrawingVisual;
                if (visual != null && geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)
                {
                    SelectedItems.Add(visual);
                }
                return HitTestResultBehavior.Continue;
            });
            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return SelectedItems;
        }

        List<DrawingVisual> IHitTest.HitTests_Reverse(Geometry region)
        {
            SelectedItems.Clear();
            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback((result) =>
            {
                GeometryHitTestResult geometryResult = result as GeometryHitTestResult;
                DrawingVisual visual = result.VisualHit as DrawingVisual;
                if (visual != null 
                    && (geometryResult.IntersectionDetail == IntersectionDetail.Intersects 
                    || geometryResult.IntersectionDetail == IntersectionDetail.FullyInside))
                {
                    SelectedItems.Add(visual);
                }
                return HitTestResultBehavior.Continue;
            });
            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return SelectedItems;
        }


        
    }
}
