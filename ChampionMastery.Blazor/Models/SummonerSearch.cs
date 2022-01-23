using System.ComponentModel.DataAnnotations;

namespace ChampionMastery.Blazor
{
    public class SummonerSearch
    {
        [Required]
        public string? SummonerName { get; set; }
    }
}
