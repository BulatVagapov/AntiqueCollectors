using System;
using System.Threading.Tasks;
using UnityEngine;

public class LoadingScreen : SingletonBase<LoadingScreen>
{
    [SerializeField] private int loadingTime;
    [SerializeField] private LoadingCircle loadingCircle;
    [SerializeField] private GameObject mainScreen;

    public event Action LoadingIsOver;

    private void Start()
    {
        Loading();
    }

    private async Task Loading()
    {
        loadingCircle.StartChangeCircles();


        while (loadingTime > 0)
        {
            await Task.Delay(loadingTime * 1000);

            loadingTime--;
        }

        loadingCircle.StopChangeCicles();
        LoadingIsOver?.Invoke();
        mainScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
