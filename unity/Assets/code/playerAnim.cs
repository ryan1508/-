using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        // -1 ~ 1
        Vector3 velocity = new Vector3(inputX, 0, inputZ);

        //animation
        if (inputX == 0)
            anim.SetBool("walk", false);
        else
            anim.SetBool("walk", true);
       
    }
    
}
