using System;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CheckpointManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterCheckpointNumber;
    private void OnEnable()
    {
        CheckpointsManager.CheckpointCounterChanged += CheckpointChangeText;
    }

    

    private void OnDisable()
    {
        CheckpointsManager.CheckpointCounterChanged -= CheckpointChangeText;
    }
    private void Start()
    {
        CheckpointChangeText();
    }
    private void CheckpointChangeText(int counter)
    {
        counterCheckpointNumber.text = counter.ToString() + "/" + CheckpointsManager.checkpointsAmount;
    }
    private void CheckpointChangeText()
    {
        counterCheckpointNumber.text = 0 + "/" + CheckpointsManager.checkpointsAmount;
    }
}
