using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boardmanager : MonoBehaviour {

    public GameObject GameManager;
    public GameObject[] jungle;
    public GameObject[] brzegprawy;
    public GameObject[] brzeglewy;
    public GameObject[] dzunglaprawa;
    public GameObject[] dzunglalewa;

	// Use this for initialization
	void Awake () {
        if (Gamemanager.instance == null)
        {
            Instantiate(GameManager);
        }

        for (int x = -6; x< 12; x++)
        {


            for (int y = 0; y< 40; y++)
            {
                float angle = Random.RandomRange(0, 180);
                Instantiate(jungle[Random.Range(0,jungle.Length)], new Vector3(x, y, 0), Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)));
            }

        }

        for (int y= 10; y<=37; y++)
        {
            int x = 5;
            if (y != 26)
            {
                x = 5;

                Instantiate(brzegprawy[Random.Range(0, brzegprawy.Length)], new Vector3(x, y, 0), Quaternion.identity);

                x = 6;

                Instantiate(dzunglaprawa[Random.Range(0, dzunglaprawa.Length)], new Vector3(x, y, 0), Quaternion.identity);
            }

           if (y == 26)
                {
                    x = 6;
                    Instantiate(dzunglaprawa[0], new Vector3(x, y, 0), Quaternion.identity);
                }
            

        }

        for (int y= 10;y<=37;y++)
        {
            int x = 0;
            if (y != 26)
            {
                Instantiate(brzeglewy[Random.Range(0, brzeglewy.Length)], new Vector3(x, y, 0), Quaternion.identity);

                x = -1;

                Instantiate(dzunglalewa[Random.Range(0, dzunglalewa.Length)], new Vector3(x, y, 0), Quaternion.identity);
            }
            if (y == 26)
            {
                x = -1;
                Instantiate(dzunglalewa[0], new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        


	}
	

}
