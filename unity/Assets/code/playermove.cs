using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody characterRigidbody;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        // -1 ~ 1
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= speed;
        characterRigidbody.velocity = velocity;
        
        ChangeFlipX(inputX);
    }


    void ChangeFlipX(float x)
    {
        if (x < 0)//왼쪽
        {
            _spriteRenderer.flipX = false;
        }
        else if (x > 0)//오른쪽
        {
            _spriteRenderer.flipX = true;
        }
    }
}


