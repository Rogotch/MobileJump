using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(0.1f, 5f)]
    public float speed_mod = 1f;

    [Range(0.1f, 5f)]
    public float jump_mod = 1f;

    public bool on_ground_flag = false;

    protected Rigidbody2D Character_rb;
    protected Vector2 speed_force = Vector2.zero;

    float horizontalInput;
    float jumpInput;

    // Start is called before the first frame update
    void Start()
    {
        Character_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Jump") != 0 && on_ground_flag)
        {
            on_ground_flag = false;
            jumpInput = Input.GetAxisRaw("Jump") * jump_mod;
        }
        else
        {
            jumpInput = 0;
        }

        speed_force = new Vector2(horizontalInput, jumpInput) * speed_mod;
        //Unit_rb.AddForce(speed_force);
        //if (jumpInput != 0 || horizontalInput != 0)
        //{
        //    Character_rb.velocity = new Vector2( Mathf.Lerp(speed_force.x, 0f, 0.1f), Character_rb.velocity.y + speed_force.y);

        //}
        Character_rb.velocity = new Vector2( Mathf.Lerp(speed_force.x, 0f, 0.001f), Character_rb.velocity.y + (horizontalInput != 0 ? speed_force.y : 0f));
        //Character_rb.velocity.y = Mathf.Lerp(speed_force.x, 0f, 0.1f);
        //Character_rb.AddForce(new Vector2(0, jumpInput));
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    on_ground_flag = true;
    //    //Debug.Log("Collision!");
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {

        //on_ground_flag = true;
        //Debug.Log(collision.gameObject);
    }
}
