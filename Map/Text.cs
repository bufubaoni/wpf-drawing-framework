using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Media;
namespace Map
{
    public class Text : DrawingVisual, INotifyPropertyChanged
    {
        public Text(Brush pForeground, string textStr, string style, double size, System.Windows.Point p)
        {
            DrawingContext drawingContext = RenderOpen();
            drawingContext.DrawText(
                new FormattedText(textStr,
                    CultureInfo.GetCultureInfo("zh_Hans"),
                    FlowDirection.LeftToRight,
                    new Typeface(style),
                    size, pForeground), p);
            drawingContext.Close();
            this.Transform = new ScaleTransform(1.0, -1.0, 0, p.Y + size / 2.0);
        }

        public Brush ForegroundBrush
        {
            get
            {
                GlyphRunDrawing pGlyphRunDrawing = (GlyphRunDrawing)this.Drawing.Children[0];
                return pGlyphRunDrawing.ForegroundBrush;
            }
            set
            {
                GlyphRunDrawing pGlyphRunDrawing = (GlyphRunDrawing)this.Drawing.Children[0];
                pGlyphRunDrawing.ForegroundBrush = value;
            }
        }
        public System.Windows.Point BaselineOrigin
        {
            get
            {
                GlyphRunDrawing pGlyphRunDrawing = (GlyphRunDrawing)this.Drawing.Children[0];
                return pGlyphRunDrawing.GlyphRun.BaselineOrigin;
            }
            set
            {
                GlyphRunDrawing pGlyphRunDrawing = (GlyphRunDrawing)this.Drawing.Children[0];
                pGlyphRunDrawing.GlyphRun.BaselineOrigin = value;
            }
        }
        public GlyphRun GlyphRun
        {
            get
            {
                GlyphRunDrawing pGlyphRunDrawing = (GlyphRunDrawing)this.Drawing.Children[0];
                return pGlyphRunDrawing.GlyphRun;
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
