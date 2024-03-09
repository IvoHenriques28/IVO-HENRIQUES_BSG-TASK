using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; //character speed
    private Rigidbody2D rb; // Rigidbody reference
    private Vector2 moveInput; //which direction player wants to go
    private Animator anim; // Animator reference

    // Start is called before the first frame update
    void Start()
    {
        //get all needed references
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
    }

    private void CheckMovement()
    {
        //get player input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //normalize movement
        moveInput.Normalize();

        //set animator float to the moveInputs

        anim.SetFloat("Input X", moveInput.x);
        anim.SetFloat("Input Y", moveInput.y);
        //set velocity on rigidbody
        rb.velocity =  moveInput * moveSpeed;
    }

}
