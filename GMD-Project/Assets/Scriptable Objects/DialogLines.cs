using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogLines")]
public class DialogLines : ScriptableObject
{
   public string[] dialogLines;
   public int DialogCount => dialogLines.Length;
}
