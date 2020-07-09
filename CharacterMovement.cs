using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (enabled)
        {
            //Get the horizontal and vertical movement input
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            //Move the player 
            Vector3 movement = new Vector3(horizontal, Of, vertical) * walkSpeed * Time.deltaTime;
            transform.Translate(movement, Space.Self);

            //Animate the player
            if (vertical != 0)
            {
                if (Input.Getkey(KeyCode.LeftShift))
                {
                    animator.SetBool("is_running", true);
                    animator.SetBool("is_walking", false);
                }
                else
                {
                    animator.SetBool("is_running", false);
                    animator.SetBool("is_walking", true);
                }
            }
            else
            {
                animator.SetBool("is_walking", false);
                animator.SetBool("is_running", false);
            }
        }
    }
}