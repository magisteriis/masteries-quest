using System.ComponentModel.DataAnnotations;

namespace ChampionMastery
{
    public class SummonerSearch
    {
        [Required]
        public string? SummonerName { get; set; }

        [Required]
        public Camille.Enums.PlatformRoute Region { get; set; } = Camille.Enums.PlatformRoute.NA1;
    }
}
