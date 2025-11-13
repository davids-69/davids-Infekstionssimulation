using UnityEngine;

public class PatientZero : MonoBehaviour
{
    public Transform target;  // objektet följer gubben
    public Vector3 offset;  // hur mycke ovanför texten ska ligga
    public Camera cam;      // kamera använd
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenpos = cam.WorldToScreenPoint(target.position + offset);
        transform.position = screenpos;
    }
}
