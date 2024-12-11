using DG.Tweening;
using System.Linq;
using TarodevGhost;
using UnityEngine;

public class GhostRunner : MonoBehaviour {
    [SerializeField] private Transform _recordTarget;
    [SerializeField] private GameObject _ghostPrefab;
    [SerializeField] private Material mat1, mat2;
    [SerializeField, Range(1, 10)] private int _captureEveryNFrames = 2;

    private ReplaySystem _system;

    private void Awake() => _system = new ReplaySystem(this);
    
    private void OnEnable() => StartFinishManager.Crossed += OnFinishLineCrossed;
    private void OnDisable() => StartFinishManager.Crossed -= OnFinishLineCrossed;
    
    private void OnFinishLineCrossed(bool runStarting) {
        if (runStarting) {
            _system.StartRun(_recordTarget, _captureEveryNFrames);
            GameObject ghostCar = Instantiate(_ghostPrefab);

            ghostCar.GetComponentsInChildren<MeshRenderer>().ElementAt(0).material = mat1;
            ghostCar.GetComponentsInChildren<MeshRenderer>().ElementAt(1).material = mat2;
            ghostCar.transform.Find("Spoiler").gameObject.GetComponent<MeshRenderer>().material = mat1;
            _system.PlayRecording(RecordingType.Best, ghostCar);
        }
        else {
            _system.FinishRun();
            _system.StopReplay();
        }
    }
}

