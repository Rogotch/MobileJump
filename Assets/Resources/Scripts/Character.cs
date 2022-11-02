using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    enum CharacterCondition { idle, move, fall }

    protected Rigidbody2D Character_rb;
    protected Vector2 speed_force = Vector2.zero;
    protected Vector2Int grid_position = Vector2Int.zero;

    CharacterCondition Condition;

    void Start()
    {
        Character_rb = gameObject.GetComponent<Rigidbody2D>();
        Condition = CharacterCondition.idle;

    }
}
