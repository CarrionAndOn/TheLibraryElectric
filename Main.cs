using MelonLoader;
using WeatherElectric.TheLibraryElectric.Melon;

namespace WeatherElectric.TheLibraryElectric
{
    public class Main : MelonMod
    {
        internal const string Name = "The Library Electric";
        internal const string Description = "See how IL2CPP breaks the mod.";
        internal const string Author = "SoulWithMae + BugoBug + EverythingOnArm";
        internal const string Company = "Weather Electric";
        internal const string Version = "2.4.0";
        internal const string DownloadLink = "https://bonelab.thunderstore.io/package/SoulWithMae/TheLibraryElectric/";
        
        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            FieldInjection.Inject();
        }
    }
}