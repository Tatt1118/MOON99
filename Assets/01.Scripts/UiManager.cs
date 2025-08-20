using UnityEngine;

public class UiManager : MonoBehaviour
{

    [Header("Še‰æ–Ê‚ÌUI")]
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject coffeeUI;
    //[SerializeField] GameObject novelUI;
    //[SerializeField] GameObject introUI;

    public void ShowMainUI() => SetActiveUI(mainUI);
    public void ShowCoffeeUI() => SetActiveUI(coffeeUI);
    //public void ShowNovelUI() => SetActiveUI(novelUI);
    //public void ShowIntroUI() => SetActiveUI(introUI);

    public void SetActiveUI(GameObject targetUI)
    {
        mainUI.SetActive(false);
        coffeeUI.SetActive(false);
        //novelUI.SetActive(false);
        //introUI.SetActive(false);

        if (targetUI != null) targetUI.SetActive(true);
    }
}
