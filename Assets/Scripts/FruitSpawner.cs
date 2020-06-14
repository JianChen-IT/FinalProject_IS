using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canSpawn = true; // 1
    //public GameObject sheepPrefab; // 2
    //public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns; // 4
    public List<GameObject> fruitList = new List<GameObject>(); // 5
   
    private void SpawnFruit()
    {
        float x = Random.Range(-100, 100);
        int selectFruit = Random.Range(0, fruitList.Count);
        //Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; // 1
        GameObject fruit = Instantiate(fruitList[selectFruit]); // 2
        fruit.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
        //sheepList.Add(sheep); // 3
        //sheep.GetComponent<Sheep>().SetSpawner(this); // 4
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnFruit();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}