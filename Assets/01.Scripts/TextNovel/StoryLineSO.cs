using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "StoryData")]
public class StoryLineSO : ScriptableObject
{
    public string storyID;
    public int storyNumber;
    public List<StoryChoice> choices; // •ªŠò‚ª‚ ‚éê‡
    public List<Dialogue> dialogues;
}

[System.Serializable]
public class StoryChoice
{
    public string choiceText;        // ‘I‘ğˆ‚Ì•¶Œ¾
    public StoryLineSO nextLine;     // ‘I‚ñ‚¾Œã‚É‘±‚­SO
}

[System.Serializable]
public class Dialogue
{
    public string characterName;            // ƒLƒƒƒ‰–¼
    [TextArea] public string dialogue;
}