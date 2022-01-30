using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject clef;
    public GameObject Active;
    public GameObject Desactive;
    public AudioSource keyActivation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D  collider)
    {
        if(collider.tag == "Player")
        {
            keyActivation.Play();
            Active.SetActive(true);
            Desactive.SetActive(false);
            clef.SetActive(false);
        }
    }
}
