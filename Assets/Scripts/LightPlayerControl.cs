using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightPlayerControl : MonoBehaviour
{
    public Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnLightMove(InputValue value)
    {
        var pos = value.Get<Vector2>();
        transform.position = new Vector3(mainCamera.ScreenToWorldPoint(pos).x, mainCamera.ScreenToWorldPoint(pos).y, 0);

        
    }
}
