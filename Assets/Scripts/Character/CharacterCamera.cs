using Cinemachine;
using UnityEngine;
using Zenject;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private CinemachineVirtualCamera _camera;

    [Inject]
    private void Construct(Character character)
    {
        _character = character;
    }
    private void Start()
    {
        Debug.Log($"{this} is install");
        _camera = GetComponent<CinemachineVirtualCamera>();
        SetTarget();

    }

    private void SetTarget()
    {
        _camera.LookAt = _character.transform;
        _camera.Follow = _character.transform;
    }
}
