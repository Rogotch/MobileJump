using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    protected Rigidbody2D Character_rb;
    protected Vector2 speed_force = Vector2.zero;


    void Start()
    {
        Character_rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
