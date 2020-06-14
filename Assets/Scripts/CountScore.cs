using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour
{
    public static int count=0;
    public Text countText;
    public bool mylock = false;
    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

    }
    void OnTriggerEnter(Collider body)
    {
        if (body.CompareTag("AtomicBomb") == false && body.CompareTag("Shoe") == false && body.CompareTag("Hammer") == false && body.CompareTag("SmallPotion") == false && body.CompareTag("MediumPotion") == false && body.CompareTag("BigPotion") == false && mylock==false)
            count = count + 1;
        SetCountText();
    }
    public void resetScore()
    {
        count = 0;
    }
}
