using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{

    public class AirState : CharacterState
    {
        public AirState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {

            _character.Animator.SetBool("Jump", true);
        }

        public override void Exit()
        {
            _character.Animator.SetBool("Jump", false);
        }

        public override void LogicUpdate()
        {

            if (_character.Data._isJump && _character.Data._jumpCount != _character.Data._jumpAmount)
            {
                _stateMachine.ChangeState(_character.Data._jumpState);
            }

            if (_character.Data._isCeiling)
            {
                _stateMachine.ChangeState(_character.Data._airState);
            }

            if (_character.Data._isGrounded)
            {
                _stateMachine.ChangeState(_character.Data._groundState);
            }

            if (_character.Data._isWallTop && _character.Data._direction.x != 0)
            {
                _stateMachine.ChangeState(_character.Data._climbState);
            }

            if (_character.Data._direction.x != 0)
            {
                _character.CharacterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character.Data._direction.x, 0, 0));
            }
        }

        public override void PhysicsUpdate()
        {

            if (_character.Data._isWall)
            {
                _stateMachine.ChangeState(_character.Data._wallState);
            }

            if (_character.Data._gravityVelocity.y > _character.Data._gravityValue)
            {
                _character.Data._gravityVelocity.y += _character.Data._gravityValue * _character.Data._gravityScale * Time.fixedDeltaTime;
            }

            if ((_character.Data._currentSpeed < _character.Data._maxSpeed && _character.Data._direction.x > 0f) || _character.Data._currentSpeed < _character.Data._maxSpeed && _character.Data._direction.x < 0f)
            {
                _character.Data._currentSpeed += _character.Data._acceleration;
            }

            _character.Data._velocity = new Vector2(_character.Data._direction.x * _character.Data._currentSpeed, _character.Data._gravityVelocity.y);
            _character.CharacterController.Move(_character.Data._velocity * Time.fixedDeltaTime);
        }
    }

}