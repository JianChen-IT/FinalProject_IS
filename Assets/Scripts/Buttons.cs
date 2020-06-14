using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transitionAnim;
    public Animator transitionMusic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button(string name) {
    	StartCoroutine(LoadScene(name));
    }
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
