using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerBag>(out var playerBag))
        {
            playerBag.AddCoin();          
            Destroy(gameObject);
        }
    }
}
