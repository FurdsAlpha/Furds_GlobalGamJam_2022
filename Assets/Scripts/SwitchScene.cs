using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string nextScene;
    public AudioSource levelUp;
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
            levelUp.Play();
            StartCoroutine(levelUpAnimation());
        }
    }

    IEnumerator levelUpAnimation(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(nextScene);
    }
}
