using UnityEngine;
using CharacterStateMachine;
internal class RunState : State
{
    public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _character._gravityVelocity.y = _character._gravityValue;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        _character._input = _runAction.ReadValue<Vector2>();
        _character._direction = _character._input;
        _character._currentAnimationBlendVector = Vector2.LerpUnclamped(_character._currentAnimationBlendVector, _character._input * _character._direction, _character._acceleration);
        _character._animator.SetFloat("Direction", _character._currentAnimationBlendVector.x);
    }

    public override void Exit()
    {
        base.Exit();

        _character._isRun = false;
        _character._gravityVelocity = Vector2.zero;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_character._isWall)
        {
            _stateMachine.ChangeState(_character._wallState);
        }

        if (!_character._isGrounded)
        {
            _stateMachine.ChangeState(_character._airState);
        }

        if (_jumpAction.triggered)
        {
            _stateMachine.ChangeState(_character._jumpState);
        }

        if (_character._direction.y != 0)
        {
            _stateMachine.ChangeState(_character._rollState);
        }

        if (_character._direction.x != 0)
        {
            _character._characterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character._direction.x, 0, 0));
        }

        if (_character._input.x == 0)
        {
            _stateMachine.ChangeState(_character._standingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.LogicUpdate();


        if (_character._currentSpeed < _character._maxSpeed && _character._direction.x != 0)
        {
            _character._currentSpeed += _character._acceleration;
        }

        _character._velocity = new Vector2(_character._direction.x * _character._currentSpeed, _character._gravityVelocity.y);
        _character._characterController.Move(_character._velocity * Time.fixedDeltaTime);
    }
}


