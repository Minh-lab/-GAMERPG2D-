using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioMannager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    public AudioClip backgrond;
    public AudioClip backgrond1;
    public AudioClip backgrond2;
    public AudioClip backgrond3;
    public AudioClip Kiemchem;
    public AudioClip CungBan;
    public AudioClip Coin;
    public AudioClip Heal;
    public AudioClip bantrung;
    public static audioMannager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && musicSource.clip != backgrond1)
        {
            musicSource.clip = backgrond1;
            musicSource.Play();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 && musicSource.clip != backgrond2)
        {
            musicSource.clip = backgrond2;
            musicSource.Play();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && musicSource.clip != backgrond3)
        {
            musicSource.clip = backgrond3;
            musicSource.Play();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0 && musicSource.clip != backgrond)
        {
            musicSource.clip = backgrond;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
