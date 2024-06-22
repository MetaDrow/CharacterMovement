using Platformer.Character;
using UnityEngine;

namespace Platformer.Ecs
{
    [CreateAssetMenu(menuName = "Scriptable Object/Player Input Ecs")]
    public class PlayerInputSO : ScriptableObject
    {
        [SerializeField] private GameInputReader _gameInputReader;
        [SerializeField] private CharacterData _characterData;

        public void OnEnable()
        {
            _gameInputReader.MoveEvent += HandleMove;
            _gameInputReader.JumpEvent += HandleJump;
            _gameInputReader.RollEvent += HandleRoll;
        }

        public void OnDisable()
        {
            _gameInputReader.MoveEvent -= HandleMove;
            _gameInputReader.JumpEvent -= HandleJump;
            _gameInputReader.RollEvent -= HandleRoll;
        }

        public void HandleMove(Vector2 input) => _characterData._direction = input;

        public void HandleJump() => _characterData._isJump = true;

        public void HandleRoll() => _characterData._isRoll = true;
    }
}