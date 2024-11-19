using System;
using TMPro;
using UnityEngine;

public class TimeManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UITextCurrentLap;
    [SerializeField] private TextMeshProUGUI UITextCurrentTime;
    [SerializeField] private TextMeshProUGUI UITextLastLapTime;
    [SerializeField] private TextMeshProUGUI UITextBestLapTime;
    private void OnEnable()
    {
        TimeManager.UIChanged += UpdateUIText;
    }
    private void OnDisable()
    {
        TimeManager.UIChanged -= UpdateUIText;
    }
    private void UpdateUIText()
    {
        UITextCurrentLap.text = $"Круг: {TimeManager.CurrentLap}";

        UITextCurrentTime.text = $"Время: {(int)TimeManager.CurrentLapTime / 60}:{Math.Floor((TimeManager.CurrentLapTime % 60) * 100) / 1000:00.00}".Replace(',', '.');
        
        UITextLastLapTime.text = $"Последнее время круга: {(int)TimeManager.LastLapTime / 60}:{Math.Floor((TimeManager.LastLapTime % 60) * 100) / 1000:00.00}".Replace(',', '.');
        
        UITextBestLapTime.text = TimeManager.BestLapTime < 1000000 ? $"Лучшее время круга: {(int)TimeManager.BestLapTime / 60}:{Math.Floor((TimeManager.BestLapTime % 60) * 100) / 1000:00.00}".Replace(',', '.') : "Лучшее время круга: 0:00.00";
    }
}
