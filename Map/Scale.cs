using System;
using System.Windows.Input;

namespace Map
{
    public class Scale : MapTools
    {
        double MouseDown_Scalar;
        static public readonly Scale Instance = new Scale();
        Scale()
        {
            //this.Cursor = new Cursor("Scale.cur");
            this.Cursor = Cursors.SizeNS;
            this.m_CommandType = CommandType.Scale;
        }

        public override void MouseLeftButtonDown()
        {
            MouseDown_Scalar = Map.Scalar;
        }

        public override void MouseMove()
        {
            double dy = CurrentMouseScreenPosition.Y - MouseDownScreenPosition.Y;
            if (dy == 0) return;
            double scalar = Math.Abs(dy) / 40.0 + 1;//移动40像素放大或缩小一倍
            if (dy < 0)
            {
                //上移动，放大
                Map.SetScalar(MouseDown_Scalar * scalar);
            }
            else
            {
                //下移，缩小
                Map.SetScalar(MouseDown_Scalar / scalar);
            }
        }


    }
}
