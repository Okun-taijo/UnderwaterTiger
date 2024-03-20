using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static VictoryManager;

public class VictoryManager : MonoBehaviour
{
    [System.Serializable]
    public class FishType
    {
        public string name;
        public int requiredCounter;
        public int caughtCounter;
        public Sprite fishSprite;
    }
  
    public FishType[] _fishTypes;
    [SerializeField] private GameObject _winPanel;
    private int _levels=0;
    private int _index;
    private void Start()
    {
        _index = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        CheckVictory();
    }
    public void CatchFish(string fishName)
    {
        for (int i = 0; i < _fishTypes.Length; i++)
        {
            if (_fishTypes[i].name == fishName && _fishTypes[i].caughtCounter < _fishTypes[i].requiredCounter)
            {
                _fishTypes[i].caughtCounter++;
                break;
            }
        }
    }
    private void CheckVictory()
    {
        bool isVictory = true;
        foreach (FishType fishType in _fishTypes)
        {
            if (fishType.caughtCounter < fishType.requiredCounter)
            {
                isVictory = false;
                break;
            }
        }
        if (isVictory)
        {
           
            HandleVictory();
        }
    }

    private void HandleVictory()
    {
        _levels++;
        _winPanel.SetActive(true);
        if (_levels < 1)
        {
            LevelAccesor.Instance.LevelProgress(_index);
        }
    }

}
