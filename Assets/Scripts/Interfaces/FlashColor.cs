using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    private Color defaultColor;

    private Tween _currTween;

    private void OnValidate()
    {
        if( meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
        if (skinnedMeshRenderer == null) skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }


    [NaughtyAttributes.Button]
    public void Flash()
    {
        if (meshRenderer != null && !_currTween.IsActive())
            _currTween = meshRenderer.material.DOColor(Color.red, "_EmissionColor", .1f).SetLoops(2, LoopType.Yoyo);

        if (skinnedMeshRenderer != null && !_currTween.IsActive())
            _currTween = skinnedMeshRenderer.material.DOColor(Color.red, "_EmissionColor", .1f).SetLoops(2, LoopType.Yoyo);
    }
}
