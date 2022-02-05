using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteriesQuest
{
    internal static class ChatHelper
    {
        public static string[] ParseChatLog(string chatLog) =>
            (!chatLog.Contains("\r\n") ? new string[] { chatLog } : chatLog.Split("\r\n"))
                .Select(s => s.Replace(" joined the lobby", ""))
                .Select(s => s.Replace(" left the lobby", ""))
                .ToArray();

        public static string ComposeMasteriesSummary(IEnumerable<SummonerViewModel> summoners)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Your masteries:");
            foreach (var summoner in summoners)
            {
                sb.AppendLine($"{summoner.Name}: {summoner.TotalChampions} champs, {summoner.TotalPoints:N0} pts.");
            }
            return sb.ToString();
        }
    }
}
