using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitchCollider : MonoBehaviour
{
    [SerializeField] private Collider2D[] colliders;

    public void UnEnable(int index)
    {
        colliders[index].enabled = false;
    }

    public void Enable(int index)
    {
        colliders[index].enabled = true;
    }
}
