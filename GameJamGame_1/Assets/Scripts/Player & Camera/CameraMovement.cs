using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float distancefFromPlayer;
    [SerializeField] Transform target;
    [SerializeField] float camResetTimer;

    [Space]

    [SerializeField] float lerp;
    [SerializeField] float resetCooldown = 0;
    [SerializeField] bool awayFromPlayer = false;
    [SerializeField] float targetX;
    [SerializeField] float camX;
    [SerializeField] float distanceToPlayer;

    [SerializeField] float distYFromPlayer;




    private void Update()
    {
        targetX = target.position.x;
        camX = transform.position.x;

        if (awayFromPlayer)
            ResetTimerHandler();

        transform.position = new Vector3(targetX + lerp, target.position.y + distYFromPlayer, transform.position.z);
    }

    public void LerpCamera(PlayerDirection direction)
    {
        if (direction == PlayerDirection.left)
        {
            lerp = Mathf.Lerp(lerp, -distancefFromPlayer, (1.5f * Time.deltaTime));
        }
        else if (direction == PlayerDirection.right)
        {
            lerp = Mathf.Lerp(lerp, distancefFromPlayer, (1.5f * Time.deltaTime));
        }
    }

    public void ReturnToTarget()
    {
        distanceToPlayer = lerp - targetX;
        distanceToPlayer = targetX - camX;
        lerp = Mathf.Lerp(lerp, distanceToPlayer, (1.5f * Time.deltaTime));
    }

    public void SetCooldownTimer()
    {
        resetCooldown = camResetTimer;
        awayFromPlayer = true;
    }

    void ResetTimerHandler()
    {
        bool condition_1 = resetCooldown <= 0;
        bool condition_2 = awayFromPlayer;
        bool condition_3 = transform.position.x == target.position.x;

        if (!condition_1)
            resetCooldown -= Time.deltaTime;

        if (condition_1 && !condition_3)
        {
            ReturnToTarget();
        }

        if (condition_1 && condition_2 && condition_3)
        {
            awayFromPlayer = false;
            resetCooldown = 0;
        }
    }
}
