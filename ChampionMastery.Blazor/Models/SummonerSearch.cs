using System.ComponentModel.DataAnnotations;

namespace ChampionMastery
{
    public class SummonerSearch
    {
        [Required]
        public string? SummonerName { get; set; }
    }
}
