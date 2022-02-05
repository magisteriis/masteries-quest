using Camille.Enums;

namespace MasteriesQuest
{
    public static class RandomExtensions
    {
        public static Champion ToChampion(this long i) => (Champion)i;
        public static string ToUnicode(this bool b) => b ? "✅" : "❌";
    }
}
