/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitDestroyer : MonoBehaviour
{

    public string tagFilter;
    /*Boundary set at the bottom of the game to destroy the fruits*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            Destroy(other.gameObject);

        }
    }
}
