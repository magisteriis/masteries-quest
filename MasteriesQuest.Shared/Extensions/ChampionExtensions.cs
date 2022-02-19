using Camille.Enums;

namespace MasteriesQuest;

public static class RandomExtensions
{
    public static Champion ToChampion(this long i)
    {
        return (Champion) i;
    }

    public static string ToUnicode(this bool b)
    {
        return b ? "✅" : "❌";
    }
}