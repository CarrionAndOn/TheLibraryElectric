using FieldInjector;
using TheLibraryElectric.Misc;
using TheLibraryElectric.Rigidbodies;
using TheLibraryElectric.Marrow;
using TheLibraryElectric.Vehicles;
using WeatherElectric.TheLibraryElectric.Behaviours.Environment;
using WeatherElectric.TheLibraryElectric.Behaviours.Markers;
using WeatherElectric.TheLibraryElectric.Behaviours.Marrow;
using WeatherElectric.TheLibraryElectric.Behaviours.PlayerUtil;
using WeatherElectric.TheLibraryElectric.Behaviours.Signals;
using WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders;
using WeatherElectric.TheLibraryElectric.Behaviours.Water;
using WeatherElectric.TheLibraryElectric.Melon;

namespace WeatherElectric.TheLibraryElectric
{
    internal static class FieldInjection
    {
        public static void Inject()
        {
            ModConsole.Msg("Injecting the fields with the fieldinjector which injects fields, crazy isnt it", 1);
            SerialisationHandler.Inject<DoNotFreeze>();
            ModConsole.Msg("Hopefully injected DoNotFreeze", 1);
            SerialisationHandler.Inject<DoNotDestroy>();
            ModConsole.Msg("Hopefully injected DoNotDestroy", 1);
            SerialisationHandler.Inject<SignalReceiver>();
            ModConsole.Msg("Hopefully injected RecieveSignal", 1);
            SerialisationHandler.Inject<SignalSender>();
            ModConsole.Msg("Hopefully injected SendSignal", 1);
            SerialisationHandler.Inject<RigManagerControl>();
            ModConsole.Msg("Hopefully injected RigManagerControl", 1);
            SerialisationHandler.Inject<FreezeRigidbodies>();
            ModConsole.Msg("Hopefully injected FreezeRigidbodies", 1);
            SerialisationHandler.Inject<DestroyOnCollision>();
            ModConsole.Msg("Hopefully injected DestroyOnCollision", 1);
            SerialisationHandler.Inject<TimescaleController>();
            ModConsole.Msg("Hopefully injected TimescaleController", 1);
            SerialisationHandler.Inject<UpdateTMP>();
            ModConsole.Msg("Hopefully injected UpdateTMP", 1);
            SerialisationHandler.Inject<VoidCounterObject>();
            ModConsole.Msg("Hopefully injected VoidCounterObject", 1);
            SerialisationHandler.Inject<RBGravityManager>();
            ModConsole.Msg("Hopefully injected RBGravityManager", 1);
            SerialisationHandler.Inject<GravityChamber>();
            ModConsole.Msg("Hopefully injected GravityChamber", 1);
            SerialisationHandler.Inject<RagdollZone>();
            ModConsole.Msg("Hopefully injected RagdollZone", 1);
            SerialisationHandler.Inject<ForceZone>();
            ModConsole.Msg("Hopefully injected ForceZone", 1);
            SerialisationHandler.Inject<SpawnOnTriggerEnter>();
            ModConsole.Msg("Hopefully injected SpawnOnTriggerEnter", 1);
            SerialisationHandler.Inject<DespawnPooledObject>();
            ModConsole.Msg("Hopefully injected DespawnPooledObject", 1);
            SerialisationHandler.Inject<RandomAudioPlayer>();
            ModConsole.Msg("Hopefully injected RandomAudioPlayer", 1);
            SerialisationHandler.Inject<IgnoreRigidbody>();
            ModConsole.Msg("Hopefully injected IgnoreRigidbody", 1);
            SerialisationHandler.Inject<RbBuoyancyManager>();
            ModConsole.Msg("Hopefully injected RbBuoyancyManager", 1);
            SerialisationHandler.Inject<WaterZone>();
            ModConsole.Msg("Hopefully injected WaterZone", 1);
            SerialisationHandler.Inject<SignalTrigger>();
            ModConsole.Msg("Hopefully injected SignalTrigger", 1);
            SerialisationHandler.Inject<SignalTriggerer>();
            ModConsole.Msg("Hopefully injected SignalTriggerer", 1);
            SerialisationHandler.Inject<HandMonitor>();
            ModConsole.Msg("Hopefully injected HandMonitor", 1);
            SerialisationHandler.Inject<SwimmingController>();
            ModConsole.Msg("Hopefully injected SwimmingController", 1);
            SerialisationHandler.Inject<InvokeIfLibInstalled>();
            ModConsole.Msg("Hopefully injected InvokeIfLibInstalled", 1);
            SerialisationHandler.Inject<RagdollOnCollide>();
            ModConsole.Msg("Hopefully injected RagdollOnCollide", 1);
            SerialisationHandler.Inject<InvokeWhenCounter>();
            ModConsole.Msg("Hopefully injected InvokeWhenCounter", 1);
            SerialisationHandler.Inject<PhotonThruster>();
            ModConsole.Msg("Hopefully injected PhotonThruster", 1);
            SerialisationHandler.Inject<TLE_SimpleRaycast>();
            ModConsole.Msg("Hopefully injected TLE_SimpleRaycast", 1);
            SerialisationHandler.Inject<RbSpeedMeter>();
            ModConsole.Msg("Hopefully injected RbSpeedMeter", 1);
            SerialisationHandler.Inject<ScoreKeeper>();
            ModConsole.Msg("Hopefully injected ScoreKeeper", 1);
            SerialisationHandler.Inject<RealtimeAnalogClock>();
            ModConsole.Msg("Hopefully injected RealtimeAnalogClock", 1);
            SerialisationHandler.Inject<CoolerSpawnablePlacer>();
            ModConsole.Msg("Hopefully injected CoolerSpawnablePlacer", 1);
            SerialisationHandler.Inject<PlungerButBetter>();
            ModConsole.Msg("Hopefully injected PlungerButBetter", 1);
            SerialisationHandler.Inject<PlungerListener>();
            ModConsole.Msg("Hopefully injected PlungerListener", 1);
            SerialisationHandler.Inject<HandHolder>();
            ModConsole.Msg("Hopefully injected HandHolder", 1);
            SerialisationHandler.Inject<Vector3Holder>();
            ModConsole.Msg("Hopefully injected Vector3Holder", 1);
            SerialisationHandler.Inject<QuaternionHolder>();
            ModConsole.Msg("Hopefully injected QuaternionHolder", 1);
            SerialisationHandler.Inject<FloatHolder>();
            ModConsole.Msg("Hopefully injected FloatHolder", 1);
            SerialisationHandler.Inject<IntHolder>();
            ModConsole.Msg("Hopefully injected IntHolder", 1);
            SerialisationHandler.Inject<RigManagerHolder>();
            ModConsole.Msg("Hopefully injected RigManagerHolder", 1);
            SerialisationHandler.Inject<FindClosestRigManager>();
            ModConsole.Msg("Hopefully injected FindClosestRigManager", 1);
            SerialisationHandler.Inject<TransformHolder>();
            ModConsole.Msg("Hopefully injected TransformHolder", 1);
            // arm forgot to inject this and then wondered why it didnt work
            SerialisationHandler.Inject<Boat>();
            ModConsole.Msg("Hopefully injected Boat", 1);
            SerialisationHandler.Inject<TimeCycleHandler>();
            ModConsole.Msg("Hopefully injected TimeCycleHandler", 1);
            SerialisationHandler.Inject<SetAudioMixer>();
            ModConsole.Msg("Hopefully injected SetAudioMixer", 1);
            ModConsole.Msg("All fields are probably injected. I can't tell since this isn't async so I can't slap a bool on it.", 1);
        }
    }
}