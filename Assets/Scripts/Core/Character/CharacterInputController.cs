using UnityEngine;
using Platformer.Character;

public class CharacterInputController : MonoBehaviour
{
    private GameInputReader _input;
    private IPlayer _character;

    private void Awake()
    {
        _input = new GameInputReader();
        _character = GetComponent<IPlayer>();
    }

    private void OnEnable()
    {
        _input.JumpEvent += HandleJump;
        _input.MoveEvent += HandleMove;
        _input.RollEvent += HandleRoll;
    }

    private void OnDisable()
    {
        _input.JumpEvent -= HandleJump;
        _input.MoveEvent -= HandleMove;
        _input.RollEvent -= HandleRoll;

    }
    private void HandleJump()
    {
        _character.Data._isJump = true;
    }
    private void HandleRoll()
    {
        _character.Data._isRoll = true;
    }

    private void HandleMove(Vector2 input)
    {
        _character.Data._direction = input;
        //_character._data._isRun = true;
    }
}