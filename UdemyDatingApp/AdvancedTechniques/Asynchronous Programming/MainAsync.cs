using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UdemyDatingApp.AdvancedTechniques.Asynchronous_Programming
{
    public class MainAsync
    {
        public async void MainFunctionality()
        {
            DownloadHtml(@"https://docs.microsoft.com/el-gr/", new WebClient());
            DownloadHtmlAsync(@"https://docs.microsoft.com/el-gr/", new WebClient());
            
            var contentHtml = GetHtml(@"https://docs.microsoft.com/el-gr/", new WebClient());
            Console.WriteLine(contentHtml);

            var contentHtmlAsync = GetHtmlAsync(@"https://docs.microsoft.com/el-gr/", new WebClient());
            //var contentFinal = Task.Run(async()=>await contentHtmlAsync);
            var contentFinal = await contentHtmlAsync;
            Console.WriteLine(contentFinal);
        }
        public void DownloadHtml(string url ,WebClient client)
        {
            
            var content = client.DownloadString(url);
            using (StreamWriter writer = new StreamWriter(@"C:\Users\apeppas\OneDrive - Deloitte (O365D)\Desktop\Write.txt"))
            {
                writer.WriteLine();
            }
        }
        public async Task DownloadHtmlAsync(string url, WebClient client)
        {
            
            
            var content = await client.DownloadStringTaskAsync(url);//(new Uri(url));
            using (StreamWriter writer = new StreamWriter(@"C:\Users\apeppas\OneDrive - Deloitte (O365D)\Desktop\WriteAsync.txt"))
            {
                await writer.WriteLineAsync();
            }
        }
        public string GetHtml (string url, WebClient client)
        {
            return client.DownloadString(url);
        }
        public async Task<string> GetHtmlAsync (string url, WebClient client)
        {
            return await client.DownloadStringTaskAsync(url);
        }
    }
}
