using UnityEngine;
using CharacterStateMachine;

internal class JumpState : State
{
    private float _jumpPossition;

    protected internal JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (_character._jumpCount < _character._jumpAmount)
        {
            _character._jumpCount++;
        }

        _character._animator.SetBool("Jump", true);

        _character._gravityVelocity.y = _character._gravityValue;


        _jumpPossition = (_character.transform.position.y + _character._jumpHeight);

        Jump();
    }

    public override void Exit()
    {
        base.Exit();
        _character._animator.SetBool("Jump", false);
        _character._isJump = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _character._direction = _character._input;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _character._velocity = new Vector3(_character._direction.x * _character._jumpLength, _character._gravityVelocity.y);

        _character._characterController.Move(_character._velocity * Time.fixedDeltaTime);

        if (_character.transform.position.y >= _jumpPossition)
        {
            _stateMachine.ChangeState(_character._airState);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        if (_character._direction.x != 0)
        {
            _character._characterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character._direction.x, 0, 0));
        }

        if (_character._isCeiling)
        {
            _stateMachine.ChangeState(_character._standingState);
        }

        if (_character._isWallTop && _character._direction.x != 0)
        {
            _stateMachine.ChangeState(_character._climbState);
        }
    }
    void Jump()
    {
        _character._gravityVelocity.y += Mathf.Sqrt(_character._jumpForce * -3f * _character._gravityValue);

    }
}

