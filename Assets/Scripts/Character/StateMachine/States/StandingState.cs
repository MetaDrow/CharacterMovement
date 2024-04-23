using UnityEngine;
using CharacterFiniteStateMachine;
internal class StandingState : CharacterState
{
    protected internal StandingState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override void Enter()
    {
        _character._characterData._isRun = false;
        _character._characterData._currentAnimationBlendVector = Vector2.zero;
        _character._characterData._currentSpeed = 0f;
        _character._characterData._velocity = Vector3.zero;
        _character._characterData._gravityVelocity = Vector3.zero;
    }

    public override void HandleInput()
    {

        _character._animator.SetFloat("Direction", _character._characterData._currentAnimationBlendVector.x);
    }

    public override void LogicUpdate()
    {
        if (!_character._characterData._isGrounded)
        {
            _stateMachine.ChangeState(_character._airState);
        }

        if (_character._characterData._isRun)
        {
            _stateMachine.ChangeState(_character._runState);
        }

        if (_character._characterData._isJump)
        {
            _stateMachine.ChangeState(_character._jumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        if (_character._characterData._gravityVelocity.y != _character._characterData._gravityValue)
        {
            _character._characterData._gravityVelocity.y += _character._characterData._gravityValue;
        }
        _character._characterController.Move(_character._characterData._gravityVelocity * Time.fixedDeltaTime);
    }
}

