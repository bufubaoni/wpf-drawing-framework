using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Media;

namespace Map
{
    public class Line : DrawingVisual, INotifyPropertyChanged
    {
        private LineGeometry pGeometry;
        public Line(Brush pBrush, Pen pPen, System.Windows.Point p1, System.Windows.Point p2)
        {
            pGeometry = new LineGeometry(p1, p2);
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

        public System.Windows.Point StartPoint
        {
            get
            {
                return pGeometry.StartPoint;
            }
            set
            {
                pGeometry.StartPoint = value;
            }
        }

        public System.Windows.Point EndPoint
        {
            get
            {
                return pGeometry.EndPoint;
            }
            set
            {
                pGeometry.EndPoint = value;
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
