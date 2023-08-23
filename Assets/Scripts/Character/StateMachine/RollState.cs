using UnityEngine;
using CharacterStateMachine;

internal class RollState : State
{
    private int _rollStateTime;
    public RollState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        _character._animator.SetBool("Roll", true);
        _character._isRoll = true;
        _rollStateTime = _character._rollTime;
    }
    public override void HandleInput()
    {
        _character._direction = _character._input;
    }
    public override void Exit()
    {
        _character._rollTime = _rollStateTime;
        _character._isRoll = false;
        _character._animator.SetBool("Roll", false);
        _character._characterController.height = 1.15f;
        _character._characterController.center = new Vector3(0, 0.7f, 0);

    }

    public override void LogicUpdate()
    {
        RollTime();

        if (_character._isRoll && _character._rollTime != 0)
        {
            _character._characterController.height = 0.5f;
            _character._characterController.center = new Vector3(0, 0.3f, 0);
        }
    }

    public override void PhysicsUpdate()
    {
        _character._velocity = new Vector3(_character._direction.x * _character._rollForce, _character._gravityVelocity.y);
        _character._characterController.Move(_character._velocity * Time.fixedDeltaTime);
    }

    void RollTime()
    {
        if (_character._rollTime != 0)
        {
            _character._rollTime--;
        }
        else
        {
            _stateMachine.ChangeState(_character._runState);
        }
    }
}

