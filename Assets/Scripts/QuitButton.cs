/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    /*Button to quit the game*/
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
