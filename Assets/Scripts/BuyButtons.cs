using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuyButtons: MonoBehaviour
{
    [SerializeField] private NetShoot _netShoot;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private int _netPraise;
    [SerializeField] private int _arrowPraise;
    [SerializeField] private TextMeshProUGUI _notEnoughCoins;
    [SerializeField] private ArrowBehaviour _arrowBehaviour;

    public void BuyNet()
    {
        if (_netPraise <= _coinManager._coins)
        {
            _netShoot._availableNets++;
            _coinManager.SpendCoins(_netPraise);
        }
        else
        {
            _notEnoughCoins.text = "NOT ENOUGH COINS!";
            StartCoroutine(FadeInOutText());
        }
    }
    public void BuyArrow()
    {
        if (_arrowPraise <= _coinManager._coins)
        {
            _arrowBehaviour.CreateArrow();
            _arrowBehaviour.PlaceArrow();
            _coinManager.SpendCoins(_arrowPraise);
        }
        else
        {
            _notEnoughCoins.text = "NOT ENOUGH COINS!";
            StartCoroutine(FadeInOutText());
        }
    }
    private IEnumerator FadeInOutText()
    {
        _notEnoughCoins.gameObject.SetActive(true);
        _notEnoughCoins.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(3f);
        _notEnoughCoins.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        _notEnoughCoins.gameObject.SetActive(false);
    }
}
