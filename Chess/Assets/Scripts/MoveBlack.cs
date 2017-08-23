using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlack : MonoBehaviour {

    public int moveSpeed = 15;
    public Transform piecePos;
    public Rigidbody rb;
    private int jumpStr = 30;
    public bool control = false;
    public Renderer rend;

    private GameController gameControl;
    private float lerpFloat = 0.2f;
    private Color curColor;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        piecePos = GetComponent<Transform>();
        rend = GetComponent<Renderer>();
        gameControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        curColor = rend.material.color;
    }

    void Update ()
    {
        if (control == true & (gameControl.cam1.enabled == true | gameControl.cam2.enabled == true))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = piecePos.position + new Vector3(0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = piecePos.position + new Vector3(0, 0, -1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = piecePos.position + new Vector3(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = piecePos.position + new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * (jumpStr * 10));
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                control = false;
                gameControl.selection = true;
                rend.material.color = curColor;
            }
        }
        else if (control == true & gameControl.cam3.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = piecePos.position + new Vector3(0, 0, -1);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = piecePos.position + new Vector3(0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = piecePos.position + new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = piecePos.position + new Vector3(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * (jumpStr * 10));
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                control = false;
                gameControl.selection = true;
                rend.material.color = curColor;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            control = false;
            gameControl.selection = true;
            rend.material.color = curColor;
        }

    }

    void OnMouseDown()
    {
        if (gameControl.selection == true)
        {
            gameControl.newSelect = true;
            gameControl.selection = false;
            gameControl.DeselectAll();
            Select();
        }
        else if (gameControl.newSelect == true)
        {
            gameControl.newSelect = false;
            gameControl.selection = true;
            gameControl.DeselectAll();
            Select();
        }
    }

    public void Deselect()
    {
        rend.material.color = curColor;
        control = false;
    }

    void Select()
    {
        control = true;
        rend.material.color = Color.LerpUnclamped(rend.material.color, Color.cyan, lerpFloat);
    }


}
