using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    public int runSpeed; // 1
   // private HealthBarHUDTester healthbar;

    void Start()
    {
        
    }
    /*
    public void setHealth(HealthBarHUDTester bar)
    {
        healthbar = bar;
    }
    void  HurtBasket(Collider body)
    {
        if (body.CompareTag("Basket")){
            if (gameObject.CompareTag("Bomb"))
            {
                float value = (float)1.5;
                healthbar.Hurt(value);
            }
            else if (gameObject.CompareTag("AtomicBomb"))
            {
                float value = (float)5;
                healthbar.Hurt(value);
            }
            else if (gameObject.CompareTag("Shoe"))
            {
                float value = (float)0.5;
                healthbar.Hurt(value);
            }
            else if (gameObject.CompareTag("Hammer"))
            {
                float value = (float)1;
                healthbar.Hurt(value);
            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward *  runSpeed * Time.deltaTime);
    }
}
