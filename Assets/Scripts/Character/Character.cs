using UnityEngine;
using CharacterFiniteStateMachine;

namespace Platformer.Character
{
    public class Character : MonoBehaviour, IDamagable
    {
        [SerializeField] internal CharacterData _characterData;
        internal CharacterController _characterController;
        internal CharacterStateMachine _stateMachine;
        internal Animator _animator;

        #region  State 
        internal StandingState _standingState;
        internal GroundState _groundState;
        internal ClimbState _climbState;
        internal DeathState _deathState;
        internal JumpState _jumpState;
        internal WallState _wallState;
        internal RollState _rollState;
        internal RunState _runState;
        internal AirState _airState;
        #endregion

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private protected void Start()
        {
            #region  StateMachine Initialization
            _stateMachine = new CharacterFiniteStateMachine.CharacterStateMachine();

            _stateMachine.Initialize(new GroundState(this, _stateMachine));
            _standingState = new StandingState(this, _stateMachine);
            _groundState = new GroundState(this, _stateMachine);
            _jumpState = new JumpState(this, _stateMachine);
            _runState = new RunState(this, _stateMachine);
            _airState = new AirState(this, _stateMachine);
            _wallState = new WallState(this, _stateMachine);
            _climbState = new ClimbState(this, _stateMachine);
            _rollState = new RollState(this, _stateMachine);
            _deathState = new DeathState(this, _stateMachine);
            #endregion
        }

        private protected void Update()
        {
            _stateMachine._currentState.HandleInput();
            _stateMachine._currentState.LogicUpdate();
        }

        private protected void FixedUpdate()
        {
            _stateMachine._currentState.PhysicsUpdate();
        }

        public void TakeDamage(int entryDamage)
        {
            _characterData.Health.Value -= entryDamage;
        }
    }

}
