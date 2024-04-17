using System;
using UnityEngine;
using CharacterStateMachine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
internal class Character : MonoBehaviour
{
    protected internal CharacterController _characterController;
    protected internal StateMachine _stateMachine;
    protected internal Animator _animator;

    #region  Field
    [Header("Movement Parameters")]
    [SerializeField, Range(0, 1)] protected internal float _acceleration;
    [SerializeField, Range(0, 15)] protected internal float _maxSpeed;
    [SerializeField, Range(0, 5)] protected internal float _rollLength;
    [SerializeField, Range(0, 20)] protected internal float _rollForce;
    [SerializeField, Range(0, 10)] protected internal int _rollTime;
    [SerializeField] protected internal float _currentSpeed;
    [SerializeField] protected internal float _climbForceY;
    [SerializeField] protected internal float _climbForceX;


    [SerializeField] protected internal Vector2 _gravityVelocity;
    [SerializeField] protected internal Vector2 _direction;
    [SerializeField] protected internal Vector2 _velocity;
    [SerializeField] protected internal Vector2 _wallClimb;
    [SerializeField] internal protected Vector2 _input;
    protected internal Vector2 _currentAnimationBlendVector;


    [SerializeField] protected internal bool _isGrounded;
    [SerializeField] protected internal bool _isWallTop;
    [SerializeField] protected internal bool _isWall;
    [SerializeField] protected internal bool _isCeiling;
    [SerializeField] protected internal bool _isRun;
    [SerializeField] protected internal bool _isRoll;

    [Header("Jump Parameters")]
    [SerializeField, Range(-30, 0)] protected internal float _gravityValue = -9.81f;
    [SerializeField, Range(0, 30)] protected internal float _jumpForce;
    [SerializeField, Range(0, 10)] protected internal float _gravityScale;
    [SerializeField, Range(0, 3)] protected internal float _jumpHeight;
    [SerializeField, Range(0, 10)] protected internal float _jumpLength;
    [SerializeField] protected internal int _jumpAmount;
    [SerializeField] protected internal bool _isJump;
    [SerializeField] protected internal int _jumpCount;



    #region  State 
    protected internal StandingState _standingState;
    protected internal GroundState _groundState;
    protected internal JumpState _jumpState;
    protected internal RunState _runState;
    protected internal AirState _airState;
    protected internal WallState _wallState;
    protected internal ClimbState _climbState;
    protected internal RollState _rollState;
    protected internal DeathState _deathState;
    #endregion


    #endregion
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private protected void Start()
    {
        _stateMachine = new StateMachine();

        #region  StateMachine Initialization
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
}
