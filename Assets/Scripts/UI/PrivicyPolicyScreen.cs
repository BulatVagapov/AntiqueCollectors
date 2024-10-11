using UnityEngine;
using UnityEngine.UI;

public class PrivicyPolicyScreen : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject settingsScreen;

    private void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClick);
        gameObject.SetActive(false);
    }

    private void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        settingsScreen.SetActive(true);
    }
}
