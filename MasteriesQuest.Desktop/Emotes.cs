using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteriesQuest
{
    internal static class Emotes
    {
        public static Uri CrushedIt(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/CrushedIt.png", depth);
        public static Uri DoesNotCompute(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/DoesNotCompute.png", depth);
        public static Uri Hmm(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/Hmm.png", depth);
        public static Uri Hooray(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/Hooray.png", depth);
        public static Uri LookingForThis(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/LookingForThis.png", depth);
        public static Uri NeverAgain(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/NeverAgain.png", depth);
        public static Uri OhNo(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/OhNo.png", depth);
        public static Uri Oops(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/Oops.png", depth);
        public static Uri Pwease(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/Pwease.png", depth);
        public static Uri TearyEyes(byte depth = 0) => _relativeImage("ms-appx:///Assets/Emotes/TearyEyes.png", depth);

        public static Func<byte, Uri>[] NotFound => new Func<byte, Uri>[]
        {
            DoesNotCompute,
            LookingForThis
        };

        public static Func<byte, Uri>[] Error => new Func<byte, Uri>[]
        {
            Hmm,
            NeverAgain,
            OhNo,
            Oops
        };

        public static Func<byte, Uri>[] RateLimit => new Func<byte, Uri>[]
        {
            Pwease,
            TearyEyes
        };

        private static Uri _relativeImage(string relativeUri, byte depth) => new(relativeUri, UriKind.RelativeOrAbsolute);
    }
}
