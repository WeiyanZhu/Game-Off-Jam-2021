using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeleportBetweenPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private GameObject target;
    private int currentPoint = 0;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float fadeTime;
    private float timer = 0;

    void Start(){
        DOTween.Init();
        timer = fadeTime;//teleport on first frame
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > fadeTime){
            timer = 0;
            Teleport();
        }
    }

    private void Teleport()
    {
        //fade
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(spriteRenderer.DOFade(0, fadeTime/2));
        mySequence.Append(spriteRenderer.DOFade(1, fadeTime/2));
        //go to next point
        currentPoint = (currentPoint + 1) % points.Count;
        target.transform.position = points[currentPoint].position;
    }
}
