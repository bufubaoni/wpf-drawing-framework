
namespace Map
{
    public class MapRingFigure : MapPathFigure
    {
        public MapRingFigure(System.Windows.Point p)
            : base(p)
        {
            this.PathFigure.IsClosed = true;
            this.PathFigure.IsFilled = true;
        }
    }
}
