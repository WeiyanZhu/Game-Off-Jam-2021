using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainManager : MonoBehaviour
{
    [SerializeField]private Image imageComponent;
    private Material material;

    void Awake()
    {
        //use a copy of material
        material = new Material(imageComponent.material);
        imageComponent.material = material;
    }

    public IEnumerator Fade(float time, int modifier = 1)
    {
        imageComponent.gameObject.SetActive(true);
        float initAlpha = 0;
        float targetAlpha = 1;

        material.SetFloat("_GradientCutoff", initAlpha);
        material.SetFloat("_GradientModifier", modifier);
        for(float timer = 0; timer < time; timer += Time.deltaTime)
        {
            material.SetFloat("_GradientCutoff", initAlpha + (targetAlpha - initAlpha)* (timer/time));
            yield return new WaitForEndOfFrame();
        }
        material.SetFloat("_GradientCutoff", targetAlpha);

        if(targetAlpha == 0 || modifier == -1)
        {
            imageComponent.gameObject.SetActive(false);
        }
    }
}
