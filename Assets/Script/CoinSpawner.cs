using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private Transform[] _spawnPoints;

    private int _randomPoint;
    private int _spawnerCoinsCount = 20;
    
    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }
    private IEnumerator SpawnCoin()
    {
        while (_spawnerCoinsCount > 0)
        {
            _randomPoint = Random.Range(0, _spawnPoints.Length);
            var newCoin = Instantiate(_template, _spawnPoints[_randomPoint].position, Quaternion.identity);
            _spawnerCoinsCount--;

            while(newCoin != null)
                yield return null;                    
        }
    }
}
