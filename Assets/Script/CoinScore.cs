using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    [SerializeField] private Text _coinCounter;

     private PlayerBag _playerBag;

    public void SetCoinScore(int value) 
    {       
        _coinCounter.text = value.ToString();
    }

    private void OnEnable()
    {
        if (_playerBag == null)
        {
            _playerBag = FindObjectOfType<PlayerBag>();
        }

        _playerBag.AddListener(SetCoinScore);               
    }

    private void OnDisable()
    {
        _playerBag.RemoveListener(SetCoinScore);
    }
}
