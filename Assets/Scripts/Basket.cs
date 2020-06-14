using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Basket : MonoBehaviour
{
    //public string fruitTag;
    public List<string> materialTags; 
    public float gotBasketDestroyDelay; // 2
    private HealthBarController healthbar;
    public AudioSource bomb;
    public AudioSource atomicBomb;
    public AudioSource smallHeal;
    public AudioSource mediumHeal;
    public AudioSource bigHeal;
    //public Camera camera;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.transform.FindChild("Explosion Variant").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("BigExplosion Variant").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green small").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green medium").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green big").GetComponent<ParticleSystem>().Stop();
    }
    public void SetHeart(HealthBarController bar)
    {
        healthbar = bar;
    }
    void OnTriggerEnter(Collider body)
    {
        if (body.CompareTag("Bomb"))
        {
            PlayerStats.Instance.TakeDamage((float)1.5);
            bomb.Play();
            gameObject.transform.FindChild("Explosion Variant").GetComponent<ParticleSystem>().Play();
            body.GetComponent<TraumaInducer>().enabled = true;
            Invoke("Stop", 1);

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

        for (int i = 0; i < materialTags.Count; i++)
        {
            if (body.CompareTag(materialTags[i]) && body.CompareTag("Bomb")==false)
            {
                Destroy(body.gameObject);

            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Stop()
    {
        gameObject.transform.FindChild("Explosion Variant").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green small").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green medium").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("Magic fire pro green big").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.FindChild("BigExplosion Variant").GetComponent<ParticleSystem>().Stop();
        //GameObject.Find("Main Camera").GetComponent<TraumaInducer>().enabled = false;
        //GameObject.Find("Main Camera").GetComponent<StressReceiver>().enabled = false;
    }



}
