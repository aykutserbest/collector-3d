using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonAnimationController : MonoBehaviour
{

    [SerializeField] private float duration;
    private void OnEnable()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        gameObject.GetComponent<RectTransform>().DOScale(0.7f, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
