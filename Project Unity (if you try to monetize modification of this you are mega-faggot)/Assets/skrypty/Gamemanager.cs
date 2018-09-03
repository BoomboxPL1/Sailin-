using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour {

    public static Gamemanager instance = null;


    public int zywotnosc = 100;
    public int jedzenie = 100;


    public void restart()
    {
        SceneManager.LoadScene(2);
    }


    void Awake () {
        if (instance==null)
        {
            instance = this;
        }
        if (instance!=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
