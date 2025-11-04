using Unity.VisualScripting;
using UnityEngine;

public class förflyttning : MonoBehaviour
{
    public Vector3 targetPos;
    public string condtion = "healthy";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 3f * Time.deltaTime);

        if (transform.position == targetPos) 
        {
            targetPos = new Vector3(Random.Range(-3,3), Random.Range(-4,4), 0);
        }
    }
}

