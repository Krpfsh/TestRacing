using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static event Action OnCheckpointTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnCheckpointTriggered?.Invoke();
        }
    }
}
