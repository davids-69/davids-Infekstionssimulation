using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class infection : MonoBehaviour

{
    public SpriteRenderer sr;
    public int unitcondtion = 0;
    public float timer = 0.10f;
    // public bool restart = false;
    Color human_Color;
    SpriteRenderer human;
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
            Destroy(this);
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
        if (col.tag == "infected human")
        {
            int diceroll = Random.Range(0, 99);
            {
                if (diceroll < 3)
                    
                {
                    unitcondtion = 1;
                    gameObject.tag = "infected human";
                    timer = Random.Range(0, 99);
                    new WaitForSeconds(10);
                }
            }
        }
        Debug.Log("GameObject1 collided with " + col.name);
       // restart = true;
       // timer = 0.0f;
    }
}

