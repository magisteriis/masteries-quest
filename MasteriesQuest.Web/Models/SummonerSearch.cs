using System.ComponentModel.DataAnnotations;

namespace MasteriesQuest
{
    public class SummonerSearch
    {
        [Required]
        public string? SummonerName { get; set; }

        [Required]
        public Camille.Enums.PlatformRoute Platform { get; set; } = Camille.Enums.PlatformRoute.NA1;
    }
}
