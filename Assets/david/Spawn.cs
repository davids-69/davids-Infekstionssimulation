using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject SpawnHumans;
    public GameObject stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            Instantiate(SpawnHumans, new Vector3(i * 3.0f, 0, 0), Quaternion.identity);
            stats.GetComponent<statisticsManager>().healthyCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
