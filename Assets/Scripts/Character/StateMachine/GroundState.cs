using UnityEngine;
using CharacterStateMachine;

internal class GroundState : State
{
    public GroundState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _character._jumpCount = 0;
        _character._gravityVelocity.y = _character._gravityValue;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _character._input = _runAction.ReadValue<Vector2>();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!_character._isGrounded)
        {
            _stateMachine.ChangeState(_character._airState);
        }

        if (_character._isGrounded && _character._direction.x != 0)
        {
            _stateMachine.ChangeState(_character._runState);
        }

        if (_character._isGrounded && _character._direction.x == 0)
        {
            _stateMachine.ChangeState(_character._standingState);
        }
    }
}

