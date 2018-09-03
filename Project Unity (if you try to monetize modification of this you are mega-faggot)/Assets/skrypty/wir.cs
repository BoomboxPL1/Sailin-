using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wir : MonoBehaviour {

    public int szanse = 1;
    public AreaEffector2D ae2D;
    private bool wplyw = false;



	// Use this for initialization
	void Start () {
        ae2D = GetComponent<AreaEffector2D>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            wplyw = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wplyw = false;
        }
    }



    // Update is called once per frame
    void Update () {


        if (wplyw == false)
        {

            int zmiana = Random.Range(0, szanse);
            if (zmiana == 0)
            {
                int rodzaj = Random.Range(0, 2);
                
                if (rodzaj == 1)
                {
                    ae2D.forceAngle = -25;
                    return;
                }
                if (rodzaj == 0)
                {
                    ae2D.forceAngle = 225;
                    return;
                }
            }

        }
	}
}
