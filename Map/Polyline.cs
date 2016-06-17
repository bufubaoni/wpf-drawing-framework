using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Media;

namespace Map
{
    public class Polyline : DrawingVisual, INotifyPropertyChanged
    {
        private PathGeometry pGeometry;
        private PathFigureCollection pPathFigureCollection;
        public Polyline(Brush pBrush, Pen pPen)
        {
            pGeometry = new PathGeometry();
            pPathFigureCollection = new PathFigureCollection();
            DrawingContext drawingContex = RenderOpen();
            drawingContex.DrawGeometry(pBrush, pPen, pGeometry);
            drawingContex.Close();
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
        public void AddPath(MapPathFigure pPathFigure)
        {
            pPathFigureCollection.Add(pPathFigure.PathFigure);
        }
        public PathGeometry PathGeometry
        {
            get
            {
                return pGeometry;
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
