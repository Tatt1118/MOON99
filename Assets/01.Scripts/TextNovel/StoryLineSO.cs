using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "StoryData")]
public class StoryLineSO : ScriptableObject
{
    public string characterName;     // 誰のセリフか
    [TextArea(3, 10)]
    public string text;              // セリフ本文
    public List<StoryChoice> choices; // 分岐がある場合
}

[System.Serializable]
public class StoryChoice
{
    public string choiceText;        // 選択肢の文言
    public StoryLineSO nextLine;     // 選んだ後に続くSO
}