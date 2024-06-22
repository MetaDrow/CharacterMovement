using Cinemachine;
using UnityEngine;
using Zenject;
using Platformer.Character;

public class CharacterCameraZenject : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    private Character _character;
    //[SerializeField] private CharacterData _characterData;

    [Inject]
    public void Construct(Character character)
    {
        _character = character;
    }

    private void Start()
    {
        Debug.Log($"{this} is install");
        SetTarget();
    }

    private void SetTarget()
    {
        _camera.LookAt = _character.transform;
        _camera.Follow = _character.transform;
    }
}
