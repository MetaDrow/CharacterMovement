using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Main Menu Panel Data")]
public class MainMenuData : ScriptableObject
{
    [SerializeField] internal bool _mainMenuEnabled;
    [SerializeField] internal const float _scaleValue = 1.2f;
    [SerializeField] internal float _duration;
    [SerializeField] internal Vector3 _objectscale;
    [SerializeField] internal Vector3 _showUpEndScaleValue;
    [SerializeField] internal Vector3 _fadeInEndScaleValue;
}
