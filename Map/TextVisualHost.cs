
namespace Map
{
    public class TextVisualHost : VisualHost<Text>,IHostType
    {
        public TextVisualHost()
        {

        }

        public VisualHostType GetVisualHostType()
        {
            return VisualHostType.TEXT;
        }
    }
}
