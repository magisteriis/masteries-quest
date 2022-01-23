using Camille.Enums;

namespace ChampionMastery
{
    public static class RandomExtensions
    {
        public static Champion ToChampion(this long i) => (Champion)i;
        public static string ToUnicode(this bool b) => b ? "✅" : "❌";
    }
}
