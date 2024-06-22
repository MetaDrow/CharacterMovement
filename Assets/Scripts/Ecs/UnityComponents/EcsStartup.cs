using Leopotam.Ecs;
using UnityEngine;
using Platformer.Character;

namespace Platformer.Ecs
{
    namespace Client
    {
        sealed class EcsStartup : MonoBehaviour
        {
            [SerializeField] private CharacterData _characterData;
            [SerializeField] private SceneData _sceneData;
            [SerializeField] private PlayerInputSO _playerInputSO;
            private EcsWorld _world;
            private EcsSystems _fixedUpdateSystem;

            void Start()
            {
                _world = new EcsWorld();
                _fixedUpdateSystem = new EcsSystems(_world);

                _fixedUpdateSystem
                    .Add(new PlayerInitSystem())
                    .Add(new PlayerStateMachineSystem())
                    .Add(new PlayerCameraInitSystem())
                    .Inject(_sceneData)
                    .Inject(_characterData)
                    .Inject(_playerInputSO)
                    .Init();

            }
            private void FixedUpdate() => _fixedUpdateSystem?.Run();

            void OnDestroy()
            {
                if (_fixedUpdateSystem != null)
                {
                    _fixedUpdateSystem.Destroy();
                    _fixedUpdateSystem = null;
                    _world.Destroy();
                    _world = null;
                }
            }
        }
    }
}