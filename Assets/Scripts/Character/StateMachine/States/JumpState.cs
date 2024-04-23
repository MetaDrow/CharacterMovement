using UnityEngine;
using CharacterFiniteStateMachine;

internal class JumpState : CharacterState
{
    private float _jumpPossition;

    protected internal JumpState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        if (_character._characterData._jumpCount < _character._characterData._jumpAmount)
        {
            _character._characterData._jumpCount++;
        }

        _character._animator.SetBool("Jump", true);
        _character._characterData._gravityVelocity.y = _character._characterData._gravityValue;
        _jumpPossition = (_character.transform.position.y + _character._characterData._jumpHeight);
        Jump();
    }

    public override void Exit()
    {
        _character._animator.SetBool("Jump", false);
        _character._characterData._isJump = false;
    }

    public override void HandleInput()
    {
       // _character._characterData._direction = _character._input;
    }

    public override void PhysicsUpdate()
    {
        _character._characterData._velocity = new Vector3(_character._characterData._direction.x * _character._characterData._jumpLength, _character._characterData._gravityVelocity.y);

        _character._characterController.Move(_character._characterData._velocity * Time.fixedDeltaTime);

        if (_character.transform.position.y >= _jumpPossition)
        {
            _stateMachine.ChangeState(_character._airState);
        }
    }

    public override void LogicUpdate()
    {
        if (_character._characterData._direction.x != 0)
        {
            _character._characterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character._characterData._direction.x, 0, 0));
        }

        if (_character._characterData._isCeiling)
        {
            _stateMachine.ChangeState(_character._standingState);
        }

        if (_character._characterData._isWallTop && _character._characterData._direction.x != 0)
        {
            _stateMachine.ChangeState(_character._climbState);
        }
    }
    void Jump()
    {
        _character._characterData._gravityVelocity.y += Mathf.Sqrt(_character._characterData._jumpForce  * -3f * _character._characterData._gravityValue);
    }
}

