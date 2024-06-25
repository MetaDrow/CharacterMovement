using Leopotam.Ecs;
using Platformer.Ecs;
using UnityEngine;

namespace Platformer.Ecs
{
    public class PlayerCameraInitSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        public void Init()
        {
            GameObject camera = Object.Instantiate(_sceneData._playerCamera, _sceneData._playerSpawnPoint.position, Quaternion.identity);
        }
    }
}