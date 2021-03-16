using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BotDiscord.Class
{
    public class ApexAPI
    {
        public string ApiKey = Environment.GetEnvironmentVariable("ApexApiKey", EnvironmentVariableTarget.User);
        public string Uri = "https://api.mozambiquehe.re/bridge?version=5&platform=PC&player={0}&auth={1}";
        public string Name { get; set; }


        //Constructor
        public ApexAPI(string name)
        {
            Name = name;
            //Build URL with name
            Uri = Uri.Replace("{0}", Name);
            Uri = Uri.Replace("{1}", ApiKey);
        }
    }
    
    public class Root
    {
        public Global global { get; set; }
        public Realtime realtime { get; set; }
        public Legends legends { get; set; }
        public MozambiquehereInternal mozambiquehere_internal { get; set; }
        public Total total { get; set; }
    }
    public class Global
    {
        public string name { get; set; }
        public long uid { get; set; }
        public string avatar { get; set; }
        public string platform { get; set; }
        public int level { get; set; }
        public int toNextLevelPercent { get; set; }
        public int internalUpdateCount { get; set; }
        public Bans bans { get; set; }
        public Rank rank { get; set; }
        public Battlepass battlepass { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Bans
    {
        public bool isActive { get; set; }
        public int remainingSeconds { get; set; }
        public string last_banReason { get; set; }
    }

    public class Rank
    {
        public int rankScore { get; set; }
        public string rankName { get; set; }
        public int rankDiv { get; set; }
        public int ladderPosPlatform { get; set; }
        public string rankImg { get; set; }
        public string rankedSeason { get; set; }
    }

    public class History
    {
        public int season1 { get; set; }
        public int season2 { get; set; }
        public int season3 { get; set; }
        public int season4 { get; set; }
        public int season5 { get; set; }
        public int season6 { get; set; }
        public int season7 { get; set; }
        public int season8 { get; set; }
    }

    public class Battlepass
    {
        public string level { get; set; }
        public History history { get; set; }
    }


    public class Realtime
    {
        public string lobbyState { get; set; }
        public int isOnline { get; set; }
        public int isInGame { get; set; }
        public int canJoin { get; set; }
        public int partyFull { get; set; }
        public string selectedLegend { get; set; }
    }

    public class Datum
    {
        public string name { get; set; }
        public int value { get; set; }
        public string key { get; set; }
    }

    public class Badge
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class GameInfo
    {
        public string skin { get; set; }
        public string frame { get; set; }
        public string pose { get; set; }
        public object intro { get; set; }
        public List<Badge> badges { get; set; }
    }

    public class ImgAssets
    {
        public string icon { get; set; }
        public string banner { get; set; }
    }

    public class Selected
    {
        public string LegendName { get; set; }
        public List<Datum> data { get; set; }
        public GameInfo gameInfo { get; set; }
        public ImgAssets ImgAssets { get; set; }
    }

    public class Bangalore
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Bloodhound
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Lifeline
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Caustic
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Gibraltar
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Mirage
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Pathfinder
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Wraith
    {
        public List<Datum> data { get; set; }
        public ImgAssets ImgAssets { get; set; }
    }

    public class Octane
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Wattson
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Crypto
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Revenant
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Loba
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Rampart
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Horizon
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class Fuse
    {
        public ImgAssets ImgAssets { get; set; }
    }

    public class All
    {
        public Bangalore Bangalore { get; set; }
        public Bloodhound Bloodhound { get; set; }
        public Lifeline Lifeline { get; set; }
        public Caustic Caustic { get; set; }
        public Gibraltar Gibraltar { get; set; }
        public Mirage Mirage { get; set; }
        public Pathfinder Pathfinder { get; set; }
        public Wraith Wraith { get; set; }
        public Octane Octane { get; set; }
        public Wattson Wattson { get; set; }
        public Crypto Crypto { get; set; }
        public Revenant Revenant { get; set; }
        public Loba Loba { get; set; }
        public Rampart Rampart { get; set; }
        public Horizon Horizon { get; set; }
        public Fuse Fuse { get; set; }
    }

    public class Legends
    {
        public Selected selected { get; set; }
        public All all { get; set; }
    }

    public class RateLimit
    {
        public int max_per_second { get; set; }
        public string current_req { get; set; }
    }

    public class MozambiquehereInternal
    {
        public bool isNewToDB { get; set; }
        public string claimedBy { get; set; }
        public string APIAccessType { get; set; }
        public string ClusterID { get; set; }
        public RateLimit rate_limit { get; set; }
    }

    public class Kills
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class WinsSeason1
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class KillsSeason1
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class Kd
    {
        public int value { get; set; }
        public string name { get; set; }
    }

    public class Total
    {
        public Kills kills { get; set; }
        public WinsSeason1 wins_season_1 { get; set; }
        public KillsSeason1 kills_season_1 { get; set; }
        public Kd kd { get; set; }
    }
}