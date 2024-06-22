using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SettingsPanel : BaseMainMenuPanel
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] internal List<MainMenuButton> _buttons;
    [SerializeField] private MainMenuData _mainMenuData;
    [SerializeField] private GameConfiguration _gameConfiguration;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            if (button.CompareTag("Back"))
            {
                button.ButtonClick += Back;
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            if (button.CompareTag("Back"))
            {
                button.ButtonClick -= Back;
            }
        }
    }

    private void Awake()
    {
        Addpanel("SettingsPanel", this);
        _rectTransform.transform.localScale = new Vector3(0, 0, 0);
        _mainMenuData._showUpEndScaleValue = new Vector3(1, 1, 0);
        _mainMenuData._fadeInEndScaleValue = new Vector3(0, 0, 0);
    }

    private async void Back()
    {
        await AsyncHidePanel();

        foreach (var panel in _menuPanels)
        {
            if (panel.Key.ToString() == "MainMenuPanel")
            {
                Task showMainMenuPanel = panel.Value.AsyncShowPanel();
            }
        }
    }

    public override async Task AsyncShowPanel()
    {
        Tween showPanelTween = _rectTransform
        .DOScale(_mainMenuData._showUpEndScaleValue, _mainMenuData._duration)
        .SetEase(Ease.InOutSine);
        await showPanelTween.AsyncWaitForCompletion();
    }

    public override async Task AsyncHidePanel()
    {
        Tween hidePanelTween = _rectTransform
        .DOScale(_mainMenuData._fadeInEndScaleValue, _mainMenuData._duration)
        .SetEase(Ease.InOutSine);
        await hidePanelTween.AsyncWaitForCompletion();
    }
}
