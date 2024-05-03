using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class MainMenuButton : AbstractButton
{
    [SerializeField] private const float _scaleValue = 1.2f;
    [SerializeField] private Vector3 _objectscale;
    [SerializeField] private Vector3 _endScaleValue;
    [SerializeField] private float _duration;
    public Action ButtonClick;

    private void Start()
    {
        _objectscale = this.transform.localScale;
        _endScaleValue = _objectscale * _scaleValue;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerClick)
        {
            ButtonClick?.Invoke();
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_endScaleValue, _duration)
        .SetEase(Ease.InOutSine);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_objectscale, _duration)
        .SetEase(Ease.InOutSine);
    }
}