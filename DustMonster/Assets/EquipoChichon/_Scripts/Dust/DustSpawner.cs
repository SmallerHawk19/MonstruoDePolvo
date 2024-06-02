using System.Collections.Generic;
using UnityEngine;

public class DustSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnInterval = 30f;

    [SerializeField] private List<GameObject> _dustPrefabs;
    [SerializeField] private bool _boosterSpawner = false;

    private float _timeSinceLastSpawn;
    private bool _isSpawning = false;

    private void Start()
    {
        _spawnPoint.gameObject.GetComponent<MeshRenderer>().enabled = false;
        SpawnDust();
    }

    private void Update()
    {
        if (_isSpawning)
        {
            _timeSinceLastSpawn += Time.deltaTime;
            if (_timeSinceLastSpawn >= _spawnInterval)
            {
                SpawnDust();
            }
        }
    }

    public void DustCollected()
    {
        _timeSinceLastSpawn = 0;
        _isSpawning = true;
    }

    private void SpawnDust()
    {
        GameObject prefabToSpawn = GetRandomDust();
        GameObject dust = Instantiate(prefabToSpawn, _spawnPoint.position, prefabToSpawn.transform.rotation);
        dust.transform.parent = _spawnPoint;

        if (_boosterSpawner)
        {
            dust.GetComponentInChildren<Collectible>().DustSpawner = this;
        } else
        {
            dust.GetComponentInChildren<KatamariCollectibles>().DustSpawner = this;
        }

        _isSpawning = false;
    }

    private GameObject GetRandomDust()
    {
        return _dustPrefabs[Random.Range(0, _dustPrefabs.Count)];
    }

}
