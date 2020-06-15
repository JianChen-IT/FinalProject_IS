/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject target;
    /*Script attached to the "Menu" Scene, to make the camera rotate around an object.*/    
    void Update()
    {
        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.right * Time.deltaTime);
    }

}
