using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] private float _totalTime;
    private float _remainingTime;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameObject _losePanel;

    private void Start()
    {
        {
            _remainingTime = _totalTime;
        }
    }

    private void Update()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            UpdateTimeOnUI();
        }
        else
        {
            Time.timeScale = 0f;  
            _losePanel.SetActive(true);
           
        }
    }

    void UpdateTimeOnUI()
    {
        if (_remainingTime < 0)
        {
            _remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timerText.text = timeString;
    }
}
