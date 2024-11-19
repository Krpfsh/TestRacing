using System;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float BestLapTime;
    public static float LastLapTime;
    public static float CurrentLapTime;
    public static int CurrentLap;

    private float lapTimerTimestamp;

    public static event Action UIChanged;
    private bool _finished = false;
    private void Awake()
    {
        BestLapTime = PlayerPrefs.GetFloat("BestLap");
        if (BestLapTime == 0)
        {
            BestLapTime = Mathf.Infinity;
        }
    }
    private void OnEnable()
    {
        StartPoint.Crossed += StartLap;
        FinishPoint.Crossed += EndLap;
        HelperUtilities.RestartGame += ClearStats;
    }
    private void OnDisable()
    {
        StartPoint.Crossed -= StartLap;
        FinishPoint.Crossed -= EndLap;
        HelperUtilities.RestartGame -= ClearStats;
    }
    private void StartLap()
    {
        CurrentLap++;
        lapTimerTimestamp = Time.time; //7.75
        _finished = false;
    }
    void EndLap()
    {
        LastLapTime = Time.time - lapTimerTimestamp;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);

        if (PlayerPrefs.GetFloat("BestLap") < BestLapTime)
        {
            PlayerPrefs.SetFloat("BestLap", BestLapTime);
        }
        _finished = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!_finished)
        {
            CurrentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0; //10.75 - 7.75 = 3;
        }
        UIChanged?.Invoke();
    }
    private void ClearStats()
    {
        LastLapTime = 0;
        CurrentLapTime = 0;
        CurrentLap = 0;
    }
}
