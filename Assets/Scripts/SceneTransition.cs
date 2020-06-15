/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public Animator transitionMusic;
    public string sceneName;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        StartCoroutine(LoadScene());    
    }
    /*Coroutine to do the transition between scenes*/
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        transitionMusic.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
