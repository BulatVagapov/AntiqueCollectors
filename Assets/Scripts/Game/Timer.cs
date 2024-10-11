using System;
using System.Threading.Tasks;

public class Timer
{
    private int currentTime;
    private int maxTime;

    public event Action TimeIsOver;
    public event Action<int> TimeIsChanged;

    public bool timer;
    public bool PauseTimer;

    public void StopTimer()
    {
        timer = false;
    }

    public Timer(int time)
    {
        maxTime = time;
    }

    public void SetTimer(int timerTime)
    {
        maxTime = timerTime;
    }

    public void StartTimer()
    {
        currentTime = maxTime;
        timer = true;
        PauseTimer = false;
        ChangeCurrentTime();
    }


    private async Task ChangeCurrentTime()
    {
        TimeIsChanged?.Invoke(currentTime);

        while (timer)
        {
            await Task.Delay(1000);

            if (PauseTimer) continue;

            currentTime -= 1;

            TimeIsChanged?.Invoke(currentTime);

            if(currentTime <= 0)
            {
                TimeIsOver?.Invoke();
            }
        }

        return;
    }
}
