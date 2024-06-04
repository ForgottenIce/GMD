using UnityEngine;

namespace Scriptable_Objects.Audio
{
    [CreateAssetMenu]
    public class AudioClips : ScriptableObject
    {
        public ClipEntry[] Clips;
        
        public AudioClip GetClip(string clipName)
        {
            foreach (var clip in Clips)
            {
                if (clip.Name == clipName)
                {
                    return clip.Clip;
                }
            }

            return null;
        }
    }
}
