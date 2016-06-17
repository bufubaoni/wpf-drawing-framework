using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Media;

namespace Map
{
    //点
    public class Point : DrawingVisual, INotifyPropertyChanged
    {
        private EllipseGeometry pGeometry;
        public Point(Brush pBrush, Pen pPen, System.Windows.Point pCenter, double pRadius)
        {
            pGeometry = new EllipseGeometry(pCenter, pRadius, pRadius);
            DrawingContext drawingContext = RenderOpen();
            drawingContext.DrawGeometry(pBrush, pPen, pGeometry);
            drawingContext.Close();
        }

        public Brush Brush
        {
            get
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                return pGeometryDrawing.Brush;
            }
            set
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                pGeometryDrawing.Brush = value;
            }
        }

        public Pen Pen
        {
            get
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                return pGeometryDrawing.Pen;
            }
            set
            {
                GeometryDrawing pGeometryDrawing = (GeometryDrawing)this.Drawing.Children[0];
                pGeometryDrawing.Pen = value;
            }
        }

        public System.Windows.Point Center
        {
            get
            {
                return pGeometry.Center;
            }
            set
            {
                pGeometry.Center = value;
            }
        }

        public double Radius
        {
            get
            {
                return pGeometry.RadiusX;
            }
            set
            {
                pGeometry.RadiusX = value;
                pGeometry.RadiusY = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //Useage:  OnPropertyChanged(GetPropertyName(() => this.Brush));
        public void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            MemberExpression expression = propertyExpression.Body as MemberExpression;
            return expression.Member.Name;
        }

    }
}
