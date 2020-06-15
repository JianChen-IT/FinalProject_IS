/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Basket : MonoBehaviour
{

    public List<string> materialTags; 
    public float gotBasketDestroyDelay; // 2
    private HealthBarController healthbar;
    /*Audio that are activated when the respective object impacts in the basket*/
    public AudioSource bomb;
    public AudioSource atomicBomb;
    public AudioSource smallHeal;
    public AudioSource mediumHeal;
    public AudioSource bigHeal;

    void Start()
    {
        /*Making sure the Particle systems are not on*/
        gameObject.transform.FindChild("Explosion Variant").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("BigExplosion Variant").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green small").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green medium").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green big").GetComponent<ParticleSystem>().Stop();
    }
    /*Health bar setter*/
    public void SetHeart(HealthBarController bar)
    {
        healthbar = bar;
    }
    /*Core function that interacts with some of the differente objects, when they collide with the basket*/
    void OnTriggerEnter(Collider body)
    {
        if (body.CompareTag("Bomb"))
        {
            PlayerStats.Instance.TakeDamage((float)1.5);                                                //Remove health
            bomb.Play();                                                                                //Play the bomb sound
            gameObject.transform.FindChild("Explosion Variant").GetComponent<ParticleSystem>().Play();  //Trigger the bomb particles
            body.GetComponent<TraumaInducer>().enabled = true;                                          //Make the camera shake
            Invoke("Stop", 1);                                                                          //After 1 second stop the particles

        }
        else if (body.CompareTag("AtomicBomb"))
        {
            atomicBomb.Play();
            gameObject.transform.FindChild("BigExplosion Variant").GetComponent<ParticleSystem>().Play();
            PlayerStats.Instance.TakeDamage((float)5);
            Invoke("Stop", 1);
        }
        else if (body.CompareTag("Shoe"))
        {
            PlayerStats.Instance.TakeDamage((float)0.5);
        }
        else if (body.CompareTag("Hammer"))
        {
            PlayerStats.Instance.TakeDamage((float)1);
        }
        else if (body.CompareTag("SmallPotion"))
        {
            PlayerStats.Instance.Heal((float)1);
            smallHeal.Play();
            gameObject.transform.FindChild("Magic fire pro green small").GetComponent<ParticleSystem>().Play();
            Invoke("Stop", 1);
        }
        else if (body.CompareTag("MediumPotion"))
        {
            PlayerStats.Instance.Heal((float)2);
            mediumHeal.Play();
            gameObject.transform.FindChild("Magic fire pro green medium").GetComponent<ParticleSystem>().Play();
            Invoke("Stop", 1);
        }
        else if (body.CompareTag("BigPotion"))
        {
            PlayerStats.Instance.Heal((float)3);
            bigHeal.Play();
            gameObject.transform.FindChild("Magic fire pro green big").GetComponent<ParticleSystem>().Play();
            Invoke("Stop", 1);
        }
        /*For loop to destroy all the objects.*/
        for (int i = 0; i < materialTags.Count; i++)
        {
            /*Making sure that the object is within the list of destroyable objects. The bomb is excluded, because
             it is destroyed in the TraumaInducer Script, which is located in External Assets--> CameraShakeFX --> Scripts */
            if (body.CompareTag(materialTags[i]) && body.CompareTag("Bomb")==false)
            {
                Destroy(body.gameObject);

            }
        }
        
    }
    /*Function that stops all the particle animations*/
    void Stop()
    {
        gameObject.transform.FindChild("Explosion Variant").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green small").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green medium").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green big").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("BigExplosion Variant").GetComponent<ParticleSystem>().Stop();
    }



}
