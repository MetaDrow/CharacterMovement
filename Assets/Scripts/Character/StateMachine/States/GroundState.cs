using CharacterFiniteStateMachine;
internal class GroundState : CharacterState
{
    public GroundState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        _character._characterData._jumpCount = 0;
        _character._characterData._gravityVelocity.y = _character._characterData._gravityValue;
    }

    public override void PhysicsUpdate()
    {

        if (!_character._characterData._isGrounded)
        {
            _stateMachine.ChangeState(_character._airState);
        }

        if (_character._characterData._isGrounded && _character._characterData._direction.x != 0)
        {
            _stateMachine.ChangeState(_character._runState);
        }

        if (_character._characterData._isGrounded && _character._characterData._direction.x == 0)
        {
            _stateMachine.ChangeState(_character._standingState);
        }
    }
}

