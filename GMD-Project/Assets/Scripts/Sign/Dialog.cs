using UnityEngine;

namespace Sign
{
    [CreateAssetMenu(menuName = "Dialog")]
    public class Dialog : ScriptableObject
    {
    
        [TextArea(0, 5)]
        public string[] dialogLines;
        public int DialogCount => dialogLines.Length;
    }
}
