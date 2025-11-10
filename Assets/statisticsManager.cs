using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class statisticsManager : MonoBehaviour
{
    public int healthyCount = 0;
    public int infectedCount = 0;
    public int immuneCount = 0;
    public int deadCount = 0;
    public TMP_Text stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        stats = stats.GetComponent<TMP_Text>();
        stats.text =  "Healthy: " + healthyCount + "\nInfected: " + infectedCount + "\nImmune: " + immuneCount + "\nDead: " + deadCount;
    }
}

