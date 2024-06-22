using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    public class WallState : CharacterState
    {
        private float _slideForce;
        private int _autoSlideTime = 50;
        public WallState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            _character.Data._isWall = true;
            _character.Data._jumpCount = 0;
            _character.Animator.SetBool("Wall", true);
            _character.Data._gravityVelocity.y = _character.Data._gravityValue;
            _slideForce = -5f;
        }
        public override void Exit()
        {
            _character.Data._isWall = false;
            _autoSlideTime = 50;
            _character.Animator.SetBool("Wall", false);
        }

        public override void LogicUpdate()
        {

            if (_character.Data._direction.y < 0)
            {
                Slide();
            }

            if (_character.Data._isJump)
            {
                _stateMachine.ChangeState(_character.Data._jumpState);
            }
        }

        void Slide()
        {
            if (!_character.Data._isWall && !_character.Data._isJump)
            {
                _stateMachine.ChangeState(_character.Data._groundState);
            }

            _character.Data._velocity = new Vector3(0, _character.Data._direction.y * _character.Data._maxSpeed);
            _character.CharacterController.Move(_character.Data._velocity * Time.fixedDeltaTime);
        }

        void SlideDown()
        {
            if (_character.Data._isWall && !_character.Data._isJump)
            {
                _character.Data._velocity = new Vector3(0, _slideForce);
                _character.CharacterController.Move(_character.Data._velocity * Time.fixedDeltaTime);
            }
            else
            {
                _stateMachine.ChangeState(_character.Data._groundState);
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
}