using UnityEngine;
using CharacterStateMachine;

internal class AirState : State
{
    internal AirState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _character._animator.SetBool("Jump", true);
    }

    public override void Exit()
    {
        base.Exit();
        _character._animator.SetBool("Jump", false);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        _character._input = _runAction.ReadValue<Vector2>();
        _character._direction = _character._input;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_jumpAction.triggered && _character._jumpCount < _character._jumpAmount)
        {
            _stateMachine.ChangeState(_character._jumpState);
            _character._jumpCount++;
        }

        if (_character._isCeiling)
        {
            _stateMachine.ChangeState(_character._airState);
        }

        if (_character._isGrounded)
        {
            _stateMachine.ChangeState(_character._groundState);
        }

        if (_character._isWallTop && _character._direction.x != 0)
        {
            _stateMachine.ChangeState(_character._climbState);
        }

        if (_character._direction.x != 0)
        {
            _character._characterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character._direction.x, 0, 0));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (_character._isWall)
        {
            _stateMachine.ChangeState(_character._wallState);
        }

        if (_character._gravityVelocity.y > _character._gravityValue)
        {
            _character._gravityVelocity.y += _character._gravityValue * _character._gravityScale * Time.fixedDeltaTime;
        }

        if ((_character._currentSpeed < _character._maxSpeed && _character._direction.x > 0f) || _character._currentSpeed < _character._maxSpeed && _character._direction.x < 0f)
        {
            _character._currentSpeed += _character._acceleration;
        }

        _character._velocity = new Vector2(_character._direction.x * _character._currentSpeed, _character._gravityVelocity.y);

        _character._characterController.Move(_character._velocity * Time.fixedDeltaTime);
    }
}

