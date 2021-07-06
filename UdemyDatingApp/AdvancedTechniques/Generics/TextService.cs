using System;
using System.Threading;

namespace UdemyDatingApp.Generics
{
    public class TextService
    {
        public void OnVideoEncoder(object source, VideoEventArgs e)
        {
            Console.WriteLine("Simulate Sending Text..."+ e.photo.Id);
            Thread.Sleep(3000);
        }
    }
}
