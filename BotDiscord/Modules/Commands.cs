using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using BotDiscord.Class;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Newtonsoft.Json;
using BotDiscord.Class;
using RestSharp;


namespace BotDiscord.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("NW")]
        public async Task QueueAsync(string server)
        {
            string message = "";
            string url = "https://firstlight.newworldstatus.com/ext/v1/worlds/";
            string apiKey =
                "FIRSTLIGHTv4.v4.local.cTRMomMVHJWuxnYoh2Md8MmoOzFy5ffGN1R6Q_5Ht9YG9sqQJXhjgWZG7jROIEpPvrusPNXSrzpSe9zED6hYK_tvC5YE9D6Ha3CdITr3pfgpwihkKMEzVxE0Go-vumSA1PXhdfu4gNcYj5K5J6vnW1ED5cYWpgSDeViEo_ZQhFa7S5MuXS7vEePVCKQhIGNrc-LYsE-0ixC18Hz704RnTRowCPFAeAzt85UKsLAGv0WCE3QWEExM00pFEA7RIpzS4Xf-8WFjRO4Te9TFjamKihyuAY6fKVVOFKQ";

            url += server.ToLower();


            var data = await getDataApiNw(server);

            message =
                $"{server} {data.message.status_enum} : \n - Nbre de joueurs en ligne {data.message.players_current}\n - Nbre de joueurs max {data.message.players_maximum}\n - Queue {data.message.queue_current} joueurs temps d'attente : {data.message.queue_wait_time_minutes} minutes";


            await ReplyAsync(message);
        }

        private async Task<ApiNw> getDataApiNw(string server)
        {
            string url = "https://firstlight.newworldstatus.com/ext/v1/worlds/";
            string apiKey =
                "FIRSTLIGHTv4.v4.local.cTRMomMVHJWuxnYoh2Md8MmoOzFy5ffGN1R6Q_5Ht9YG9sqQJXhjgWZG7jROIEpPvrusPNXSrzpSe9zED6hYK_tvC5YE9D6Ha3CdITr3pfgpwihkKMEzVxE0Go-vumSA1PXhdfu4gNcYj5K5J6vnW1ED5cYWpgSDeViEo_ZQhFa7S5MuXS7vEePVCKQhIGNrc-LYsE-0ixC18Hz704RnTRowCPFAeAzt85UKsLAGv0WCE3QWEExM00pFEA7RIpzS4Xf-8WFjRO4Te9TFjamKihyuAY6fKVVOFKQ";

            url += server.ToLower();

            var data = new ApiNw();
            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    apiKey);
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(url);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    data = JsonConvert.DeserializeObject<ApiNw>(EmpResponse);
                }
            }


            return data;
        }


        [Command("Hi")]
        public async Task SalutAsync()
        {
            await ReplyAsync("bien ou bien ?");
        }

        [Command("bien")]
        public async Task BienAsync()
        {
            await ReplyAsync("T'es con ou quoi ?");
        }

        [Command("Rand")]
        public async Task RandAsync()
        {
            Random random = new Random();
            int nbre = random.Next(100);
            await ReplyAsync($"Nombre aléatoire : {nbre}");
        }

        [Command("Ping")]
        public async Task PingAsync()
        {
            Random random = new Random();
            int nbre = random.Next(100);
            await ReplyAsync($"Nombre aléatoire : {nbre}");
        }

        [Command("Users")]
        public async Task UserAsync()
        {
            string roleList = "";
            var roles = Context.Guild.Roles;
            foreach (var role in roles)
            {
                roleList += role.Name + "\n";
            }

            int nbreUser = Context.Guild.MemberCount;

            await Context.Channel.SendMessageAsync($"{nbreUser} utilisateurs, roles : \n" + roleList);
        }


        [Command("IP")]
        public async Task IPAsync()
        {
            var host = await Dns.GetHostEntryAsync(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    await ReplyAsync($"IP : {ip.ToString()}");
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        [Command("APEX")]
        public async Task ApexGetRank(string name)
        {
            ApexAPI apexApi = new ApexAPI(name);

            using (var webClient = new WebClient())
            {
                var rawData = webClient.DownloadString(apexApi.Uri);
                var playerStat = JsonConvert.DeserializeObject<Root>(rawData);

                var message = $"{playerStat.global.name} : {Environment.NewLine}" +
                              $"Level {playerStat.global.level}{Environment.NewLine}" +
                              $"Total kills {playerStat.total.kills.value}{Environment.NewLine}" +
                              $"Rank {playerStat.global.rank.rankName}{Environment.NewLine}" +
                              $"RankDiv {playerStat.global.rank.rankDiv}{Environment.NewLine}" +
                              $"RankScore {playerStat.global.rank.rankScore}{Environment.NewLine}";

                await ReplyAsync(message);
            }

            // Console.WriteLine(apexApi.global.rank.rankScore);
        }
    }
}