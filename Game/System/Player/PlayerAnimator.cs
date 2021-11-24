using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string ON_GROUND_BOOL = "onGround"; //var names in animator
    private const string SPEED_FLOAT = "speed";
    [SerializeField] private Animator animator;
    [SerializeField] private Animator outlineAnimator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer outlineSpriteRenderer;

    public void SetFacingLeft(bool value){
        spriteRenderer.flipX = !value;
        outlineSpriteRenderer.flipX = !value;
    }

    public void SetSpeed(float value)
    {
        if(value > 0.01f)
            SetFacingLeft(false);
        else if(value < -0.01f)
            SetFacingLeft(true);
        value = Mathf.Abs(value);
        animator.SetFloat(SPEED_FLOAT, value);
        outlineAnimator.SetFloat(SPEED_FLOAT, value);
    }

    public void SetOnGround(bool value)
    {
        if(animator.GetBool(ON_GROUND_BOOL) != value)
        {
            animator.SetBool(ON_GROUND_BOOL, value);
            outlineAnimator.SetBool(ON_GROUND_BOOL, value);
        }
    }
}
