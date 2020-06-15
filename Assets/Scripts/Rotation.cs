/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 speed;

    /*Rotation for the potions*/
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
