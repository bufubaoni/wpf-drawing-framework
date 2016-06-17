using System;
using System.Windows.Input;

namespace Map
{
    public class WindowMax : MapTools
    {
        static public readonly WindowMax Instance = new WindowMax();
        WindowMax()
        {
            this.Cursor = Cursors.Cross;
            this.m_CommandType = CommandType.WindowMax;
            this.DragShape = DragType.HollowRect;
        }

        public override void MouseLeftButtonUp()
        {
            double para = 0.0;
            if (Math.Abs(MapTools.MouseUpScreenPosition.X - MapTools.MouseDownScreenPosition.X) < 100.0
                && Math.Abs(MapTools.MouseUpScreenPosition.Y - MapTools.MouseDownScreenPosition.Y) < 100.0)
            {
                para = 3.0;
            }
            else
            {
                para = Map.m_MainCanvas_Half_Width * 2.0 / Math.Abs(MapTools.MouseUpScreenPosition.X - MapTools.MouseDownScreenPosition.X);
                double deltaH = Map.m_MainCanvas_Half_Height * 2.0 / Math.Abs(MapTools.MouseUpScreenPosition.Y - MapTools.MouseDownScreenPosition.Y);
                if (deltaH > para) para = deltaH;
                if (para > 3.0) para = 3.0;
            }
            para *= Map.Scalar;
            Map.SetScalar(para);
            //计算中点
            Map.Center((MapTools.MouseDownMapPosition.X + MapTools.MouseUpMapPosition.X) * 0.5,
                (MapTools.MouseDownMapPosition.Y + MapTools.MouseUpMapPosition.Y) * 0.5);

        }



    }
}
