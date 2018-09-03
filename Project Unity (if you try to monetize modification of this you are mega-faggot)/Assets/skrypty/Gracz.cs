using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Gracz : MonoBehaviour {

    public Camera camera;
    public BoxCollider2D bc2D;
    public Rigidbody2D rb2D;
    public ConstantForce2D force;
    public float moveTime = 0.3f;
    public float wzmocnienie = 1f;
    public float silawody = 30;
    public Text jedzenietext;
    public Text wytrzymalosctext;
    public float Time = 3f;


    private int zywnosc;
    private int wytrzymałość;


    private Vector2 przyspieszenie;
    private Vector2 skret;
    
    private Vector2 stop;
    public int kotwica=10;


	// Use this for initialization
	void Start () {
        force = GetComponent<ConstantForce2D>();
        rb2D = GetComponent<Rigidbody2D>();

        camera = FindObjectOfType<Camera>();

        stop = new Vector2(0, 0);
        przyspieszenie = new Vector2(0,20f);

        zywnosc= Gamemanager.instance.jedzenie;
        wytrzymałość = Gamemanager.instance.zywotnosc;




    }
    private void restart()
    {
        Gamemanager.instance.restart();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Meta")
        {
            kotwica = 30;
            Invoke("restart", 1f);

        }

        if (collision.tag == "Przeszkoda")
        {


            wytrzymałość -= 10;
    

        }
        if (collision.tag == "jedzenie")
        {

            collision.gameObject.SetActive(false);
            zywnosc += 20;
        }


        /*
        if (collision.tag == "Water")
        {
            force.relativeForce = new Vector2(0, silawody);
        }
        if (collision.tag == "Water2")
        {
            force.relativeForce = new Vector2(0, 3 * silawody);
        }
        */
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
       if( collision.tag == "Wir")
        {
            kotwica = 0;
        }
       
       else if(collision.tag== "Water")
        {
            
            force.relativeForce = new Vector2(0, silawody);
            

        }

        else if (collision.tag== "Water2")
        {
            force.relativeForce = new Vector2(0, 3 * silawody);
        }
        




    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wir")
        {
            kotwica = 3;
        }
        /*
        if (collision.tag == "Water2")
        {
            force.relativeForce = new Vector2(0, silawody);
        }
        if (collision.tag == "Water")
        {
            force.relativeForce = new Vector2(0, 2*silawody);
        }
        */
    }



    void Update()
    {

        jedzenietext.text = "Jedzenie: "+zywnosc;
        wytrzymalosctext.text = "Kadlub: " + wytrzymałość;
        
    }

    // Update is called once per frame
    void FixedUpdate () {

        

        //Sterowanie kalwiaturą
        Vector3 pozycja = transform.position;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (kotwica != 0)
            {
                rb2D.drag = kotwica-14;
            }
            force.force = przyspieszenie;
            
          
        }
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            force.force = stop;
            rb2D.drag = kotwica;
            
        }

        camera.transform.position = transform.position - new Vector3 (2.5f,-2.5f,10f);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            StartCoroutine(Rotating(Input.GetAxisRaw("Horizontal")));
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            StartCoroutine(Rotating(Input.GetAxisRaw("Horizontal")));
            
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            StartCoroutine(Rotating(0));
        }


        //przekład sterowania
        float obrot = transform.rotation.z;
        skret = new Vector2(wzmocnienie * obrot,0);
        force.force = skret;


        
       
    }



    // obsługa obrotu
    IEnumerator Rotating(float axis)
    {
        Quaternion prosto = new Quaternion(0.000000f, 0.000000000f, 0.00000000000f, 1);

        if (axis > 0) {
            
            Quaternion start = transform.rotation;


            // możliwy błąd, skręt w przypadkach niesterowności

            rb2D.freezeRotation = true;

            // koniec błędu 

            if (Quaternion.Angle(prosto, transform.rotation) < 36.9f && transform.rotation.z <= 0)
            {
               

                if (Quaternion.Angle(prosto, transform.rotation) < 36)
                {
                    Quaternion end = new Quaternion(0, 0, transform.rotation.z - Mathf.Abs(axis), 0);
                    transform.rotation = Quaternion.RotateTowards(start, end, 2 * moveTime);
                }
            }
            
            if (Quaternion.Angle(transform.rotation, prosto) < 36.9f && transform.rotation.z >= 0)
            {
                
                transform.rotation = Quaternion.RotateTowards(start, prosto, 2* moveTime);

            }


            rb2D.freezeRotation = false;
            yield return null;
        }
        if (axis<0)
        {
            Quaternion start = transform.rotation;

            
            if (Quaternion.Angle(transform.rotation, prosto) < 36.9f)
            {
                rb2D.freezeRotation = true;

               if (Quaternion.Angle(transform.rotation,prosto ) < 36)
                {
                    
                    Quaternion end = new Quaternion(0, 0, transform.rotation.z + Mathf.Abs(axis), 0);
                    transform.rotation = Quaternion.RotateTowards(start, end, 2 * moveTime);
                }
            }

          

            if (Quaternion.Angle(prosto, transform.rotation) < 36.9f && transform.rotation.z <= 0)
            {

                transform.rotation = Quaternion.RotateTowards(start, prosto, 2* moveTime);

            }

            /*
            if (Quaternion.Angle(prosto, transform.rotation) < 36.9f && transform.rotation.z < 0)
            {
                transform.rotation = Quaternion.RotateTowards(start, prosto, moveTime);
            }
            */

            rb2D.freezeRotation = false;


            yield return null;


        }








        //debugowanie wiru
        /*
        if (transform.rotation== prosto)
        {
            Debug.Log("Działa1111");
            Quaternion start = transform.rotation;
            if (axis < 0)
            {
                Quaternion end = new Quaternion(0, 0, Mathf.Abs(axis), 0);
                transform.rotation = Quaternion.RotateTowards(start, end, moveTime);

            
            }
            if (axis > 0)
            {
                Quaternion end = new Quaternion(0, 0, Mathf.Abs(axis), 0);
                transform.rotation = Quaternion.RotateTowards(start, end, moveTime);


            }
            yield return null;
        }
        */

        /*
        if (transform.rotation.z < 2 * float.Epsilon && transform.rotation.z > 0)
        {

            Quaternion start = transform.rotation;
            if (axis > 0)
            {
                Quaternion end = new Quaternion(0, 0, Mathf.Abs(axis), 0);
                transform.rotation = Quaternion.RotateTowards(start, end, moveTime);


            }
            yield return null;
        }
        */




        if (axis==0)
        {


            transform.rotation = Quaternion.RotateTowards(transform.rotation, prosto, 0.5f);

        
            

            yield return null;

        }
        
        

    }

    /*
    //przyspieszenie na wodzie

    IEnumerator przyspiesz()
    {
        Vector2 start = force.relativeForce;
        

        if (start.y<80)
        {
            
            force.relativeForce = 1.5f * start;
            yield return new WaitForSecondsRealtime(Time);
            force.relativeForce = force.relativeForce + new Vector2(0, 10);
            yield return new WaitForSecondsRealtime(Time);

        }
        if (start.y > 80)
        {
            force.relativeForce = new Vector2(0, Random.Range(100,120));
        }
        yield return null;
        
    }
    */

    
}

