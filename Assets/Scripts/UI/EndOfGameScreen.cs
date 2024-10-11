using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button homeButton;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameScreen;

    [SerializeField] private ResultDetails playerResultDetails;
    [SerializeField] private ResultDetails enemyResultDetails;

    private string winResultText = "you win!";
    private string lostResultText = "you lost!";

    private void Start()
    {
        homeButton.onClick.AddListener(OnHomeButtonClick);
        restartButton.onClick.AddListener(OnRestartButtonClick);
        WinnerDeterminator.Instance.WinnerIsDeterminated += OnWinnerIsDeterminated;
        GameManager.Instance.GameCycleEndEvent += () => gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnRestartButtonClick()
    {
        GameManager.Instance.OnGameCycleStart();
        gameObject.SetActive(false);
        gameScreen.SetActive(true);
    }

    private void OnHomeButtonClick()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnWinnerIsDeterminated(CollectedItemsCounter[] result, CharacterType winner)
    {
        if (winner.Equals(CharacterType.Player))
        {
            resultText.text = winResultText;
        }
        else
        {
            resultText.text = lostResultText;
        }

        if (result[0].CharacterType.Equals(CharacterType.Player))
        {
            playerResultDetails.SetResultsDetails(result[0].ItemKeeper.CountOfCollectedItemsByType);
            enemyResultDetails.SetResultsDetails(result[1].ItemKeeper.CountOfCollectedItemsByType);
        }
        else
        {
            playerResultDetails.SetResultsDetails(result[1].ItemKeeper.CountOfCollectedItemsByType);
            enemyResultDetails.SetResultsDetails(result[0].ItemKeeper.CountOfCollectedItemsByType);
        }
    }
}
