
namespace Map
{
    public class PointVisualHost : VisualHost<Point>,IHostType
    {
        public PointVisualHost()
        {

        }
        public VisualHostType GetVisualHostType()
        {
            return VisualHostType.POINT;
        }
    }
}
