using System;
using System.Threading;

namespace UdemyDatingApp.Generics
{
    public class MailService
    {
        public void OnVideoEncoder(object source,VideoEventArgs e )
        {
            Console.WriteLine("Encoding Email " +e.photo.Id);
            Thread.Sleep(3000);
        }
    }
}
