using Leopotam.Ecs;
using Platformer.Character;
using UnityEngine;

namespace Platformer.Ecs
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private CharacterData _characterData;
        private SceneData _sceneData;

        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();
            ref var player = ref playerEntity.Get<Player>();

            GameObject playerGO = Object.Instantiate(_characterData._playerPrefab, _sceneData._playerSpawnPoint.position, Quaternion.Euler(0, 90, 0));

            var playerPrefabAnimator = playerGO.GetComponent<Animator>();
            var playerPrefabCharacterController = playerGO.GetComponent<CharacterController>();

            player.Animator = playerPrefabAnimator;
            player.CharacterController = playerPrefabCharacterController;
            player.Data = _characterData;
            player.PlayerTransform = playerGO.transform;
            player.Data._iPlayer = player;
        }
    }
}