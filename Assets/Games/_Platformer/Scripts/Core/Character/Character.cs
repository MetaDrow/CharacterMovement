using UnityEngine;
using CharacterFiniteStateMachine;

namespace Platformer.Character
{
    public class Character : MonoBehaviour, IDamagable, IPlayer
    {
        internal CharacterStateMachine _stateMachine;

        [SerializeField] internal protected CharacterData _characterData;

        public CharacterData Data
        {
            get
            {
                return _characterData;
            }

            set
            {
                value = _characterData;

            }
        }
        public CharacterController CharacterController { get; set; }
        public Animator Animator { get; set; }
        public Transform PlayerTransform { get; set; }


        private void Awake()
        {
            PlayerTransform = this.transform;
            CharacterController = GetComponent<CharacterController>();
            Animator = GetComponent<Animator>();
        }

        private protected void Start()
        {
            #region  StateMachine Initialization
            _stateMachine = new CharacterStateMachine();

            _stateMachine.Initialize(new GroundState(this, _stateMachine));
            Data._standingState = new StandingState(this, _stateMachine);
            Data._groundState = new GroundState(this, _stateMachine);
            Data._jumpState = new JumpState(this, _stateMachine);
            Data._runState = new RunState(this, _stateMachine);
            Data._airState = new AirState(this, _stateMachine);
            Data._wallState = new WallState(this, _stateMachine);
            Data._climbState = new ClimbState(this, _stateMachine);
            Data._rollState = new RollState(this, _stateMachine);
            Data._deathState = new DeathState(this, _stateMachine);
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
            Data.Health.Value -= entryDamage;
        }
    }
}