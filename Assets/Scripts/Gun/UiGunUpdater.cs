using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiGunUpdater : MonoBehaviour
{
    public Image uiImage;

    [Header("Animation")]
    public float duration = .1f;
    public Ease ease = Ease.OutBack;

    private Tween _currTween;

    private void OnValidate()
    {
        if(uiImage == null) uiImage = GetComponent<Image>();    
    }

    public void UptadeValue(float f)
    {
        uiImage.fillAmount = f;
    }

    public void UptadeValue(float max, float current)
    {
        if (_currTween != null) _currTween.Kill();
       _currTween = uiImage.DOFillAmount(1 - (current / max),duration).SetEase(ease);
    }
}
