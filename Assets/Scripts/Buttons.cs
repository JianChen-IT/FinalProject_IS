/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Buttons : MonoBehaviour
{

    public Animator transitionAnim;
    public Animator transitionMusic;


    public void button(string name) {
    	StartCoroutine(LoadScene(name));
    }
    /*FadeOut animation for transitioning to other scenes*/
    IEnumerator LoadScene(string name)
    {
        transitionAnim.SetTrigger("end");
        transitionMusic.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
    }

    public void exit() {
        Application.Quit();
     }


}
