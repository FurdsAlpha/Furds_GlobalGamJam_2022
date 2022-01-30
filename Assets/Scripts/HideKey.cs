using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideKey : MonoBehaviour
{
    public GameObject clef;
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
        Vector3 _light_ = _light.transform.InverseTransformPoint(transform.position);
        //colliderPoints[0] = new Vector2(this.transform.position.x, this.transform.position.y);
        colliderPoints[0] = new Vector2(clef.transform.localPosition.x, clef.transform.localPosition.y);
        colliderPoints[1] = new Vector2(-_light_.x , -_light_.y);
        edgeCol.points = colliderPoints;
    }
    void OnTriggerStay2D(Collider2D  collider)
    {
        if(hideInLight == true)
        {
            visuel.SetActive(true);
            Debug.Log(this.gameObject + "est révélé dans l'ombre");
        }
        else if(hideInLight == false)
        {
            visuel.SetActive(false);
            Debug.Log(this.gameObject + "est caché dans l'ombre");
        }else{
            
        }
    }

    void OnTriggerExit2D(Collider2D  collider)
    {
        if(hideInLight == true)
        {
            visuel.SetActive(false);
            Debug.Log(this.gameObject + "est caché dans la lumiere");
        }
        else if(hideInLight == false)
        {
            visuel.SetActive(true);
            Debug.Log(this.gameObject + "est révélé dans la lumiere");
        }
        else{

        }
    }
}
