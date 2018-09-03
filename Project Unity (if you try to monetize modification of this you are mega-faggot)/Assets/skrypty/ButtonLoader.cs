using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoader : MonoBehaviour {

	public void rozpocznij()
    {
        SceneManager.LoadScene(3);
    }
    public void instrukcja()
    {
        SceneManager.LoadScene(1);
    }
    public void powrot()
    {
        SceneManager.LoadScene(0);
    }

    public void wylacz()
    {
        Application.Quit();
    }
    
}
