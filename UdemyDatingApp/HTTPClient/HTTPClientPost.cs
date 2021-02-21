using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.HTTPClient
{
    public class HTTPClientPost
    {
        
        public async Task<string> TestPost() 
        {
            var Person = new Person { Name="John",Occupation="Engineer" };
            var json = JsonConvert.SerializeObject(Person);
            var data = new StringContent(json,Encoding.UTF8,"application/json");
            var client = new HttpClient();
            var url = "https://httpbin.org/post";
            var request =await client.PostAsync(url, data);

            var result =  request.Content.ReadAsStringAsync().Result;
            Console.WriteLine(request);
            return result;
            
        }
    }
}
