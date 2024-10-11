using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button policyButton;
    [SerializeField] private Button backButton;
    private Image musicButtonImage;
    private Image soundButtonImage;

    [SerializeField] private Sprite musicSoundOnSprite;
    [SerializeField] private Sprite musicSoundOffSprite;

    [SerializeField] private GameObject policyScreen;
    [SerializeField] private GameObject mainScreen;

    private void Start()
    {
        musicButtonImage = musicButton.GetComponent<Image>();
        soundButtonImage = soundButton.GetComponent<Image>();

        SetMusicAndSoundButtonView(musicButtonImage, AudioManager.Instance.MusicPref);
        SetMusicAndSoundButtonView(soundButtonImage, AudioManager.Instance.SoundsPref);

        musicButton.onClick.AddListener(OnMusicButtonClick);
        soundButton.onClick.AddListener(OnSoundButtonClick);
        policyButton.onClick.AddListener(OnPolicyButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);

        gameObject.SetActive(false);
    }

    private void SetMusicAndSoundButtonView(Image buttonImage, int state)
    {
        if (state == 0)
        {
            buttonImage.sprite = musicSoundOnSprite;
        }
        else
        {
            buttonImage.sprite = musicSoundOffSprite;
        }
    }

    private void OnMusicButtonClick()
    {
        if (AudioManager.Instance.MusicPref == 1)
        {
            AudioManager.Instance.TurnOnMusic();

        }
        else
        {
            AudioManager.Instance.TurnOffVolumeForGroup("MusicVolume");
        }

        AudioManager.Instance.ChangeMusicPrefs();

        SetMusicAndSoundButtonView(musicButtonImage, AudioManager.Instance.MusicPref);
    }

    private void OnSoundButtonClick()
    {
        if (AudioManager.Instance.SoundsPref == 1)
        {
            AudioManager.Instance.TurnOnSounds();

        }
        else
        {
            AudioManager.Instance.TurnOffVolumeForGroup("SoundsVolume");
        }

        AudioManager.Instance.ChangeSoundsPrefs();

        SetMusicAndSoundButtonView(soundButtonImage, AudioManager.Instance.SoundsPref);
    }

    private void OnPolicyButtonClick()
    {
        gameObject.SetActive(false);
        policyScreen.SetActive(true);
    }

    private void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        mainScreen.SetActive(true);
    }
}
