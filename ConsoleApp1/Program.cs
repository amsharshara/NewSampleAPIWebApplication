using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        public class Auth
        {
            public string Handler { get; set; }
        }
        public class car
        {

            public int id { get; set; }

            public string name { get; set; }
        }

        static async Task Main(string[] args)
        {


            //get
            var ch = new System.Net.Http.HttpClient();
            var msg = await ch.GetAsync("https://localhost:7119/msg");
            var res = await msg.Content.ReadAsStringAsync();
            Console.WriteLine(res);
            //
            var msgHi = await ch.GetAsync("https://localhost:7119/msg/Tester");
            var resMsg = await msgHi.Content.ReadAsStringAsync();
            Console.WriteLine(resMsg);

            //post
            //ch.DefaultRequestHeaders.Add("id", "1");
            var mp = await ch.PostAsync("https://localhost:7119/msg", null);
            var resp = await mp.Content.ReadAsByteArrayAsync();
            string resps = System.Text.Encoding.UTF8.GetString(resp);
            Console.WriteLine(resps);

            //post json 
            List<car> lst = new List<car>()
            {
                new car { id = 1, name="a"},
                new car { id = 2, name="aa"}
            };

            var lstjson = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
            var hlstjson = new StringContent(lstjson,
               Encoding.UTF8, "application/json");

            var relstjson = await ch.PostAsync("https://localhost:7119/msglst", hlstjson);
            var rh = await relstjson.Content.ReadAsByteArrayAsync(); //relstjson.Content.ReadAsStringAsync();
            Console.WriteLine(Encoding.UTF8.GetString(rh));

            //get jwt

            ch.DefaultRequestHeaders.Add("username", "");
            ch.DefaultRequestHeaders.Add("password", "");
            var jwt = await ch.PostAsync("https://localhost:7119/auth", null);
            var bre = await jwt.Content.ReadAsByteArrayAsync();
            var bres = System.Text.Encoding.UTF8.GetString(bre);
            var authclass = Newtonsoft.Json.JsonConvert.DeserializeObject<Auth>(bres);
            //
            ch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authclass.Handler);
            var testjwt = await ch.GetAsync("https://localhost:7119/newAuth");
            var rrr = await testjwt.Content.ReadAsStringAsync();
            //
            Console.WriteLine(rrr);





            //var ch1 = new System.Net.Http.HttpClient();
            //ch1.DefaultRequestHeaders.Add("username", "1");
            //ch1.DefaultRequestHeaders.Add("password", "2");
            //var resauth = await ch1.PostAsync("https://localhost:7119/auth", null);
            //string jwrt1 = await resauth.Content.ReadAsStringAsync();
            //var jwt = await resauth.Content.ReadAsByteArrayAsync();
            //var ssjwt = Encoding.UTF8.GetString(jwt);
            //var ssssjwt = Newtonsoft.Json.JsonConvert.DeserializeObject<Authtoken>(ssjwt);
            //ch1.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ssssjwt.token);
            //var autg = await ch1.GetAsync("https://localhost:7119/test");
            //var reaut = await autg.Content.ReadAsStringAsync();
            //Console.WriteLine(reaut);








            //  var hc=new HttpClient();
            //  var res=await hc.GetAsync("https://localhost:7125");
            //  var msg=await res.Content.ReadAsStringAsync();            
            //  Console.WriteLine(msg);
            //  //
            //  var m=await hc.GetStringAsync("https://localhost:7125");
            //  Console.WriteLine(m);
            //  //json
            //  var getjs = await hc.GetAsync("https://localhost:7125/json");
            //  var reget = await getjs.Content.ReadAsStringAsync();
            //  var lst =Newtonsoft.Json.JsonConvert.DeserializeObject<List<WeatherForecast>>(reget);
            //  Console.WriteLine(lst);
            //  //
            //  var hm = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7125");

            //  var ssr = await hc.SendAsync(hm);
            //  Console.WriteLine(ssr);
            //  //
            //  // hc.DefaultRequestHeaders.Add("", "");
            //  hc.DefaultRequestHeaders.Add("id", "23");
            //  var srp=await hc.PostAsync("https://localhost:7125",null);
            //  Console.WriteLine(srp);
            //  //
            //var arr = new List<WeatherForecast>() {
            //          new WeatherForecast() { TemperatureC=1, Summary="1",Date=DateOnly.FromDateTime(DateTime.Now) },
            //          new WeatherForecast() { TemperatureC=2, Summary="2",Date=DateOnly.FromDateTime(DateTime.Now) },
            //          new WeatherForecast() { TemperatureC=3, Summary="3",Date=DateOnly.FromDateTime(DateTime.Now)},
            //      };
            //  var c=Newtonsoft.Json.JsonConvert.SerializeObject(arr);
            //  var harr = new StringContent(c);
            //  var srl = await hc.PostAsync("https://localhost:7125", harr);
            //  Console.WriteLine(srl); 






            ////////////test api

            // var capi = new HttpClient();

            // capi.DefaultRequestHeaders.Add("User-Agent", "C# program");
            // var msg = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7125/test/say");

            // var sre=await capi.SendAsync(msg);

            // var cdt=await capi.GetStringAsync("https://localhost:7125/test/say");

            //var gh =  await capi.GetAsync("https://localhost:7125/test/1");
            // var hr1=await gh.Content.ReadAsByteArrayAsync();
            // var t=System.Text.Encoding.UTF8.GetString(hr1);
            // var hr2 = await gh.Content.ReadAsStringAsync();
            // var res = Newtonsoft.Json.JsonConvert.DeserializeObject < List<KeyValuePair<int, string>>>(hr2);
            // //var hr3 = await gh.Content.ReadAsStreamAsync();

            // var sres = Newtonsoft.Json.JsonConvert.SerializeObject(res);
            // var cres=new StringContent(sres,System.Text.Encoding.UTF8,System.Net.Mime.MediaTypeNames.Application.Json);
            // var ss = await capi.PostAsync("https://localhost:7125/test/new", cres);


            // var crt = new System.Net.Http.FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("id", "1") });
            // var ss1 = await capi.PostAsync("https://localhost:7125/test/form", crt);

            // var l = Newtonsoft.Json.JsonConvert.SerializeObject(new { id = 1 });

            // var cr = new System.Net.Http.StringContent(l, System.Text.Encoding.UTF8, "application/json");

            // var ch = new StringContent("1", System.Text.Encoding.UTF8, MediaTypeNames.Text.Plain);
            // System.Net.Http.MultipartFormDataContent fd = new MultipartFormDataContent();
            // fd.Add(ch, "id");
            // var ss3= await capi.PostAsync("https://localhost:7125/test/form", fd);
            // //capi.DefaultRequestHeaders.Add("id", "1");


            // var ss2 = await capi.PostAsJsonAsync<List<KeyValuePair<int, string>>>("https://localhost:7125/test/new",res);
            // Console.Write(ss.ToString());
            //
            //
            //
            //try
            //{

            //    ////
            //    SmtpClient smtpClient = new SmtpClient("mail.yourcourses.info", 26);
            //    smtpClient.EnableSsl = true;
            //    smtpClient.Credentials = new NetworkCredential("noreply@yourcourses.info", "qmYVS5Jy1M");//new NetworkCredential(_configuration["EmailConfigs:SmtpUsername"].ToString(), _configuration["EmailConfigs:SmptPassword"].ToString());
            //    smtpClient.SendCompleted += SmtpClient_SendCompleted;

            //    smtpClient.Send("noreply@yourcourses.info", "amsharshara@gmail.com", "ddddd", "Dddddd");
            //}
            //catch (Exception ex)
            //{
            //}


            /////jwt

            ////username
            //var login = Newtonsoft.Json.JsonConvert.SerializeObject(new { Username = "1", Password = "2" });
            //StringContent sc = new StringContent(login, System.Text.Encoding.UTF8, "application/json");
            ////get token
            //HttpClient client = new HttpClient();
            //var getToken = client.PostAsync("https://localhost:7216/API/ClassUsers/AuthenticateUser", sc).GetAwaiter().GetResult();
            //var resbtye = getToken.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            //var resToken = System.Text.Encoding.UTF8.GetString(resbtye);
            ////
            //var jwt = Newtonsoft.Json.JsonConvert.DeserializeObject<Authtoken>(resToken);
            ////get authorize api
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt.token);
            //var getuser = client.GetAsync("https://localhost:7216/API/ClassUsers").GetAwaiter().GetResult();


            Console.Read();
        }


    }

}