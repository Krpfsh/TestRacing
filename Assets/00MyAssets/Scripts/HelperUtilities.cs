using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelperUtilities : MonoBehaviour
{
    [SerializeField] private string _gameSceneName;
    public static event Action RestartGame;
    void Update()
    {
        if (SceneManager.GetActiveScene().name == _gameSceneName)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartParameters();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                PlayerPrefs.DeleteKey("BestLap");
                RestartParameters();
            }
        }
    }
    private void RestartParameters()
    {
        RestartGame?.Invoke();
        SceneManager.LoadScene(_gameSceneName);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
