using System;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _checkpointsCollider;
    private int _checkpointCounter;
    public static event Action<int> CheckpointCounterChanged;
    public static int checkpointsAmount;
    public static event Action OnGoalTriggered;

    private void Awake()
    {
        checkpointsAmount = _checkpointsCollider.Length;
    }
    private void OnEnable()
    {
        Checkpoint.OnCheckpointTriggered += CheckpointReached;
        FinishPoint.Crossed += CheckpointReset;
    }
    private void OnDisable()
    {
        Checkpoint.OnCheckpointTriggered -= CheckpointReached;
        FinishPoint.Crossed -= CheckpointReset;
    }
    private void CheckpointReached()
    {
        _checkpointCounter++;
        CheckpointSwitcher();
        CheckpointCounterChanged?.Invoke(_checkpointCounter);
        if(_checkpointCounter == _checkpointsCollider.Length)
        {
            OnGoalTriggered?.Invoke();
        }
    }
    private void CheckpointReset()
    {
        _checkpointCounter = 0;
        _checkpointsCollider[0].GetComponent<BoxCollider>().enabled = true;
        CheckpointCounterChanged?.Invoke(_checkpointCounter);
    }
    private void CheckpointSwitcher()
    {
        for (int i = 0; i < _checkpointsCollider.Length; i++)
        {
            if (i == _checkpointCounter)
            {
                _checkpointsCollider[i].GetComponent<BoxCollider>().enabled = true;
                continue;
            }
            _checkpointsCollider[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
}
