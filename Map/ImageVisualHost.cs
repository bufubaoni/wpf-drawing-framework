namespace Map
{
    public class ImageVisualHost : VisualHost<Image>, IHostType
    {
        public ImageVisualHost()
        {

        }



        public VisualHostType GetVisualHostType()
        {
            return VisualHostType.IMAGE;
        }
    }
}
