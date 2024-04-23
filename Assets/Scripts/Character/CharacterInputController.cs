using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Input Reader")]
public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private GameInputReader _input;
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
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
        _character._characterData._isJump = true;
    }
    private void HandleRoll()
    {
        _character._characterData._isRoll = true;
    }

    private void HandleMove(Vector2 input)
    {
        _character._characterData._direction = input;
        _character._characterData._isRun = true;
    }
}
