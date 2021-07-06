using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.HTTPClient
{
    public static class HTTPClientPost
    {
        
        public static async Task<string> TestPost() 
        {
            var Person = new Person { Name="John",Occupation="Μηχανικός" };
            var json = JsonConvert.SerializeObject(Person);
            var data = new StringContent(json,Encoding.UTF8,"application/json");
            var client = new HttpClient();
            var url = "https://httpbin.org/post";
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json;charset=UTF-8");
            //client.DefaultRequestHeaders.AcceptEncoding.Add(new MediaTypeWithQualityHeaderValue("application/json;charset=UTF-8"));
                 
            var request =await client.PostAsync(url, data);

            var result =  request.Content.ReadAsStringAsync().Result;
            Console.WriteLine(request);
            return result;
            
        }
    }
}
