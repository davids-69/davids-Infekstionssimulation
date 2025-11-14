using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SpawnHumans;
    public GameObject stats;
    public int intialpopulation = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var i = 0; i < intialpopulation; i++)
        {
            float startposx = Random.Range(-8.0f, 8.0f);
            float startposy = Random.Range(-8.0f, 8.0f);
            Instantiate(SpawnHumans, new Vector3(startposx, startposy, 0), Quaternion.identity);
            stats.GetComponent<statisticsManager>().healthyCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
