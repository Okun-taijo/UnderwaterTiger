using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishParametrs : MonoBehaviour
{
    public string fishName;
    public Sprite fishSprite;
    [SerializeField] private int _coins;

    public void CatchFish()
    {
        CoinManager._instance.AddCoins(_coins);
    }
}
