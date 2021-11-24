using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private int currentPoint;
    private float currentPosInPercentage = 0; // which pos between point A to B are we at
    [SerializeField] private float speed;
    [Header("Direction")]
    [SerializeField] private bool flipDirection = true;
    [SerializeField] [ShowIf("flipDirection")] private bool spriteAssetFacingRight;


    void FixedUpdate()
    {
        Move();
        if(flipDirection)
            ChangeDirection();
    }

    private void Move(){
        int nextPoint = (currentPoint + 1) % points.Count;
        Vector3 diff = points[nextPoint].position - points[currentPoint].position;
        float distance = diff.magnitude;
        float advance = (speed * 0.01f) / distance;
        currentPosInPercentage += advance;
        //change to next edge
        if(currentPosInPercentage >= 1)
        {
            currentPosInPercentage %= 1;
            currentPoint = nextPoint;
            nextPoint = (currentPoint + 1) % points.Count;
            diff = points[currentPoint].position - points[nextPoint].position;
        }
        rigid.MovePosition(points[currentPoint].position + diff * currentPosInPercentage);
    }

    private void ChangeDirection(){
        int nextPoint = (currentPoint + 1) % points.Count;
        Vector3 diff = points[nextPoint].position - points[currentPoint].position;
        //when moving perfectly vertical, dont flip direction
        if(diff.x != 0)
        {
            bool noFlipNeed = spriteAssetFacingRight? (diff.x > 0) : (diff.x < 0);
            float xSymbol = noFlipNeed? 1 : -1;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * xSymbol;
            transform.localScale = scale;
        }
    }
}
