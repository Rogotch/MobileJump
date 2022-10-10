using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    float horizontalInput;
    float jumpInput;

    [Range(0.1f, 5f)]
    public float speed_mod = 1f;

    [Range(0.1f, 5f)]
    public float jump_mod = 1f;

    public bool on_ground_flag = true;

    void FixedUpdate()
    {
        //float dirX = Input.GetAxis(("Horizontal"));
        //Character_rb.velocity = new Vector2(dirX*7f, 0);
        //if (Input.GetButtonDown("Jump"))
        //    Character_rb.velocity = new Vector2(0, 14f);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Jump") != 0 && on_ground_flag)
        {
            //Debug.Log("Jump");
            on_ground_flag = false;
            jumpInput = Input.GetAxisRaw("Jump") * jump_mod;
        }
        else
        {
            jumpInput = 0;
        }

        speed_force = new Vector2(horizontalInput, jumpInput) * speed_mod;

        Character_rb.velocity = new Vector2(Mathf.Lerp(speed_force.x, 0f, 0.001f), Character_rb.velocity.y + (jumpInput != 0 ? speed_force.y : 0f));
    }
}
