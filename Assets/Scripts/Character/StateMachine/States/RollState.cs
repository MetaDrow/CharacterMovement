using UnityEngine;
using CharacterFiniteStateMachine;

internal class RollState : CharacterState
{
    private int _rollStateTime;
    public RollState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        _character._animator.SetBool("Roll", true);
        _character._characterData._isRoll = true;
        _rollStateTime = _character._characterData._rollTime;
    }
    public override void HandleInput()
    {

    }
    public override void Exit()
    {
        _character._characterData._rollTime = _rollStateTime;
        _character._characterData._isRoll = false;
        _character._animator.SetBool("Roll", false);
        _character._characterController.height = 1.15f;
        _character._characterController.center = new Vector3(0, 0.7f, 0);
    }

    public override void LogicUpdate()
    {
        RollTime();

        if (_character._characterData._isRoll && _character._characterData._rollTime != 0)
        {
            _character._characterController.height = 0.5f;
            _character._characterController.center = new Vector3(0, 0.3f, 0);
        }
    }

    public override void PhysicsUpdate()
    {
        _character._characterData._velocity = new Vector3(_character._characterData._direction.x * _character._characterData._rollForce, _character._characterData._gravityVelocity.y);
        _character._characterController.Move(_character._characterData._velocity * Time.fixedDeltaTime);
    }

    void RollTime()
    {
        if (_character._characterData._rollTime != 0)
        {
            _character._characterData._rollTime--;
        }
        else
        {
            _stateMachine.ChangeState(_character._runState);
        }
    }
}

