using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "StoryData")]
public class StoryLineSO : ScriptableObject
{
    public string characterName;     // �N�̃Z���t��
    [TextArea(3, 10)]
    public string text;              // �Z���t�{��
    public List<StoryChoice> choices; // ���򂪂���ꍇ
}

[System.Serializable]
public class StoryChoice
{
    public string choiceText;        // �I�����̕���
    public StoryLineSO nextLine;     // �I�񂾌�ɑ���SO
}