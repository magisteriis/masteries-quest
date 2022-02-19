namespace MasteriesQuest;

internal static class ArrayExtensions
{
    public static T Random<T>(this T[] array)
    {
        return array[System.Random.Shared.Next(0, array.Length)];
    }
}