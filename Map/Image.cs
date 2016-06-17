using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Map
{
    public class Image : DrawingVisual, INotifyPropertyChanged
    {
        public Image(string filename, System.Windows.Point p)
        {
            Uri pUri = new Uri(filename, UriKind.RelativeOrAbsolute);
            BitmapImage pBitmapImage = new BitmapImage(pUri);
            Rect pRect = new Rect();
            pRect.X = p.X;
            pRect.Y = p.Y;
            pRect.Width = pBitmapImage.PixelWidth;
            pRect.Height = pBitmapImage.PixelHeight;
            DrawingContext drawingContext = RenderOpen();

            drawingContext.DrawImage(pBitmapImage, pRect);
            drawingContext.Close();
            this.Transform = new ScaleTransform(1.0, -1.0, 0, p.Y + pBitmapImage.PixelHeight / 2.0);

        }
        public BitmapImage ImageSource
        {
            get
            {
                ImageDrawing pImageDrawing = (ImageDrawing)this.Drawing.Children[0];
                return (BitmapImage)(pImageDrawing.ImageSource);
            }
            set
            {
                ImageDrawing pImageDrawing = (ImageDrawing)this.Drawing.Children[0];
                pImageDrawing.ImageSource = value;
            }
        }
        public Rect Rect
        {
            get
            {
                ImageDrawing pImageDrawing = (ImageDrawing)this.Drawing.Children[0];
                return pImageDrawing.Rect;
            }
            set
            {
                ImageDrawing pImageDrawing = (ImageDrawing)this.Drawing.Children[0];
                pImageDrawing.Rect = value;
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
