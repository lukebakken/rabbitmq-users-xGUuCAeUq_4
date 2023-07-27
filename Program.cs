using System.Text;

string basicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes("guest:guest"));
HttpClient httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {basicAuth}");

string jsonBody = "{\"payload\":\"hello world from sage 100\",\"payload_encoding\":\"string\",\"properties\":{},\"routing_key\":\"CustomerOrder_SageSync\"}";
StringContent stringContent = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(new Uri("http://localhost:15672/api/exchanges/%2f/amq.default/publish"), stringContent);

Console.WriteLine(httpResponseMessage);
