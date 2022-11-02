using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class Player : Character
{

    float horizontalInput;
    float jumpInput;

    [Range(0.1f, 5f)]
    public float speed_mod = 1f;

    [Range(0.1f, 5f)]
    public float jump_mod = 1f;

    public bool on_ground_flag = true;
    public GameObject CellDetector;

    public GridLayout gl;
    public Tilemap tl;
    public Tile tile;

    void FixedUpdate()
    {
        //float dirX = Input.GetAxis(("Horizontal"));
        //Character_rb.velocity = new Vector2(dirX*7f, 0);
        //if (Input.GetButtonDown("Jump"))
        //    Character_rb.velocity = new Vector2(0, 14f);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Jump") != 0 && on_ground_flag)
        {
            Debug.Log(gl.WorldToCell(gameObject.transform.position));
            on_ground_flag = false;
            jumpInput = Input.GetAxisRaw("Jump") * jump_mod;
        }
        else
        {
            jumpInput = 0;
        }

        if (horizontalInput != 0f)
        {
            var cellPosition = gl.WorldToCell(transform.position) + Vector3Int.down;
            grid_position = new Vector2Int(cellPosition.x, cellPosition.y);
            //cellPosition.z = 1;
            Debug.Log(tl.GetTile(cellPosition));

            Vector3 cell_pos = gl.CellToWorld(cellPosition);
            tl.SetTile(cellPosition, tile);
            cell_pos.z = CellDetector.gameObject.transform.position.z;
            CellDetector.gameObject.transform.position = cell_pos - gl.cellSize/2;
            //int axisValue = horizontalInput > 0 ? 1 : -1;
            //Debug.Log("Horizontal " + Convert.ToString(axisValue));
        }
        speed_force = new Vector2(horizontalInput, jumpInput) * speed_mod;

        Character_rb.velocity = new Vector2(Mathf.Lerp(speed_force.x, 0f, 0.001f), Character_rb.velocity.y + (jumpInput != 0 ? speed_force.y : 0f));
    }
}
