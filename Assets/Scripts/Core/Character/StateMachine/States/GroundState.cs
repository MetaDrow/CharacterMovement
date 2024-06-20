using Platformer.Character;
using UnityEngine;

namespace CharacterFiniteStateMachine
{
    public class GroundState : CharacterState
    {
        public GroundState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {

            _character.Data._jumpCount = 0;
            _character.Data._gravityVelocity.y = _character.Data._gravityValue;
        }

        public override void PhysicsUpdate()
        {

            if (!_character.Data._isGrounded)
            {
                _stateMachine.ChangeState(_character.Data._airState);
            }

            if (_character.Data._isGrounded && _character.Data._direction.x != 0)
            {
                _stateMachine.ChangeState(_character.Data._runState);
            }

            if (_character.Data._isGrounded && _character.Data._direction.x == 0)
            {
                _stateMachine.ChangeState(_character.Data._standingState);
            }
        }
    }
}