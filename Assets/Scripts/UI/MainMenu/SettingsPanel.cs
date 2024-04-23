using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : AbstractPanel
{

    [SerializeField] private GameConfiguration _gameConfiguration;
    [SerializeField] internal List<MainMenuButton> _buttons;
    [SerializeField] private MainMenuData _mainMenuData;
    [SerializeField] private RectTransform _rectTransform;

    private void Awake()
    {

        Debug.Log($"{this} was hide then awake");
        //ShowUpPanel(this);
        _rectTransform.transform.localScale = new Vector3(0, 0, 0);
        _mainMenuData._showUpEndScaleValue = new Vector3(1, 1, 0);
        _mainMenuData._fadeInEndScaleValue = new Vector3(0, 0, 0);
    }

    internal void ChangeSettings()
    {
        Debug.Log("I change some settigns");
    }

    internal void ChangeSetting()
    {
        Debug.Log("I change some settigns again ");
    }


    public void ShowUpPanel()
    {
        gameObject.SetActive(true);
        Tween showUpTween = _rectTransform
        .DOScale(_mainMenuData._showUpEndScaleValue, _mainMenuData._duration)
        .SetEase(Ease.InOutSine);
    }

    public void HidePanel()
    {

    }
}
