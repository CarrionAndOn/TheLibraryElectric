﻿using MelonLoader;

namespace TheLibraryElectric
{
    public class Main : MelonMod
    {
        internal const string Name = "The Library Electric";
        internal const string Description = "Condemn him to the IL2CPP.";
        internal const string Author = "CarrionAndOn";
        internal const string Company = "Weather Electric";
        internal const string Version = "0.0.0";
        internal const string DownloadLink = "null";
        public override void OnInitializeMelon()
        {
            FieldInjector.SerialisationHandler.Inject<DoNotFreeze>();
            FieldInjector.SerialisationHandler.Inject<DoNotDestroy>();
            FieldInjector.SerialisationHandler.Inject<RecieveSignal>();
            FieldInjector.SerialisationHandler.Inject<SendSignal>();
            FieldInjector.SerialisationHandler.Inject<MrSplitter>();
            FieldInjector.SerialisationHandler.Inject<FreezeRigidbodies>();
            FieldInjector.SerialisationHandler.Inject<DestroyOnCollision>();
        }
    }
}