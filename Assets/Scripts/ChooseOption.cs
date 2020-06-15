/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOption : MonoBehaviour
{
	public static string bodyPart;
    /*Function that assigns the body part that the user wants to play*/
    public void SelectOption(){
    	string option = gameObject.tag;
    	switch (option)
        {
        case "Hips":
            bodyPart="Hip";
            break;
        case "Arms":
            bodyPart="Wrist";
            break;
        }
    }

}
