namespace Map
{
    public class PolylineVisualHost : VisualHost<Polyline>,IHostType
    {
        public PolylineVisualHost()
        {

        }

        public VisualHostType GetVisualHostType()
        {
            return VisualHostType.POLYLINE;
        }
    }
}
