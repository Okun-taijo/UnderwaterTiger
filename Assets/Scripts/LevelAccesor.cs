using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAccesor : MonoBehaviour
{
    private static LevelAccesor _instance;
    public static LevelAccesor Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject("LevelAccesor");
                _instance = singletonObject.AddComponent<LevelAccesor>();
            }
            return _instance;
        }
    }

    public Button[] _buttons;
    private int _passedLevels;

    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _passedLevels = PlayerPrefs.GetInt("CurrentLevelProgress", _passedLevels);
        UpdateButtonInteractivity();
    }

    public void LevelProgress(int index)
    {
        if(_passedLevels <index) 
        {
            _passedLevels = index;
        }
        else
        {

        }
        PlayerPrefs.SetInt("CurrentLevelProgress", _passedLevels);
        UpdateButtonInteractivity();
    }

    private void UpdateButtonInteractivity()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i] != null)
            {
                _buttons[i].interactable = (i < _passedLevels);
            }
        }
    }

}
