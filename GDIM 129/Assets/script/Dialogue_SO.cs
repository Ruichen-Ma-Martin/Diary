using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLine", menuName = "Scriptable Objects/DialogueLine", order = 1)]
public class Dialogue_SO : ScriptableObject
{
   public string[] _lines;
    public string[] _playerReplyOptions;
    public Dialogue_SO[] _npcReplies;
    public int _SanNumber;
    public bool _isFlash;

}
