using System.Collections.Generic;
using System.Windows.Media;

namespace Map
{
    static public class Map
    {
        public static double m_MainCanvas_Half_Width;
        public static double m_ScalarBar = 10;
        public static double m_MainCanvas_Half_Height;
        public static double m_Min_E;
        public static double m_Min_N;
        public static double m_Max_E;
        public static double m_Max_N;

        public static double m_Center_N;
        public static double m_Center_E;

        public static double TranslateX;
        public static double TranslateY;

        public static double Scalar;
        static ScaleTransform m_ScaleTransform;
        static TranslateTransform m_TranslateTransform;
        public static TransformGroup m_TransformGroup;

        static public List<DrawingVisual> SelectedItems;

        static public void Center(double x, double y)
        {
            m_Center_E = x;
            m_Center_N = y;
            CalculateTranslateDelta();
        }

        static public void SetCanvasSize(double width, double height)
        {
            m_MainCanvas_Half_Width = width * 0.5;
            m_MainCanvas_Half_Height = height * 0.5;
            CalculateTranslateDelta();
        }

        static public void SetScalar(double scalar)
        {
            Scalar = scalar;
            CalculateTranslateDelta();
        }

        static public void SetScalarDelta(double scalar)
        {
            Scalar *= scalar;
            CalculateTranslateDelta();
        }

        static public void CalculateTranslateDelta()
        {
            TranslateX = m_MainCanvas_Half_Width - m_Center_E * Scalar;
            TranslateY = m_MainCanvas_Half_Height + m_Center_N * Scalar;
            //修改显示部件
            m_ScaleTransform.ScaleX = Scalar;
            m_ScaleTransform.ScaleY = -Scalar;
            m_TranslateTransform.X = TranslateX;
            m_TranslateTransform.Y = TranslateY;
        }

        //设置平移增量
        static public void SetTranslateDelta(double dx, double dy)
        {
            m_Center_E += dx;
            m_Center_N += dy;
            CalculateTranslateDelta();
        }

        static Map()
        {
            m_MainCanvas_Half_Width = 500;
            m_MainCanvas_Half_Height = 600;
            Scalar = 1;
            m_Min_E = 0;
            m_Min_N = 0;
            m_Max_E = 500;
            m_Max_N = 600;
            m_ScaleTransform = new ScaleTransform();
            m_TranslateTransform = new TranslateTransform();
            m_TransformGroup = new TransformGroup();
            m_TransformGroup.Children.Add(m_ScaleTransform);
            m_TransformGroup.Children.Add(m_TranslateTransform);
        }

        static public void SetMapEnvelope(double minX, double minY, double maxX, double maxY)
        {
            m_Min_E = minX;
            m_Min_N = minY;
            m_Max_E = maxX;
            m_Max_N = maxY;
            FullExtent();
        }

        static public void FullExtent()
        {
            double sx = m_MainCanvas_Half_Width / (m_Max_E - m_Min_E) * 2.0;
            double sy = m_MainCanvas_Half_Height / (m_Max_N - m_Min_N) * 2.0;
            if (sx < sy)
            {
                Scalar = sx;
            }
            else
            {
                Scalar = sy;
            }
            Scalar *= 0.96;
            m_Center_E = (m_Max_E + m_Min_E) / 2.0;
            m_Center_N = (m_Max_N + m_Min_N) / 2.0;
            CalculateTranslateDelta();
        }


    }
}
