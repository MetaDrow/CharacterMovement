using UnityEngine;
using CharacterStateMachine;

internal class JumpState : State
{
    float _finalJumppos;
    protected internal JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _character._isJump = true;
        _character._animator.SetBool("Jump", true);
        _character._gravityVelocity.y = _character._gravityValue;
        _finalJumppos = (_character.transform.position.y + _character._jumpHeight);
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

        _character._input = _runAction.ReadValue<Vector2>();
        _character._direction = _character._input;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Debug.Log("on jumpstate");
        _character._velocity = new Vector3(_character._direction.x * _character._jumpLength, _character._gravityVelocity.y);
        _character._characterController.Move(_character._velocity * Time.fixedDeltaTime);

        if (_character.transform.position.y >= _finalJumppos)
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

        if (_jumpAction.triggered && _character._jumpCount < _character._jumpAmount)
        {
            _stateMachine.ChangeState(_character._jumpState);
            _character._jumpCount++;
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
        _character._jumpCount++;
    }
}

