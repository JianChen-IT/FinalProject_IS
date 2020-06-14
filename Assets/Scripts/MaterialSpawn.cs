using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canSpawn = true; // 1
    //public GameObject sheepPrefab; // 2
    //public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3
    private float timeBetweenSpawns; // 4
    public List<GameObject> materialList = new List<GameObject>(); // 5
    

    private void SpawnMaterial()
    {
    
        float x = Random.Range(-100, 100);
        int selectMaterial = Random.Range(0, materialList.Count);
        //Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; // 1
        GameObject material = Instantiate(materialList[selectMaterial]); // 2
        material.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
        
        //sheepList.Add(sheep); // 3
        //sheep.GetComponent<Sheep>().SetSpawner(this); // 4
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnMaterial();
            yield return new WaitForSeconds(Random.Range(2, 10));
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
