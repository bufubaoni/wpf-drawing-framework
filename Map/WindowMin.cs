using System;
using System.Windows.Input;

namespace Map
{
    public class WindowMin : MapTools
    {
        static public readonly WindowMin Instance = new WindowMin();
        WindowMin()
        {
            this.Cursor = Cursors.Cross;
            this.m_CommandType = CommandType.WindowMin;
            this.DragShape = DragType.HollowRect;
        }

        public override void MouseLeftButtonUp()
        {
            double para = 0.0;
            if (Math.Abs(MapTools.MouseUpScreenPosition.X - MapTools.MouseDownScreenPosition.X) < 100.0
                && Math.Abs(MapTools.MouseUpScreenPosition.Y - MapTools.MouseDownScreenPosition.Y) < 100.0)
            {
                para = 0.3;
            }
            else
            {
                para = Math.Abs(MapTools.MouseUpScreenPosition.X - MapTools.MouseDownScreenPosition.X) / (Map.m_MainCanvas_Half_Width * 2.0);
                double deltaH = Math.Abs(MapTools.MouseUpScreenPosition.Y - MapTools.MouseDownScreenPosition.Y) / Map.m_MainCanvas_Half_Height * 2.0;
                if (deltaH < para) para = deltaH;
                if (para < 0.3) para = 0.3;
            }
            para *= Map.Scalar;
            Map.SetScalar(para);
            //计算中点
            Map.Center((MapTools.MouseDownMapPosition.X + MapTools.MouseUpMapPosition.X) * 0.5,
                (MapTools.MouseDownMapPosition.Y + MapTools.MouseUpMapPosition.Y) * 0.5);
        }
    }
}
