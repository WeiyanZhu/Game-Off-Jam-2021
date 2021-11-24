using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectOutline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material spriteDefaultMat;
    private OutlineType outlineType = OutlineType.UnKnown;
    [SerializeField] private Material unknownOutlinelineMat;
    [SerializeField] private Material passOutlinelineMat;
    [SerializeField] private Material bugOutlinelineMat;
    //[SerializeField] private float thickness = 0.015f;
    private Dictionary<OutlineType, Material> outlineMaterials = new Dictionary<OutlineType, Material>();

    void Awake(){
        outlineMaterials.Add(OutlineType.UnKnown, unknownOutlinelineMat);
        outlineMaterials.Add(OutlineType.Pass, passOutlinelineMat);
        outlineMaterials.Add(OutlineType.Bug, bugOutlinelineMat);
    }

    public void ChangeOutlineType(OutlineType t){
        outlineType = t;
        //Update the outline if the object is being selected
        if(spriteRenderer.sharedMaterial != spriteDefaultMat)
            spriteRenderer.sharedMaterial = outlineMaterials[outlineType];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //outlineMaterials[outlineType].SetFloat("_Thickness", thickness);
        spriteRenderer.sharedMaterial = outlineMaterials[outlineType];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.sharedMaterial = spriteDefaultMat;
    }

    public void ChangeSpriteRenderer(SpriteRenderer newRenderer){
        spriteRenderer.sharedMaterial = spriteDefaultMat;
        spriteRenderer = newRenderer;
        ChangeOutlineType(outlineType);
    }
}
