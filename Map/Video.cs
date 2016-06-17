using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Media;

namespace Map
{
    public class Video : DrawingVisual, INotifyPropertyChanged
    {
        private MediaPlayer pMediaPlayer;
        private Rect pRect;
        private double Scale;
        public Video(string filename, System.Windows.Point p, double scale)
        {
            Uri pUri = new Uri(filename, UriKind.RelativeOrAbsolute);
            pMediaPlayer = new MediaPlayer();
            pMediaPlayer.Open(pUri);
            //pMediaPlayer.Play();
            pRect = new Rect();
            pRect.X = p.X;
            pRect.Y = p.Y;
            Scale = scale;
            pMediaPlayer.MediaFailed += pMediaPlayer_MediaFailed;
            pMediaPlayer.MediaOpened += pMediaPlayer_MediaOpened;
        }

        void pMediaPlayer_MediaOpened(object sender, EventArgs e)
        {
            pRect.Width = pMediaPlayer.NaturalVideoWidth * Scale;
            pRect.Height = pMediaPlayer.NaturalVideoHeight * Scale;
            DrawingContext drawingContext = RenderOpen();
            drawingContext.DrawVideo(pMediaPlayer, pRect);

            drawingContext.Close();
            this.Transform = new ScaleTransform(1.0, -1.0, 0, pRect.Y + pRect.Height / 2.0);
        }


        void pMediaPlayer_MediaFailed(object sender, ExceptionEventArgs e)
        {
            System.Windows.MessageBox.Show("视频播放失败！");
        }
        public MediaPlayer Player
        {
            get
            {
                VideoDrawing pVideoDrawing = (VideoDrawing)this.Drawing.Children[0];
                return pVideoDrawing.Player;
            }
            set
            {
                VideoDrawing pVideoDrawing = (VideoDrawing)this.Drawing.Children[0];
                pVideoDrawing.Player = value;
            }
        }
        public Rect Rect
        {
            get
            {
                VideoDrawing pVideoDrawing = (VideoDrawing)this.Drawing.Children[0];
                return pVideoDrawing.Rect;
            }
            set
            {
                VideoDrawing pVideoDrawing = (VideoDrawing)this.Drawing.Children[0];
                pVideoDrawing.Rect = value;
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
