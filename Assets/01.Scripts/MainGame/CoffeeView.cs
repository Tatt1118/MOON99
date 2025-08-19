using UnityEngine;
using UnityEngine.UI;

public class CoffeeView : MonoBehaviour
{
    [SerializeField] Button coffeeCup;
    [SerializeField] GameObject coffeeSceneUI;

    public void ShowUI()
    {
        coffeeSceneUI.SetActive(true);
    }

    public void HideUI()
    {
        coffeeSceneUI.SetActive(false);
    }
}
