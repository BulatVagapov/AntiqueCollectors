using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject selectGameModeScreen;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnStartButtonClick()
    {
        selectGameModeScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnSettingsButtonClick()
    {
        settingsScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
