using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;

public class MainView : MonoBehaviour
{
    [SerializeField] Button charaClickButton;
    [SerializeField] TextMeshProUGUI charaTMP;
    [SerializeField] TextMeshProUGUI dialogueTMP;
    [SerializeField] StoryLineSO[] storyData;

    public StoryLineSO[] StoryLineSO => storyData;

    // ボタン設定
    public void SetUpButton(Action onClick)
    {
        charaClickButton.onClick.RemoveAllListeners();
        charaClickButton.onClick.AddListener(() => onClick?.Invoke());
    }

    // テキスト表示
    public void DisplayText(string characterName, string dialogue)
    {
        charaTMP.text = characterName;
        dialogueTMP.text = dialogue;
    }
}
