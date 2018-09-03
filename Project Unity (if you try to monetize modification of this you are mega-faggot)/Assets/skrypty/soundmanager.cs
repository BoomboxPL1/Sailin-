using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour {
    public static soundmanager instance = null;

    public AudioSource audioSource;
    public AudioClip[] muzyka;


    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);


    }




    void Start () {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = muzyka[Random.Range(0, muzyka.Length)];
        audioSource.Play();

		
	}
	
	
}
