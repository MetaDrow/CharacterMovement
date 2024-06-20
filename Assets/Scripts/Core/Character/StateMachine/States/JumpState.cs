using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    public class JumpState : CharacterState
    {
        private float _jumpPosition;

        public  JumpState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            if (_character.Data._jumpCount < _character.Data._jumpAmount)
            {
                _character.Data._jumpCount++;
            }

            _character.Animator.SetBool("Jump", true);
            _character.Data._gravityVelocity.y = _character.Data._gravityValue;
            _jumpPosition = (_character.PlayerTransform.position.y + _character.Data._jumpHeight);
            Jump();
        }

        public override void Exit()
        {
            _character.Animator.SetBool("Jump", false);
            _character.Data._isJump = false;
        }



        public override void PhysicsUpdate()
        {
            _character.Data._velocity = new Vector3(_character.Data._direction.x * _character.Data._jumpLength, _character.Data._gravityVelocity.y);

            _character.CharacterController.Move(_character.Data._velocity * Time.fixedDeltaTime);

            if (_character.PlayerTransform.position.y >= _jumpPosition)
            {
                _stateMachine.ChangeState(_character.Data._airState);
            }
        }

        public override void LogicUpdate()
        {
            if (_character.Data._direction.x != 0)
            {
                _character.CharacterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character.Data._direction.x, 0, 0));
            }

            if (_character.Data._isCeiling)
            {
                _stateMachine.ChangeState(_character.Data._standingState);
            }

            if (_character.Data._isWallTop && _character.Data._direction.x != 0)
            {
                _stateMachine.ChangeState(_character.Data._climbState);
            }
        }
        void Jump()
        {
            _character.Data._gravityVelocity.y += Mathf.Sqrt(_character.Data._jumpForce * -3f * _character.Data._gravityValue);
        }
    }
}