using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShadowController : MonoBehaviour
{[Header("Movement Setting")]
    public float speed = 6.0F;
    public float Direction;
    private Rigidbody2D _rigidbody;

    [Space(15)]
    public float jumpSpeed = 8.0F;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnMove(InputValue value)
    {
        Direction = value.Get<float>();
    }
    
    public void OnJump()
    {
        if(Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector3(0,jumpSpeed,0), ForceMode2D.Impulse);
        }
    }

    public void Move()
    {
        transform.position += new Vector3(Direction, 0 ,0) * speed * Time.deltaTime;
    }
}
