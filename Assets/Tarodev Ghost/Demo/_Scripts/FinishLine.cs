using System;
using UnityEngine;

public class FinishLine : MonoBehaviour {
    [SerializeField] private GameObject _startVisual, _finishedVisual;

    public static event Action<bool> Crossed;

    private bool _running;

    private void Awake() {
        _startVisual.SetActive(true);
        _finishedVisual.SetActive(false);
    }

    private void OnEnable() => Goal.OnGoalTriggered += GoalOnOnGoalTriggered;
    private void OnDisable() => Goal.OnGoalTriggered -= GoalOnOnGoalTriggered;

    private void GoalOnOnGoalTriggered() {
        _finishedVisual.SetActive(true);
        Debug.Log("test");
    }

    private void OnTriggerEnter(Collider col) {
        if (_running && !_finishedVisual.activeSelf) return;
      
        _running = !_running;
        _startVisual.SetActive(false);
        _finishedVisual.SetActive(false);
        Crossed?.Invoke(_running);
    }

    private void OnTriggerExit(Collider col) {
        _startVisual.SetActive(!_running);
    }
}