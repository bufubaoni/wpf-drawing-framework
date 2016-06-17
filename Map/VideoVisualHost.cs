
namespace Map
{
    public class VideoVisualHost : VisualHost<Video>,IHostType
    {
        bool isPlay;
        public VideoVisualHost()
        {
            isPlay = false;
            this.MouseRightButtonUp += VideoVisualHost_MouseRightButtonUp;
        }

        void VideoVisualHost_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Video pVideo = this[i];
                if (isPlay)
                {
                    pVideo.Player.Pause();
                }
                else
                {
                    pVideo.Player.Play();
                }
            }
            isPlay = !isPlay;
        }

        public VisualHostType GetVisualHostType()
        {
            return VisualHostType.VIDEO;
        }
    }
}
