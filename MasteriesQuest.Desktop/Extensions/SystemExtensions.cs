using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteriesQuest
{
    internal static class ArrayExtensions
    {
        public static T Random<T>(this T[] array) => array[System.Random.Shared.Next(0, array.Length)];
    }
}
