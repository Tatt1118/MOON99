using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "StoryData")]
public class StoryLineSO : ScriptableObject
{
    public string storyID;
    public int storyNumber;
    public List<StoryChoice> choices; // ���򂪂���ꍇ
    public List<Dialogue> dialogues;
}

[System.Serializable]
public class StoryChoice
{
    public string choiceText;        // �I�����̕���
    public StoryLineSO nextLine;     // �I�񂾌�ɑ���SO
}

[System.Serializable]
public class Dialogue
{
    public string characterName;            // �L������
    [TextArea] public string dialogue;
}