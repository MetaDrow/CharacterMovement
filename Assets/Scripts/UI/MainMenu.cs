using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
public class MainMenu : MonoBehaviour
{
    private SceneLoadHandler _sceneLoadhadnler;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private const float _scaleValue = 1.2f;
    [SerializeField] private Vector3 _objectscale;
    [SerializeField] private Vector3 _showUpEndScaleValue;
    [SerializeField] private Vector3 _fadeInEndScaleValue;
    [SerializeField] private float _duration;

    [Inject]
    private void Construct(SceneLoadHandler sceneLoadHandler)
    {
        _sceneLoadhadnler = sceneLoadHandler;
        Debug.Log($"{_sceneLoadhadnler} injected");
    }

    public void Awake()
    {
        _rectTransform.transform.localScale = new Vector3(0, 0, 0);
        _showUpEndScaleValue = new Vector3(1, 1, 0);
        _fadeInEndScaleValue = new Vector3(0, 0, 0);
    }

    public void Start()
    {
        ShowUp();
    }

    public async void Play()
    {
        await AsyncFadeIn();
        _sceneLoadhadnler.LoadGamePlay();
    }

    public async void LoadMainMenuSceneAsync()
    {
        await AsyncFadeIn();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowUp()
    {

        Tween showUpTween = _rectTransform.DOScale(_showUpEndScaleValue, _duration)
    .SetEase(Ease.InOutSine);
    }

    async Task AsyncFadeIn()
    {

        Tween fadeInTween = _rectTransform.DOScale(_fadeInEndScaleValue, _duration)
.SetEase(Ease.InOutSine);
        await fadeInTween.AsyncWaitForCompletion();

    }

}
