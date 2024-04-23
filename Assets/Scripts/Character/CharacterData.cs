using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Character Data")]
public class CharacterData : ScriptableObject
{
    public GameObject _currentPrefab;
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
}
