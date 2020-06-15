/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawn : MonoBehaviour
{
    public bool canSpawn = true;
    private float timeBetweenSpawns;
    public List<GameObject> materialList = new List<GameObject>();
    
    /*Selects and spawns a material*/
    private void SpawnMaterial()
    {
    
        float x = Random.Range(-100, 100);
        int selectMaterial = Random.Range(0, materialList.Count);
        GameObject material = Instantiate(materialList[selectMaterial]);
        material.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);

    }
    /*A material is spawned after a waiting time between 2 to  10 seconds*/
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnMaterial();
            yield return new WaitForSeconds(Random.Range(2, 10));
        }
    }
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

}
