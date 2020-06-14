using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialDestroyer : MonoBehaviour
{

    //public Text countText;
    //private int count;


    // Start is called before the first frame update
    public List<string> tagFilter;
    void Start()
    {
        //count = 0;
        //SetCountText ();

    }
    private void OnTriggerEnter(Collider other) // 1
    {
        for (int i=0; i<tagFilter.Count; i++ ) {
            if (other.CompareTag(tagFilter[i])) // 2
            {
                Destroy(other.gameObject); // 3
                //count = count + 1;
                //SetCountText ();
            }
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
