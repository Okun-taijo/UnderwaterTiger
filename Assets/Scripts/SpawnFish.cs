using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
   [System.Serializable]
   public class FishInfo
    {
        public GameObject _fishPrefab;
        public int _countOfFish;
    }

    [SerializeField] private FishInfo[] _fishTypes;
    [SerializeField] private Vector3 _spawnAreaMin;
    [SerializeField] private Vector3 _spawnAreaMax;

    private void Start()
    {
        FishSpawning();
    }

    void FishSpawning()
    {
        foreach(FishInfo info in _fishTypes)
        {
            for(int i=0;i<info._countOfFish; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Instantiate(info._fishPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(_spawnAreaMin.x, _spawnAreaMax.x);
        float randomY = Random.Range(_spawnAreaMin.y, _spawnAreaMax.y);
        float randomZ = Random.Range(_spawnAreaMin.z, _spawnAreaMax.z);
        return new Vector3(randomX, randomY, randomZ);
    }
}
