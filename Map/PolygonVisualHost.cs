
namespace Map
{
    public class PolygonVisualHost : VisualHost<Polygon>,IHostType
    {
        public PolygonVisualHost()
        { 
        }
        public VisualHostType GetVisualHostType()
        {
            return VisualHostType.POLYGON;
        }
    }
}
