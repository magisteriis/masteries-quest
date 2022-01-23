using System.Text.Json.Serialization;

namespace ChampionMastery
{
    public class Champion2
    {
        [JsonPropertyName("Key")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
