using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class MainMenuPanel : BaseMainMenuPanel
{
    private SceneLoadHandler _sceneLoadHandler;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] internal List<MainMenuButton> _buttons;
    [SerializeField] private MainMenuData _mainMenuData;
    
    [Inject]
    public  void Construct(SceneLoadHandler sceneLoadHandler)
    {
        _sceneLoadHandler = sceneLoadHandler;
        Debug.Log($"{_sceneLoadHandler} injected");
    }
    
    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            if (button.CompareTag("Play"))
            {
                button.ButtonClick += Play;
            }
            else if (button.CompareTag("Settings"))
            {
                button.ButtonClick += OpenSettings;
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            if (button.CompareTag("Play"))
            {
                button.ButtonClick += Play;
            }
            else if (button.CompareTag("Settings"))
            {
                button.ButtonClick -= OpenSettings;
            }
        }
    }

    public void Awake()
    {
        Addpanel("MainMenuPanel", this);
        _rectTransform.transform.localScale = new Vector3(0, 0, 0);
        _mainMenuData._showUpEndScaleValue = new Vector3(1, 1, 0);
        _mainMenuData._fadeInEndScaleValue = new Vector3(0, 0, 0);
    }

    public async void Start()
    {
        await AsyncShowPanel();
    }

    private async void Play()
    {
        await AsyncHidePanel();
        _sceneLoadHandler.LoadGamePlayScene();
    }

    private async void OpenSettings()
    {
        await AsyncHidePanel();

        foreach (var panel in _menuPanels)
        {
            if (panel.Key.ToString() == "SettingsPanel")
            {
                Task showSettingsPanel  = panel.Value.AsyncShowPanel();
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
