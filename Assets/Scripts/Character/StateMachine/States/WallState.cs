using UnityEngine;
using CharacterFiniteStateMachine;
internal class WallState : CharacterState
{
    private float _slideForce;
    private int _autoSlideTime = 50;
    internal WallState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        _character._characterData._isWall = true;
        _character._characterData._jumpCount = 0;
        _character._animator.SetBool("Wall", true);
        _character._characterData._gravityVelocity.y = _character._characterData._gravityValue;
        _slideForce = -5f;
    }
    public override void Exit()
    {
        _character._characterData._isWall = false;
        _autoSlideTime = 50;
        _character._animator.SetBool("Wall", false);
    }

    public override void HandleInput()
    {

    }

    public override void PhysicsUpdate()
    {
        AutoSlideTimer();

        if (_character._characterData._velocity.x != _character._characterData._direction.x * _character._characterData._maxSpeed)
        {
            _character._characterData._velocity.x = _character._characterData._direction.x * _character._characterData._maxSpeed;
        }

        if (_character._characterData._direction.y < 0)
        {
            Slide();
        }
    }
    public override void LogicUpdate()
    {

        if (_character._characterData._isJump)
        {
            _stateMachine.ChangeState(_character._jumpState);
        }
    }

    void Slide()
    {
        if (!_character._characterData._isWall && !_character._characterData._isJump)
        {
            _stateMachine.ChangeState(_character._groundState);
        }

        _character._characterData._velocity = new Vector3(0, _character._characterData._direction.y * _character._characterData._maxSpeed);
        _character._characterController.Move(_character._characterData._velocity * Time.fixedDeltaTime);
    }

    void SlideDown()
    {
        if (_character._characterData._isWall && !_character._characterData._isJump)
        {
            _character._characterData._velocity = new Vector3(0, _slideForce);
            _character._characterController.Move(_character._characterData._velocity * Time.fixedDeltaTime);
        }
        else
        {
            _stateMachine.ChangeState(_character._groundState);
        }
    }

    void AutoSlideTimer()
    {

        if (_autoSlideTime != 0)
        {
            _autoSlideTime--;
        }
        else
        {
            SlideDown();
        }
    }
}

