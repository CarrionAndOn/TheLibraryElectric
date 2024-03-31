using System;
using BoneLib;
using SLZ.SFX;
using TheLibraryElectric.Melon;
using UnityEngine;
using UnityEngine.Audio;

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Set Audio Mixer")]
#endif
    public class SetAudioMixer : MonoBehaviour
    {
#if MELONLOADER
        public bool applyToAudioSource;
        public MixerType audioSourceMixerType = MixerType.Sfx;
        public AudioSource[] audioSources;
        public bool applyToImpactSfx;
        public MixerType impactSfxMixerType = MixerType.Sfx;
        public ImpactSFX[] impactSfxs;
        public bool applyToGunSfx;
        public MixerType gunSfxGunshotMixerType = MixerType.Gunshot;
        public MixerType gunSfxInteractionMixerType = MixerType.Sfx;
        public GunSFX[] gunSfxs;
#else
        [Header("Audio Source")]
        [Tooltip("Apply the mixer to an AudioSource")]
        public bool applyToAudioSource;
        [Tooltip("The mixer type to apply to the AudioSource")]
        public MixerType audioSourceMixerType = MixerType.Sfx;
        [Tooltip("The AudioSource to apply the mixer to")]
        public AudioSource[] audioSources;
        [Header("Impact SFX")]
        [Tooltip("Apply the mixer to an ImpactSFX")]
        public bool applyToImpactSfx;
        [Tooltip("The mixer type to apply to the ImpactSFX")]
        public MixerType impactSfxMixerType = MixerType.Sfx;
        [Tooltip("The ImpactSFX to apply the mixer to")]
        public ImpactSFX[] impactSfxs;
        [Header("Gun SFX")]
        [Tooltip("Apply the mixer to a GunSFX")]
        public bool applyToGunSfx;
        [Tooltip("The mixer type to apply to the GunSFX gunshot")]
        public MixerType gunSfxGunshotMixerType = MixerType.Gunshot;
        [Tooltip("The mixer type to apply to the GunSFX interaction")]
        public MixerType gunSfxInteractionMixerType = MixerType.Sfx;
        [Tooltip("The GunSFX to apply the mixer to")]
        public GunSFX[] gunSfxs;
#endif

        private void Start()
        {
            if (applyToAudioSource && audioSources.Length > 0)
            {
                foreach (var audioSource in audioSources)
                {
                    audioSource.outputAudioMixerGroup = GetMixerGroup(audioSourceMixerType);
                }
            }
            if (applyToImpactSfx && impactSfxs.Length > 0)
            {
                foreach (var impactSfx in impactSfxs)
                {
                    impactSfx.outputMixer = GetMixerGroup(impactSfxMixerType);
                }
            }
            if (applyToGunSfx && gunSfxs.Length > 0)
            {
                foreach (var gunSfx in gunSfxs)
                {
                    gunSfx.gunshotOutputMixer = GetMixerGroup(gunSfxGunshotMixerType);
                    gunSfx.interactionOutputMixer = GetMixerGroup(gunSfxInteractionMixerType);
                }
            }
        }

        private static AudioMixerGroup GetMixerGroup(MixerType type)
        {
            AudioMixerGroup mixerGroup = null;
            switch (type)
            {
                case MixerType.Sfx:
                    mixerGroup = Audio.SFXMixer;
                    break;
                case MixerType.Music:
                    mixerGroup = Audio.MusicMixer;
                    break;
                case MixerType.Gunshot:
                    mixerGroup = Audio.GunshotMixer;
                    break;
                case MixerType.Master:
                    mixerGroup = Audio.MasterMixer;
                    break;
                default:
                    ModConsole.Error("MixerType not set properly!");
                    break;
            }
            return mixerGroup;
        }
        
        public SetAudioMixer(IntPtr ptr) : base(ptr) { }
    }
}

public enum MixerType
{
    Sfx,
    Music,
    Gunshot,
    Master
}