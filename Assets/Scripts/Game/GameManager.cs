using System;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    private Timer timer;
    [SerializeField] private int gameCycleTime;

    public event Action GameCycleStartEvent;
    public event Action GameCycleEndEvent;

    public Timer Timer => timer;

    protected override void Awake()
    {
        base.Awake();
        timer = new Timer(gameCycleTime);
        timer.TimeIsOver += OnGameCycleEnd;
    }

    public void OnGameCycleStart()
    {
        timer.StartTimer();
        GameCycleStartEvent?.Invoke();
    }

    private void OnGameCycleEnd()
    {
        timer.StopTimer();
        GameCycleEndEvent?.Invoke();
    }

    private void OnApplicationQuit()
    {
        timer.StopTimer();
    }
}
