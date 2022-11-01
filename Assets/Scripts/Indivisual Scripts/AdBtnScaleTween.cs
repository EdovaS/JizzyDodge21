using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AdBtnScaleTween : MonoBehaviour
{
    void Start()
    {
        FunctionTimer.Create(AddBtnScale, 0.30f);
        FunctionTimer.Create(DisableAnimatorComponent, 0.30f); // disabling it because, it is making problem while animating. 
    }

    private void DisableAnimatorComponent()
    {
        transform.parent.GetComponent<Animator>().enabled = false;
    }

    void AddBtnScale()
    {
        
        Vector2 Btnscale = new Vector2(0.85f, 0.85f);
        transform.DOScale(Btnscale, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
