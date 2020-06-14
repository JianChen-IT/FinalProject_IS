using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitDestroyer : MonoBehaviour
{

	//public Text countText;
    //private int count;


    // Start is called before the first frame update
    public string tagFilter;
    void Start()
    {
    	//count = 0;
        //SetCountText ();
        
    }
    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag(tagFilter)) // 2
        {
            Destroy(other.gameObject); // 3
            //count = count + 1;
            //SetCountText ();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /*void SetCountText ()
    {
        countText.text = "Frutas Perdidas: " + count.ToString ();
       
    }
    */
}
