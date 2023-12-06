using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Spawn()
    {
        Instantiate(bossPrefab, spawnPosition.position, spawnPosition.rotation);
    }

    private void Start()
    {
        Spawn();
    }
}
