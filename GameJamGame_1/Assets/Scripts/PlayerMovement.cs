using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerBody;
    public float playerSpeed = 5f;
    public Rigidbody2D rb;

    [HideInInspector] public enum PlayerDirection
    {
        none,
        left,
        right,
    }
    public PlayerDirection walkDirection = PlayerDirection.none;
    [HideInInspector] public bool interacting;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
        MovePlayer();
    }

    void MovementCheck()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            walkDirection = PlayerDirection.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            walkDirection = PlayerDirection.right;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log("player has stopped travelling left");
            if (walkDirection == PlayerDirection.left)
                walkDirection = PlayerDirection.none;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("player has stopped travelling right");
            if (walkDirection == PlayerDirection.right)
                walkDirection = PlayerDirection.none;
        }

        if (Input.GetKeyDown(KeyCode.E))
            interacting = true;
    }

    private void MovePlayer()
    {
        if (walkDirection == PlayerDirection.left)
        {
            rb.velocity = Vector2.left * playerSpeed;
        }
        else if (walkDirection == PlayerDirection.right)
        {
            rb.velocity = Vector2.right * playerSpeed;
        }
        else if (walkDirection == PlayerDirection.none && rb.velocity != Vector2.zero)
            rb.velocity = Vector2.zero;
    }
}
