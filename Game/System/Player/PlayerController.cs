using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool freeze;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private PlayerAnimator playerAnimator;
    [Header("Input")]
    private float horizontalMovementInput;
    private bool flyInput;
    private bool shootInput;
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSensitivity;
    [SerializeField] private float flySpeed;
    [SerializeField] private float flySensitivity;
    private float horizontalInputWithSensitivity = 0; //scaled input with sensitivity, from -1 to 1
    [Header("Shooting")]
    [SerializeField] private GameObject testingBullet;
    [SerializeField] private float testingBulletZ = -1;

    void Update()
    {
        if(freeze)
        {
            //animator.SetFloat("speed", 0);
            return;
        }
        UpdateInputValues();
    }

    void FixedUpdate()
    {
        if(freeze)
        {
            //animator.SetFloat("speed", 0);
            return;
        }
        Move();
        CheckShooting();
    }

    private void UpdateInputValues()
    {
        InputManager inputManager = SystemManager.instance.InputManager;
        horizontalMovementInput = inputManager.Action.Player.Move.ReadValue<Vector2>().x;
        flyInput = (inputManager.Action.Player.Fly.ReadValue<float>() > 0);
        //keep shooting enabled until it is consumed by the next fixed update
        shootInput = shootInput || inputManager.Action.Player.Fire.triggered; 
    }

    private void Move()
    {
        CheckFly();
        CheckHorizontalMovement();
    }

    private void CheckHorizontalMovement()
    {
        //reset speed to 0 when moving to opposite direction or stop moving
        horizontalInputWithSensitivity = (horizontalMovementInput * horizontalInputWithSensitivity) <= 0? 0 : horizontalInputWithSensitivity;
        horizontalInputWithSensitivity = Mathf.MoveTowards(horizontalInputWithSensitivity, horizontalMovementInput, moveSensitivity * 0.001f);
        rigid.velocity = new Vector2(horizontalInputWithSensitivity * moveSpeed, rigid.velocity.y);
        playerAnimator.SetSpeed(horizontalInputWithSensitivity * moveSpeed);
    }

    private void CheckFly()
    {
        if(flyInput)
        {
            float speed = Mathf.MoveTowards(rigid.velocity.y, flySpeed, 0.01f * flySensitivity);
            rigid.velocity = new Vector2(rigid.velocity.x, speed);
        }
    }

    private void CheckShooting()
    {
        if(shootInput){
            shootInput = false;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = (mousePos - playerPos).normalized;

            GameObject bullet = Instantiate(testingBullet, new Vector3(playerPos.x, playerPos.y, testingBulletZ), Quaternion.identity);
            bullet.GetComponent<TestingBullet>().Launch(direction);
            SystemManager.instance.AudioManager.PlaySFX(SFXFileName.Shoot);
        }
    }

    public void Freeze()
    {
        freeze = true;
        rigid.velocity = Vector2.zero;
    }
}
