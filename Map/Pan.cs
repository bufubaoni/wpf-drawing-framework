using System.Windows.Input;
namespace Map
{
    public class Pan : MapTools
    {
        System.Windows.Point MouseDownScreenCenter;
        static public readonly Pan Instance = new Pan();
        Pan()
        {
            this.Cursor = new Cursor(System.IO.Path.Combine(
                System.Environment.CurrentDirectory, "Cursors/hand.cur"));
            this.m_CommandType = CommandType.Pan;
        }

        public override void MouseLeftButtonDown()
        {
            MouseDownScreenCenter.X = Map.m_Center_E;
            MouseDownScreenCenter.Y = Map.m_Center_N;
        }
       
        public override void MouseMove()
        {
            double dx = MouseDownMapPosition.X - CurrentMouseMapPosition.X;
            double dy = MouseDownMapPosition.Y - CurrentMouseMapPosition.Y;
            Map.Center(MouseDownScreenCenter.X + dx, MouseDownScreenCenter.Y + dy);
        }

    }
}
