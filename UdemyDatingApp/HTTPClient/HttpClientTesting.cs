using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace UdemyDatingApp
{
    /* ------------------ <Response> ---------------- */
    [DataContract]
    public class RequestDataObjects
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
    [DataContract]
    public class ResponseItemsObject
    {
        [DataMember(Name = "rpaKey")]
        public string RpaKey { get; set; }

        [DataMember(Name = "itemNo")]
        public string ItemNo { get; set; }

        [DataMember(Name = "rpaProcessId")]
        public string RpaProcessId { get; set; }

        [DataMember(Name = "appExternalRef")]
        public string AppExternalRef { get; set; }

        [DataMember(Name = "queueRequestData")]
        public List<RequestDataObjects> QueueRequestData { get; set; }

        [DataMember(Name = "statusCode")]
        public string StatusCode { get; set; }

        [DataMember(Name = "rPAData")]
        public string RPAData { get; set; }
    }



    [DataContract]
    public class PayloadObject
    {
        [DataMember(Name = "queueResponseItemsList")]
        public List<ResponseItemsObject> QueueResponseItemsList { get; set; }
    }



    [DataContract]
    public class ExcepObj
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "desc")]
        public string Desc { get; set; }

        [DataMember(Name = "sev")]
        public string Sev { get; set; }

        [DataMember(Name = "cat")]
        public string Cat { get; set; }
    }



    [DataContract]
    public class GetNextItemsResponse
    {
        [DataMember(Name = "payload")]
        public PayloadObject Payload { get; set; }

        [DataMember(Name = "exceptions")]
        public ExcepObj Exceptions { get; set; }

        [DataMember(Name = "messages")]
        public string Messages { get; set; }

        [DataMember(Name = "executionTime")]
        public decimal ExecutionTime { get; set; }
    }



    /* ------------------ </Response> -------------- */



    /* ------------------ <Request> ---------------- */



    [DataContract]
    public class GetNextItemsRequest
    {
        [DataMember(Name = "applicationRefId")]
        public string ApplicationRefId { get; set; }

        [DataMember(Name = "dequeueItemsCount")]
        public string DequeueItemsCount { get; set; }

        [DataMember(Name = "UserID")]
        public string UserId { get; set; }
    }



    /* ------------------ </Request> --------------- */
    public class HttpClientTesting
    {

        /*public static async Task<string> GetAuthorizationTokenAsync()
        {​​​​​​​
            var parameters = new Dictionary<string,string>
            {
                {"client_id", "rpa-apps-portal-api"},
                {"client_secret","977BDF8C-0846-4A97-8E9D-75CE94E800F8"},
                {"scopes","rpa-apps-portal-api-v1"},
                {"grant_type","client_credentials"}

            };
            string jsonStr = string.Empty;
            using (HttpClient dynamicsClient = new HttpClient {​​​​​​​ BaseAddress = new Uri("https://myqa.nbg.gr/identity/connect/token") }​​​​​​​)
            {​​​​​​​
                var paramsFinal = parameters;
                jsonStr = await dynamicsClient.PostAsync("https://myqa.nbg.gr/identity/connect/token", new FormUrlEncodedContent(paramsFinal)).Result.Content.ReadAsStringAsync();
            }​​​​​​​
            var token = string.Empty;
            return token;
            
        }​​​​​​​*/
        public static PayloadObject GetNextItems(string Token, GetNextItemsRequest request)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("endpoint") };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            /*var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var result = client.PostAsync("endpoint", content).Result;*/
            var result = client.PostAsJsonAsync<GetNextItemsRequest>("endpoint", request).Result;
            GetNextItemsResponse response = result.Content.ReadFromJsonAsync<GetNextItemsResponse>().Result;
            string payloadString = response.Payload?.ToString();
            PayloadObject payloadResponseInObject = JsonConvert.DeserializeObject<PayloadObject>(payloadString);
            return payloadResponseInObject;
            
        }

    }
}
