using System;
using UnityEngine;
using static Dreamteck.Splines.ParticleController;

public class FinishPoint : MonoBehaviour
{
    public static event Action Crossed;
    public static event Action ExitPoint;
    private void OnTriggerEnter(Collider other)
    {
        Crossed?.Invoke();
        ExitPoint?.Invoke();
        Debug.Log("finish point enter");
    }
}
