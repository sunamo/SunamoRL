namespace SunamoRL.RL;

using SunamoRL.Interfaces;

public class RL
{
    private static class Xaml
    {
        public static byte LanguageId { get; set; } = 1;

        public static void Initialize(LangsShared lang)
        {
            LanguageId = (byte)lang;
        }
    }

    public static LangsShared Lang
    {
        set => ThisApp.Lang = value;
        get => ThisApp.Lang;
    }

    public static IResourceHelper Loader { get; set; } = null!;

    private static int langsLength = 0;

    static RL()
    {
        langsLength = Enum.GetValues(typeof(LangsShared)).Length;
    }

    public static void Initialize(LangsShared lang)
    {
        RL.Lang = lang;
        AppLangHelperShared.CurrentCulture = new CultureInfo(lang.ToString());
        AppLangHelperShared.CurrentUICulture = new CultureInfo(lang.ToString());
    }
}
