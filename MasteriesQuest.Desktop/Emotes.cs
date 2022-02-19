namespace MasteriesQuest;

internal static class Emotes
{
    // TODO: partial, one for Desktop and one for Web.
    public static readonly string Directory = "ms-appx:///Assets/Emotes/";
    public static Uri CrushedIt => _relativeImage("CrushedIt.png");
    public static Uri DoesNotCompute => _relativeImage("DoesNotCompute.png");
    public static Uri Hmm => _relativeImage("Hmm.png");
    public static Uri Hooray => _relativeImage("Hooray.png");
    public static Uri LookingForThis => _relativeImage("LookingForThis.png");
    public static Uri NeverAgain => _relativeImage("NeverAgain.png");
    public static Uri OhNo => _relativeImage("OhNo.png");
    public static Uri Oops => _relativeImage("Oops.png");
    public static Uri Pwease => _relativeImage("Pwease.png");
    public static Uri TearyEyes => _relativeImage("TearyEyes.png");

    public static Uri[] NotFound => new[]
    {
        DoesNotCompute,
        LookingForThis
    };

    public static Uri[] Error => new[]
    {
        Hmm,
        NeverAgain,
        OhNo,
        Oops
    };

    public static Uri[] RateLimit => new[]
    {
        Pwease,
        TearyEyes
    };

    private static Uri _relativeImage(string relativeUri)
    {
        return new(Path.Combine(Directory, relativeUri), UriKind.RelativeOrAbsolute);
    }
}