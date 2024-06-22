using Cinemachine;
using Platformer.Character;
using UnityEngine;

namespace Platformer.Ecs
{
    public class CharacterCameraEcs : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private CharacterData _characterData;

        private void Start() => SetTarget();

        private void SetTarget()
        {
            _camera.LookAt = _characterData._iPlayer.PlayerTransform.transform;
            _camera.Follow = _characterData._iPlayer.PlayerTransform.transform;
        }
    }
}