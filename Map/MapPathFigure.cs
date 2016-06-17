using System.Windows.Media;

namespace Map
{
    public class MapPathFigure
    {
        private PathFigure pPathFigure;
        private PathSegmentCollection pPathSegmentCollection;
        public MapPathFigure(System.Windows.Point p)
        {
            pPathFigure = new PathFigure();
            pPathFigure.IsClosed = false;
            pPathFigure.StartPoint = p;
            pPathFigure.IsFilled = false;
            pPathSegmentCollection = pPathFigure.Segments;
        }

        public PathFigure PathFigure
        {
            get
            {
                return pPathFigure;
            }
        }
        public PathSegmentCollection Segments
        {
            get
            {
                return pPathSegmentCollection;
            }
        }
        public void Add(PathSegment pPathSegment)
        {
            pPathSegmentCollection.Add(pPathSegment);
        }
    }
}
