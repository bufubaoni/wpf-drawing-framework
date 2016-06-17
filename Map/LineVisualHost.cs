namespace Map
{
    public class LineVisualHost : VisualHost<Line>,IHostType
    {
        public LineVisualHost()
        {
        }


        public VisualHostType GetVisualHostType()
        {
            return VisualHostType.LINE;
        }
    }
}
