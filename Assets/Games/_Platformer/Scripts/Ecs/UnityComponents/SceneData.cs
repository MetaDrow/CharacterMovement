using UnityEngine;

namespace Platformer.Ecs
{
    public class SceneData : MonoBehaviour
    {
        public Transform _playerSpawnPoint;
        public GameObject _playerCamera;
        public Transform _playerCameraPosition;
        public PlayerInputSO _playerInputSO;
    }
}