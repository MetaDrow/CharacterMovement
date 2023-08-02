using UnityEngine;

[RequireComponent(typeof(Character))]
public class InputController : MonoBehaviour
{
    [SerializeField] private GameInputReaderSO _input;
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        _input.JumpEvent += HandleJump;
        _input.MovementEvent += HandleMove;
        _input.RollEvent += HandleRoll;

    }

    private void OnDisable()
    {
        _input.JumpEvent -= HandleJump;
        _input.MovementEvent -= HandleMove;
        _input.RollEvent -= HandleRoll;

    }
    private void HandleJump()
    {
        _character._isJump = true;
    }
    private void HandleRoll()
    {
        _character._isRoll = true;
    }

    private void HandleMove(Vector2 input)
    {
        _character._input = input;
        _character._isRun = true;
    }
}
