using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infection : MonoBehaviour

{
    public SpriteRenderer sr;
    public int unitcondtion;
    private float timer = 0.0f;
    private bool restart = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        int diceroll = Random.Range(0, 50);
        {
            if (diceroll < 10)
            {
                unitcondtion = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (unitcondtion == 0)
        {
            sr.color = Color.white;
        }
        if (unitcondtion == 1)
        {
            sr.color = Color.green;
        }
        /*if (unitcondtion == 2)
        {
            sr.color = Color.blue;
        }
        if (unitcondtion == 3)
        {
            sr.color = Color.red;
        }*/
    }

   

    void FixedUpdate()
    {
        if (restart == true)
        {
            timer = timer + Time.deltaTime;
            if (timer > 0.25f)
            {
                gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
                gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.0f, 0.0f);
                restart = false;
            }
        }
    }

    // called when this GameObject collides with GameObject2.
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
        restart = true;
        timer = 0.0f;
    }
}

