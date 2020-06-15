/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public float timeBetweenSpawns;
    public List<GameObject> fruitList = new List<GameObject>();
   /*Function in charge of selecting a random fruit and spawning it*/
    private void SpawnFruit()
    {
        float x = Random.Range(-100, 100);
        int selectFruit = Random.Range(0, fruitList.Count);
        GameObject fruit = Instantiate(fruitList[selectFruit]);
        fruit.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    /*Coroutine that is activated after a given time*/
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnFruit();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

}