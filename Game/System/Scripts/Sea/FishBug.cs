using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBug : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float bugSpeed = 10;
    private float normalSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = animator.speed;
        animator.speed = bugSpeed;
    }

    public void Fix()
    {
        animator.speed = normalSpeed;
    }
}
