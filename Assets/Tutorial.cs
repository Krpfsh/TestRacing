using UnityEngine;

public class Tutorial : MonoBehaviour
{
    
    private void Start()
    {
        if(PlayerPrefs.GetInt("OffTutorial") == 1)
        {
            Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
        else
        {
            Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
            Time.timeScale = 0f;
        }
    }
    
    public void ClickButtonStartGame()
    {
        Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void ClickButtonNeverAgain()
    {
        Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("OffTutorial", 1);
    }
}
