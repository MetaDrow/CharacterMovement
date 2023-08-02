using UnityEngine;
using CharacterStateMachine;

internal class WallState : State
{
    private float _slideForce;
    private int _autoSlideTime = 50;
    internal WallState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _character._isWall = true;
        _character._jumpCount = 0;
        _character._animator.SetBool("Wall", true);
        _character._gravityVelocity.y = _character._gravityValue;
        _slideForce = -5f;
    }
    public override void Exit()
    {
        base.Exit();
        _character._isWall = false;
        _autoSlideTime = 50;
        _character._animator.SetBool("Wall", false);
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _character._direction = _character._input;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        AutoSlideTimer();

        if (_character._velocity.x != _character._direction.x * _character._maxSpeed)
        {
            _character._velocity.x = _character._direction.x * _character._maxSpeed;
        }

        if (_character._direction.y < 0)
        {
            Slide();
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_character._isJump)
        {
            _stateMachine.ChangeState(_character._jumpState);
        }
    }

    void Slide()
    {
        
        if (!_character._isWall && !_character._isJump)
        {
            _stateMachine.ChangeState(_character._groundState);
        }
        
        _character._velocity = new Vector3(0, _character._direction.y * _character._maxSpeed);
        _character._characterController.Move(_character._velocity * Time.fixedDeltaTime);
    }

    void SlideDown()
    {
        if (_character._isWall && !_character._isJump)
        {
            _character._velocity = new Vector3(0, _slideForce);
            _character._characterController.Move(_character._velocity * Time.fixedDeltaTime);
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

