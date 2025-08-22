using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;

public class MainView : MonoBehaviour
{
    [SerializeField] Button coffeeClickButton;
    [SerializeField] Button charaClickButton;
    [SerializeField] TextMeshProUGUI charaTMP;
    [SerializeField] TextMeshProUGUI coffeeTMP;

    public Action onClick;

    public void SetUpButton(Action onClick)
    {
        charaClickButton.onClick.AddListener(() => onClick?.Invoke());
    }

    //テキスト表示
    public void DisplayText()
    {
        charaTMP.gameObject.SetActive(true);
    }

}
