using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;


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
        
        
    }
}