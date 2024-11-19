using System;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public static event Action Crossed;
    private void OnTriggerEnter(Collider other)
    {
        Crossed?.Invoke();
        if (other.tag == "Player")
        {
            Debug.Log("Playertrig");
        }
    }
}
