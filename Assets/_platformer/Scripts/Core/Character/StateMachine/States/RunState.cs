using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    public class RunState : CharacterState
    {
        public RunState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            _character.Data._isRun = true;
            _character.Data._gravityVelocity.y = _character.Data._gravityValue;

        }

        public override void HandleInput()
        {
            _character.Data._currentAnimationBlendVector = Vector2.LerpUnclamped(_character.Data._currentAnimationBlendVector, _character.Data._direction, _character.Data._acceleration);
            _character.Animator.SetFloat("Direction", _character.Data._currentAnimationBlendVector.x);
        }

        public override void Exit()
        {
            _character.Data._isRun = false;
            _character.Data._gravityVelocity = Vector2.zero;
        }
        public override void LogicUpdate()
        {



            if (_character.Data._isWall)
            {
                _stateMachine.ChangeState(_character.Data._wallState);
            }

            if (!_character.Data._isGrounded)
            {
                _stateMachine.ChangeState(_character.Data._airState);
            }

            if (_character.Data._isJump)
            {
                _stateMachine.ChangeState(_character.Data._jumpState);
            }

            if (_character.Data._isRoll)
            {
                _stateMachine.ChangeState(_character.Data._rollState);
            }

            if (_character.Data._direction.x != 0 && _character.Data._isGrounded == true)
            {
                _character.CharacterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character.Data._direction.x, 0, 0));
            }

            if (_character.Data._direction.x == 0)
            {
                _stateMachine.ChangeState(_character.Data._standingState);
            }

        }

        public override void PhysicsUpdate()
        {
            if (_character.Data._currentSpeed < _character.Data._maxSpeed && _character.Data._direction.x != 0)
            {
                _character.Data._currentSpeed += _character.Data._acceleration;
            }

            _character.Data._velocity = new Vector2(_character.Data._direction.x * _character.Data._currentSpeed, _character.Data._gravityVelocity.y);
            _character.CharacterController.Move(_character.Data._velocity * Time.fixedDeltaTime);
        }
    }
}




