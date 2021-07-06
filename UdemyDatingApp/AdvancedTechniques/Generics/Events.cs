using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.Generics
{
    public class VideoEventArgs : EventArgs
    {
        public Photo photo { get; set; }
    }
    public class Events
    {
        //public delegate void VideoEncoderEventHandler(object source, EventArgs args);

        public event EventHandler<VideoEventArgs> VideoEncoder;

        public void MainFunctionality(Photo photo)
        {
            Console.WriteLine("Encoding Video");
            Thread.Sleep(3000);

            OnVideoEncoder(photo);
        }

        protected virtual void OnVideoEncoder(Photo photo)
        {
            if (VideoEncoder != null)
                VideoEncoder(this, new VideoEventArgs {photo = photo });
                
        }
    }
}
