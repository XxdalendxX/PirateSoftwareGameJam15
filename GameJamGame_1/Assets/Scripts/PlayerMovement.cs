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
    PlayerInfo playerInfo;

    Transform player;
    Rigidbody2D rb;
    PlayerInteractionHandler intHandler;

    [SerializeField] Transform playerBody;
    [SerializeField] CameraMovement cam;

    [HideInInspector] public PlayerDirection walkDirection = PlayerDirection.none;
    [HideInInspector] public bool interacting;
    [HideInInspector] public bool secondaryInteracting;

    

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
        intHandler = GetComponent<PlayerInteractionHandler>();
        intHandler.canMove = true;
    }

    void Update()
    {
        if (!intHandler.canMove)
            return;

        PlayerInputCheck();
        MovePlayer();

        if (interacting)
            PlayerInteraction();
        else if (secondaryInteracting)
            SecondaryPlayerInteraction();
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
        else if (walkDirection != PlayerDirection.none &&
                !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) &&
                !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            walkDirection = PlayerDirection.none;
        }

        if (Input.GetKeyDown(KeyCode.E))
            interacting = true;
        if (Input.GetKeyDown(KeyCode.F))
            secondaryInteracting = true;
    }

    private void MovePlayer()
    {
        if (walkDirection == PlayerDirection.left)
        {
            rb.velocity = Vector2.left * playerInfo.playerSpeed;
            playerBody.localRotation = Quaternion.Euler(0, 180, 0);
            cam.LerpCamera(walkDirection);
            cam.SetCooldownTimer();
        } //move player left
        else if (walkDirection == PlayerDirection.right)
        {
            rb.velocity = Vector2.right * playerInfo.playerSpeed;
            playerBody.localRotation = Quaternion.identity;
            cam.LerpCamera(walkDirection);
            cam.SetCooldownTimer();
        } // move player right
        else if (walkDirection == PlayerDirection.none && rb.velocity != Vector2.zero)
            rb.velocity = Vector2.zero;
    }

    private void PlayerInteraction()
    {
        if (intHandler.isInteracting)
            intHandler.PlayerIsInteracting();
        interacting = false;
    }
    private void SecondaryPlayerInteraction()
    {
        if (intHandler.isInteracting)
            intHandler.PlayerIsDoingTheOtherInteraction();
        secondaryInteracting = false;
    }
}
