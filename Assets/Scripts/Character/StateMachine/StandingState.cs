using UnityEngine;
using CharacterStateMachine;
internal class StandingState : State
{
    protected internal StandingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _character._isRun = false;
        _character._currentAnimationBlendVector = Vector2.zero;
        _character._currentSpeed = 0f;
        _character._velocity = Vector3.zero;
        _character._gravityVelocity = Vector3.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _character._direction = _character._input;
        _character._animator.SetFloat("Direction", _character._currentAnimationBlendVector.x);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!_character._isGrounded)
        {
            _stateMachine.ChangeState(_character._airState);
        }

        if (_character._isRun)
        {
            _stateMachine.ChangeState(_character._runState);
        }

        if (_character._isJump)
        {
            _stateMachine.ChangeState(_character._jumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (_character._gravityVelocity.y != _character._gravityValue)
        {
            _character._gravityVelocity.y += _character._gravityValue;
        }
        _character._characterController.Move(_character._gravityVelocity * Time.fixedDeltaTime);
    }
}

