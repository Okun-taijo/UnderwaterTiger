using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static VictoryManager;

public class FishManagerUI : MonoBehaviour
{
    [SerializeField] private Image[] _caughtFishImages;
    [SerializeField] private VictoryManager _victoryManager;
    [SerializeField] private TextMeshProUGUI[] _fishCountTexts;
    [SerializeField] private TextMeshProUGUI _netCountText;
    [SerializeField] private NetShoot _netCounter;

    


    void Update()
    {
        UpdateCaughtFish();
        UpdateNetCount();
    }

    private void UpdateCaughtFish()
    {
        for (int i = 0; i < _caughtFishImages.Length; i++)
        {
            if (i < _victoryManager._fishTypes.Length)
            {
                _caughtFishImages[i].sprite = _victoryManager._fishTypes[i].fishSprite;
                _caughtFishImages[i].gameObject.SetActive(true);
                _fishCountTexts[i].text = $"{_victoryManager._fishTypes[i].caughtCounter} / {_victoryManager._fishTypes[i].requiredCounter}";
            }
            else
            {
                _caughtFishImages[i].gameObject.SetActive(false);
                _fishCountTexts[i].text = "";
            }
        }
    }
    private void UpdateNetCount()
    {
        int netCount = _netCounter.GetNetCount();
        _netCountText.text = "Nets: " + netCount.ToString();
    }
}
