using MelonLoader;

namespace WeatherElectric.TheLibraryElectric.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");

        public static MelonPreferences_Entry<int> loggingMode;

        public static void Setup()
        {
            loggingMode = GlobalCategory.GetEntry<int>("LoggingMode") ?? GlobalCategory.CreateEntry("LoggingMode", 0, "Logging Mode", "The level of logging to use. 0 = Important Only, 1 = All");
            GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            GlobalCategory.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup for The Library Electric", 1);
        }
    }
}