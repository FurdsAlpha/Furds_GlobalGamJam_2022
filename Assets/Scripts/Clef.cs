using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clef : MonoBehaviour
{
    public GameObject clef;
    public GameObject Active;
    public GameObject Desactive;
    public bool hideInLight = false;
    public EdgeCollider2D edgeCol;
    public GameObject _light;
    public GameObject visuel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 [] colliderPoints;
        colliderPoints = edgeCol.points;
        //colliderPoints[0] = new Vector2(this.transform.position.x, this.transform.position.y);
        colliderPoints[0] = new Vector2(clef.transform.position.x, clef.transform.position.y);
        colliderPoints[1] = new Vector2(_light.transform.position.x, _light.transform.position.y);
        edgeCol.points = colliderPoints;
    }
    void OnTriggerEnter2D(Collider2D  collider)
    {
        if(collider.tag == "Player")
        {
            Active.SetActive(true);
            Desactive.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else if(collider.tag == "Terrain" && hideInLight == false)
        {
            visuel.SetActive(false);
            Debug.Log(this.gameObject + "est caché dans la lumiere");
        }
        else if(collider.tag == "Terrain" && hideInLight == true)
        {
            visuel.SetActive(true);
            Debug.Log(this.gameObject + "est révélé dans la pénombre");
        }else{
            
        }
    }

    void OnTriggerExit2D(Collider2D  collider)
    {
        if(collider.tag == "Player")
        {
            Active.SetActive(true);
            Desactive.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else if(collider.tag == "Terrain" && hideInLight == false)
        {
            visuel.SetActive(true);
            Debug.Log(this.gameObject + "est caché dans la pénonbre");
        }
        else if(collider.tag == "Terrain" && hideInLight == true)
        {
            visuel.SetActive(false);
            Debug.Log(this.gameObject + "est révélé dans la lumiere");
        }
        else{

        }
    }
}
