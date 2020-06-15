/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialDestroyer : MonoBehaviour
{
    /*Assigned to a gameobject to destroy the materials*/
    public List<string> tagFilter;

    private void OnTriggerEnter(Collider other)
    {
        for (int i=0; i<tagFilter.Count; i++ ) {
            if (other.CompareTag(tagFilter[i]))
            {
                Destroy(other.gameObject);

            }
        }
    }

}
