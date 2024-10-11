using UnityEngine;
using UnityEngine.UI;

public class SelectGameModeScreen : MonoBehaviour
{
    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject rulesScreen;
    [SerializeField] private GameObject mainScreen;

    void Start()
    {
        easyButton.onClick.AddListener(OnEasyButtonClick);
        mediumButton.onClick.AddListener(OnMediumButtonClick);
        hardButton.onClick.AddListener(OnHardButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);

        gameObject.SetActive(false);
    }
    
    private void OnEasyButtonClick()
    {
        CharacterSetter.Instance.ChangeSpeed(GameMode.Easy);
        SetScreensActivity();
    }

    private void OnMediumButtonClick()
    {
        CharacterSetter.Instance.ChangeSpeed(GameMode.Medium);
        SetScreensActivity();
    }

    private void OnHardButtonClick()
    {
        CharacterSetter.Instance.ChangeSpeed(GameMode.Hard);
        SetScreensActivity();
    }

    private void SetScreensActivity()
    {
        gameObject.SetActive(false);
        rulesScreen.SetActive(true);
    }
    private void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        mainScreen.SetActive(true);
    }
}
