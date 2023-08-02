using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptsSO/InputReader")]
public class GameInputReaderSO : ScriptableObject, GameInput.IGameplayActions
{
    private GameInput _gameInput;

    public event Action<Vector2> MovementEvent;
    public event Action JumpEvent;
    public event Action RollEvent;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();

            _gameInput.Gameplay.SetCallbacks(this);

            SetGameplay();
        }
    }

    public void SetGameplay()
    {
        _gameInput.Gameplay.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            RollEvent?.Invoke();
        }
    }
}
