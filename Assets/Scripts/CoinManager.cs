using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager _instance; 
    public int _coins; 
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Image _coinImage;
    private const string CoinPrefsKey = "PlayerCoins";


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadCoins();
        _coinText.text = _coins.ToString();
    }
    private void LoadCoins()
    {
        _coins = PlayerPrefs.GetInt(CoinPrefsKey, 0);
    }

    // Метод для сохранения количества монет в PlayerPrefs
    private void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinPrefsKey, _coins);
        PlayerPrefs.Save();
    }

    public void AddCoins(int amount)
    {
        _coins += amount;
        SaveCoins();
        UpdateCoinDisplay(); 
    }
    public void SpendCoins(int amount)
    {
        _coins -= amount;
        SaveCoins();
        UpdateCoinDisplay();
    }

    public void UpdateCoinDisplay()
    {
        if (_coinImage != null)
        {
            _coinImage.gameObject.SetActive(true);
            _coinText.text = _coins.ToString();
        }
    }
}
