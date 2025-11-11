using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.UI;
using UnityEngine;

public class infection : MonoBehaviour

{
    public float speed = 3f;
    public SpriteRenderer sr;
    public int unitcondtion = 0;
    public float timer = 0.10f;
    // public bool restart = false;
    Color human_Color;
    SpriteRenderer human;
    public GameObject stats;
    private bool isAlive = true;
    public float infectionDurantion = 5.0f;
    public int infectionChance = 50;
    private float changeDirectionInterval = 0f;
    private float DirectionX;
    private float DirectionY;
    public Vector3 targetPos;
   

    private void Awake()
    {
        stats = GameObject.Find("statistics");
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unitcondtion == 0)
        {
            sr.color = Color.white; // frisk
        }
        if (unitcondtion == 1)
        {
            sr.color = Color.green; // sjuk
        }
        if (unitcondtion == 2)
        {
            sr.color = Color.blue; // immun
        }
        if (unitcondtion == 3)
        {
            sr.color = Color.red; // död
        // Destroy(this);

        }
        changeDirectionInterval -=Time.deltaTime;
        if (changeDirectionInterval <= 0)
        { 
            DirectionX = Random.Range(-1, 2);
            DirectionY = Random.Range(-1, 2);
            changeDirectionInterval = 2.0f; //reset interval 


        }
        Debug.Log(isAlive);
        //rörelse
        if (isAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 3f * Time.deltaTime);

            if (transform.position == targetPos)
            {
                targetPos = new Vector3(Random.Range(-3, 3), Random.Range(-4, 4), 0);
            }
            /*if (transform.position.x <= 8.5f && DirectionX > 0) 
            {
                DirectionX += -1;                
            }
            if (transform.position.x >= -8.5f && DirectionX < 0)
            {
                DirectionX += -1;
            }
            if (transform.position.y <= 4.5f && DirectionX > 0)
            {
                DirectionX += -1;
            }
            if (transform.position.y >= -4.5f && DirectionX < 0)
            {
                DirectionX += -1;
            }
            transform.Translate(new Vector3(DirectionX, DirectionY, 0).normalized * speed * Time.deltaTime); */
        }
    }



    void FixedUpdate()
    {
        /*  if (restart == true)
          {
              timer = timer + Time.deltaTime;
              if (timer > 0.10f)
              {
                  gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
                  gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.0f, 0.0f);
                  restart = false;
              }
          }*/
    }

    // called when this GameObject collides with GameObject2.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "infected human" && gameObject.tag == "human")
        {
            int diceroll = Random.Range(0, 101);
            {
                if (diceroll < 50)

                {
                    unitcondtion = 1;
                    gameObject.tag = "infected human";
                    infect();
                   
                }
            }
        }
        Debug.Log("GameObject1 collided with " + col.name);
        // restart = true;
        // timer = 0.0f;
    }

    IEnumerator Infected()
    {
        timer = Random.Range(0, 11);
        stats.GetComponent<statisticsManager>().infectedCount++;
        stats.GetComponent<statisticsManager>().healthyCount--;
        yield return new WaitForSeconds(timer);
        int diceroll = Random.Range(0, 101);

        //IF någonting med diceroll
        if (diceroll < 3)
        {
            // blå = immun
            unitcondtion = 2;
            gameObject.tag = "Immune";
            stats.GetComponent<statisticsManager>().immuneCount++;
            stats.GetComponent<statisticsManager>().infectedCount--;

        }
        //Annars död
        else
        {
            // röd = död
            unitcondtion = 3;
            gameObject.tag = "dead";
            isAlive = false;
            // Destroy(gameObject);
            stats.GetComponent<statisticsManager>().deadCount++;
            stats.GetComponent<statisticsManager>().infectedCount--;
        }

        yield return null;
    }
    void infect()
    { 
        StartCoroutine(Infected());
    
    }
    void Immuneordead()
    {
        int infect = Random.Range(0, 101);
        if (infect < 50)
        {
            stats.GetComponent<statisticsManager>().infectedCount--;
            stats.GetComponent<statisticsManager>().immuneCount++;
        }
    }
}



