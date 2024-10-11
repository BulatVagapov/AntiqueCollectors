using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private void Start()
    {
        GameManager.Instance.Timer.TimeIsChanged += SetTimerText;
        GameManager.Instance.GameCycleStartEvent += () => gameObject.SetActive(true);
        GameManager.Instance.GameCycleEndEvent += () => gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    private void SetTimerText(int timeInSeconds)
    {
        timerText.text = (timeInSeconds / 60) + ":" + ((timeInSeconds % 60) < 10 ? "0" + (timeInSeconds % 60) : (timeInSeconds % 60));
    }
}
