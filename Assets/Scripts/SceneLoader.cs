using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;
    private int _index;
    private void Start()
    {
        _index = SceneManager.GetActiveScene().buildIndex;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToMenuFromWin()
    {
        Time.timeScale = 1f;
        LevelAccesor.Instance.LevelProgress(_index);
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToNextLevel()
    {
        Time.timeScale = 1f;
        LevelAccesor.Instance.LevelProgress(_index);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void GoToNumberScene()
    {

        if (_sceneNumber < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_sceneNumber);
        }
        else
        {

        }
    }
}

