using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundChecking : MonoBehaviour
{
    [SerializeField]private PlayerAnimator playerAnimator;
    [SerializeField]private LayerMask groundLayer;
    private bool touchGround = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.isTrigger && groundLayer == (groundLayer | (1 << other.gameObject.layer)))
        {
            StopAllCoroutines();
            playerAnimator.SetOnGround(true);
            touchGround = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(!other.isTrigger && groundLayer == (groundLayer | (1 << other.gameObject.layer))&& !touchGround)
        {
            StopAllCoroutines();
            playerAnimator.SetOnGround(true);
            touchGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(!other.isTrigger && groundLayer == (groundLayer | (1 << other.gameObject.layer)))
        {
            //if player didn't touch any ground for 0.2 seconds, set its animation to flying ones
            StopAllCoroutines();
            StartCoroutine(LeaveGroundCoroutine());
            touchGround = false;
        }
    }

    private IEnumerator LeaveGroundCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        if(!touchGround)
            playerAnimator.SetOnGround(false);
    }
}