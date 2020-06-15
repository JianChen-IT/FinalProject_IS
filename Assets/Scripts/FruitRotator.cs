/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitRotator : MonoBehaviour
{
    public Vector3 speed; 


    /*Fruit and materials rotator*/
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
