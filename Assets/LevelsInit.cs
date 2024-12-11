using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsInit : MonoBehaviour
{
    [SerializeField] private LevelSO[] _levelsSO;
    [SerializeField] private GameObject _levelPrefab;
    private void Awake()
    {
        InitLevels();
    }
    private void InitLevels()
    {
        for (int i = 0; i < _levelsSO.Length; i++)
        {
            Debug.Log(i);
            GameObject level = Instantiate(_levelPrefab, new Vector2(0, 0), Quaternion.identity, gameObject.transform);

            level.transform.GetChild(0).GetComponent<Image>().sprite = _levelsSO[i].levelPreview;
            //button
            level.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
            int index = i;
            level.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => LoadSceneWithIndex(index));


            level.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _levelsSO[i].levelName;

            // другая правая переменная для того, чтобы изменять рекорд сохранённый
            level.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = 0f.ToString();
        }
    }
    private void LoadSceneWithIndex(int number)
    {
        SceneManager.LoadScene("Level " +(number+1));
    }
}
