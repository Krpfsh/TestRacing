using System;
using UnityEngine;

public class StartFinishManager : MonoBehaviour
{
    [SerializeField] private GameObject _startPoint, _finishPoint;

    public static event Action<bool> Crossed;

    private bool _running;

    private void Awake()
    {
        _startPoint.SetActive(true);
        _finishPoint.SetActive(false);
    }

    private void OnEnable()
    {
        CheckpointsManager.OnGoalTriggered += GoalOnOnGoalTriggered;
        StartPoint.Crossed += StartFinishPointReached;
        FinishPoint.ExitPoint += StartPointExit;
        FinishPoint.Crossed += StartFinishPointReached;
    }
    private void OnDisable()
    {
        CheckpointsManager.OnGoalTriggered -= GoalOnOnGoalTriggered;
        StartPoint.Crossed -= StartFinishPointReached;
        FinishPoint.ExitPoint -= StartPointExit;
        FinishPoint.Crossed -= StartFinishPointReached;
    }

    private void GoalOnOnGoalTriggered()
    {
        _finishPoint.SetActive(true);
    }

    private void StartFinishPointReached() {
        if (_running && !_finishPoint.activeSelf) return;

        _running = !_running;
        _startPoint.SetActive(false);
        _finishPoint.SetActive(false);
        Crossed?.Invoke(_running);
    }

    private void StartPointExit() { 
        _startPoint.SetActive(!_running);
    }
}
