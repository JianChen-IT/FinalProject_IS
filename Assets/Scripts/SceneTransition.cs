using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public Animator transitionMusic;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        StartCoroutine(LoadScene());
        
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        transitionMusic.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
