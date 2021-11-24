using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackgroundBar : MonoBehaviour
{
    [SerializeField] private Transform transGroup;
    [SerializeField] private GameObject barItemPref;
    [SerializeField] private List<Sprite> possibleSprites = new List<Sprite>();
    [SerializeField] private bool reverse = false;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int numsInALoop = 10;
    [SerializeField] private float itemHeight = 100;
    [SerializeField] private float screenHeight = 720;

    void Start(){
        GenerateIcons();
        if(reverse){
            transform.localScale = new Vector3(1, -1, 1);
        }
    }

    void Update(){
        Move();
    }

    private void GenerateIcons()
    {
        List<Sprite> icons = new List<Sprite>();
        for(int x = 0; x < numsInALoop; ++x)
        {
            icons.Add(possibleSprites[Random.Range(0, possibleSprites.Count)]);
        }
        icons.AddRange(icons.ToArray());
        foreach(Sprite s in icons){
            GameObject obj = Instantiate(barItemPref, transGroup);
            Image image = obj.GetComponent<Image>();
            image.sprite = s;
            if(reverse){
                obj.transform.localScale = new Vector3(1, -1, 1);
            }
        }
    }

    private void Move()
    {
        // multiply certain numbles by -1 if reverse
        float reverseScale = reverse? -1 : 1;
        // we set y scale to -y when reverse, which changed the initial pos of the bar
        // if not reversed, jump from 1.5 to 0.5, if reverse, jump from 0.75 to -0.25. 
        // get by experimentations since not sure how rect transform works
        float warpPoint = reverse? 0.75f : 1.5f;
        transform.position += Vector3.up * moveSpeed * Time.deltaTime * reverseScale;
        float loopHeight = numsInALoop * itemHeight * Screen.height / screenHeight;
        if(transform.position.y * reverseScale >= loopHeight * warpPoint)
        {
            transform.position += Vector3.down * loopHeight * reverseScale;
        }
    }
}
