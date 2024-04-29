using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SettingsPanel : AbstractPanel
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
                Debug.Log("Enable subs back");
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
                Debug.Log("Enable subs back");
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

    public void Start()
    {

    }

    private async void Back()
    {
        await AsyncFadeInPanel();

        foreach (var panel in _menuPanels)
        {
            if (panel.Key.ToString() == "MainMenuPanel")
            {

                panel.Value.ShowPanel(panel.Value);
            }

        }
    }

    internal void ChangeSettings()
    {
        Debug.Log("I change some settigns");
    }

    internal void ChangeSetting()
    {
        Debug.Log("I change some settigns again ");
    }

    async Task AsyncFadeInPanel()
    {
        Tween fadeInTween = _rectTransform
        .DOScale(_mainMenuData._fadeInEndScaleValue, _mainMenuData._duration)
        .SetEase(Ease.InOutSine);
        await fadeInTween.AsyncWaitForCompletion();
    }

    public override void ShowPanel(IInteractablePanel panel)
    {
        Tween showUpTween = _rectTransform
        .DOScale(_mainMenuData._showUpEndScaleValue, _mainMenuData._duration)
        .SetEase(Ease.InOutSine);
    }
}
