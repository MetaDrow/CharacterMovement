using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    public class StandingState : CharacterState
    {
        public StandingState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {

        }

        public override void Enter()
        {
            _character.Data._isRun = false;
            _character.Data._currentAnimationBlendVector = Vector2.zero;
            _character.Data._currentSpeed = 0f;
            _character.Data._velocity = Vector3.zero;
            _character.Data._gravityVelocity = Vector3.zero;
        }

        public override void HandleInput()
        {

            _character.Animator.SetFloat("Direction", _character.Data._currentAnimationBlendVector.x);
        }

        public override void LogicUpdate()
        {
            if (!_character.Data._isGrounded)
            {
                _stateMachine.ChangeState(_character.Data._airState);
            }

            if (_character.Data._isRun)
            {
                _stateMachine.ChangeState(_character.Data._runState);
            }

            if (_character.Data._isJump)
            {
                _stateMachine.ChangeState(_character.Data._jumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            if (_character.Data._gravityVelocity.y != _character.Data._gravityValue)
            {
                _character.Data._gravityVelocity.y += _character.Data._gravityValue;
                
            }
            _character.CharacterController.Move(_character.Data._gravityVelocity * Time.fixedDeltaTime);

            if(_character.Data._direction.x != 0)
            {
                _character.Data._isRun = true;
            }
        }
    }
}