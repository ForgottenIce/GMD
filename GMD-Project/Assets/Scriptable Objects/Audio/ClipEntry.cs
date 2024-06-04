using System;
using UnityEngine;

namespace Scriptable_Objects.Audio
{
    [Serializable]
    public struct ClipEntry
    {
        public string Name;
        public AudioClip Clip;

        public ClipEntry(string name, AudioClip clip)
        {
            Name = name;
            Clip = clip;
        }
    }
}
