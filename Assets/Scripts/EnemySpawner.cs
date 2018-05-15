using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn = null;
    public Vector2 spawnDelayMinMax = new Vector2(0.5f, 2.0f);
    public int maxAmountOfEntitys = 10;
    public bool isInfinite = false;

    private int entityCounter;

    private void Start()
    {
        entityCounter = maxAmountOfEntitys;
        StartCoroutine("SpawnEntity");
    }

    private IEnumerator SpawnEntity()
    {
        while ((maxAmountOfEntitys < entityCounter) || isInfinite)
        {
            GameObject newEntity = GameObject.Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)], transform.position, Quaternion.identity);
            newEntity.GetComponent<EnemyController>().target = GameObject.FindObjectOfType<PlayerController>().transform;

            entityCounter--;
            yield return new WaitForSeconds(Random.Range(spawnDelayMinMax.x, spawnDelayMinMax.y));
        }

    }

    private void Update()
    {
        
    }

}
