using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

#nullable enable

namespace MasteriesQuest.ViewModels
{
    public class SummonerSearchViewModel
    {
        [Required]
        public string? SummonerName { get; set; }

        [Required]
        public Camille.Enums.PlatformRoute Platform { get; set; } = Camille.Enums.PlatformRoute.NA1;
    }
}
