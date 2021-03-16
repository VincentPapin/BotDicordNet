using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using BotDiscord.Class;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Newtonsoft.Json;
using BotDiscord.Class;


namespace BotDiscord.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("Hi")]
        public async Task SalutAsync()
        {
            await ReplyAsync("Hi");
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