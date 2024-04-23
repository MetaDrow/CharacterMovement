using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
public class MainMenuPanel : AbstractPanel
{

    private SceneLoadHandler _sceneLoadHandler;

    [SerializeField] internal List<MainMenuButton> _buttons;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private MainMenuData _mainMenuData;

    [Inject]
    private void Construct(SceneLoadHandler sceneLoadHandler)
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
                Debug.Log("Enable subs play");
            }
            else if (button.CompareTag("Settings"))
            {
                button.ButtonClick += OpenSettings;
                Debug.Log("Enable subs settigns");
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
                Debug.Log("Unsubscribe button");
            }

        }
    }

    public void Awake()
    {

        _rectTransform.transform.localScale = new Vector3(0, 0, 0);
        _mainMenuData._showUpEndScaleValue = new Vector3(1, 1, 0);
        _mainMenuData._fadeInEndScaleValue = new Vector3(0, 0, 0);
    }


    public void Start()
    {
        ShowUpPanel();
    }


    public async void OpenSettings()
    {
        await AsyncFadeInPanel();



        _settingsPanel.ShowUpPanel();
    }

    public async void Play()
    {
        await AsyncFadeInPanel();
        _sceneLoadHandler.LoadGamePlay();
    }

    public void ShowUpPanel()
    {
        Tween showUpTween = _rectTransform
        .DOScale(_mainMenuData._showUpEndScaleValue, _mainMenuData._duration)
        .SetEase(Ease.InOutSine);
    }

    async Task AsyncFadeInPanel()
    {

        Tween fadeInTween = _rectTransform
        .DOScale(_mainMenuData._fadeInEndScaleValue, _mainMenuData._duration)
        .SetEase(Ease.InOutSine);
        await fadeInTween.AsyncWaitForCompletion();
    }

    public void Exit()
    {
        Application.Quit();
    }




}
