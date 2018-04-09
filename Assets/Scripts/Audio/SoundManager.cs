using System;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public enum SoundType
    {
        FailNote,
        GoodNote,
        PerfectNote,
    }

    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip failNoteClip;
        [SerializeField] private AudioClip goodNoteClip;
        [SerializeField] private AudioClip perfectNoteClip;

        private readonly Dictionary<SoundType, AudioClip> clips = new Dictionary<SoundType, AudioClip>(Enum.GetValues(typeof(SoundType)).Length);

        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();

            clips[SoundType.FailNote] = failNoteClip;
            clips[SoundType.GoodNote] = goodNoteClip;
            clips[SoundType.PerfectNote] = perfectNoteClip;
        }

        public void PlaySound(SoundType _type)
        {
            source.PlayOneShot(clips[_type]);
        }
    }
}