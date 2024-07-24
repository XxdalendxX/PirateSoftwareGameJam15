using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection
{
    none,
    left,
    right,
}

public class PlayerMovement : MonoBehaviour
{
    Transform player;
    public float playerSpeed = 5f;
    Rigidbody2D rb;

    [SerializeField] Transform playerBody;
    [SerializeField] CameraMovement cam;

    public PlayerDirection walkDirection = PlayerDirection.none;
    [HideInInspector] public bool interacting;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
    }

    void Update()
    {
        PlayerInputCheck();
        MovePlayer();
    }

    void PlayerInputCheck()
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
            if (walkDirection == PlayerDirection.left)
                walkDirection = PlayerDirection.none;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
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
            playerBody.localRotation = Quaternion.Euler(0, 180, 0);
            cam.LerpCamera(walkDirection);
            cam.SetCooldownTimer();
        } //move player left
        else if (walkDirection == PlayerDirection.right)
        {
            rb.velocity = Vector2.right * playerSpeed;
            playerBody.localRotation = Quaternion.identity;
            cam.LerpCamera(walkDirection);
            cam.SetCooldownTimer();
        } // move player right
        else if (walkDirection == PlayerDirection.none && rb.velocity != Vector2.zero)
            rb.velocity = Vector2.zero;
    }


}
