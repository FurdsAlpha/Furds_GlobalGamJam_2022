using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerLight;
    public GameObject playerShadow;
    public EdgeCollider2D edgeCol;

    public bool hide;
    float un = 1;
    public float DeathSpeed;
    public string nextScene;



    // Start is called before the first frame update
    void Start()
    {
        edgeCol = GetComponent<EdgeCollider2D>();
        playerShadow.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 [] colliderPoints;
        colliderPoints = edgeCol.points;
        //colliderPoints[0] = new Vector2(this.transform.position.x, this.transform.position.y);
        colliderPoints[0] = new Vector2(playerLight.transform.position.x,playerLight.transform.position.y);
        colliderPoints[1] = new Vector2(playerShadow.transform.position.x, playerShadow.transform.position.y - un + 0.05f);
        edgeCol.points = colliderPoints;

        if (hide)
        {
            playerShadow.transform.localScale = new Vector3(1,1,1);
            playerShadow.GetComponent<ParticleSystem>().Stop();
            un = 1f;
        }
        else
        {
            un -= DeathSpeed * Time.deltaTime;

            if(un <= 0.3f)
            {
                StartCoroutine(DeathAnimation());
            }
        }
        
        playerShadow.transform.localScale = new Vector3(un,un,un);
    }

    void OnTriggerStay2D(Collider2D  collider)
    {
        if(collider.tag == "Terrain")
        {
            hide = true;
        }
        if(collider.tag == "Terrain Intouchable")
        {
            hide = true;
        }
        
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        hide = false;
        playerShadow.GetComponent<ParticleSystem>().Play();
    }
    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextScene);
    }
}
