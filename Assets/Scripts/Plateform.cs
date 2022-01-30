using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform : MonoBehaviour
{
    
    public GameObject plateform;
    void Start()
    {
        plateform.SetActive(true);
    }
    void OnTriggerEnter(Collider  collider)
    {
        if(collider.tag == "Mouse")
        {
            plateform.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        plateform.SetActive(true);
    }
}
