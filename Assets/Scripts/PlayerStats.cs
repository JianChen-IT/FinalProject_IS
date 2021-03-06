﻿/*
 Interactive Systems Final Project
 Students: Jian Chen, Laia Auset & Aitor Rodriguez
 Date: May 15, 2020
 NOTE: most of the code is not written from us. We only added a coroutine, called in take damage
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
    public Animator transitionAnim;
    public Animator transitionMusic;
    public Animator bombMusic;

    #region Sigleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
        if (health <= 0)
        {
            StartCoroutine(LoadScene());
        }    
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }
    /*Coroutine triggered when the game is over. It includes some fade out animations for the
     visuals and the music. The score is also freezed to stop counting.*/
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        transitionMusic.SetTrigger("FadeOut");
        bombMusic.SetTrigger("FadeOut");
        CountScore countScore = GameObject.Find("Basket 1").GetComponent<CountScore>();
        countScore.mylock = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game Over");
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
}
