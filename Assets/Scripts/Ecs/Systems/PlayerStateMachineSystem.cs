using Leopotam.Ecs;
using CharacterFiniteStateMachine;

namespace Platformer.Ecs
{
    public class PlayerStateMachineSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<Player> _playerInputDataFilter;
        private Player _player;

        public void Init()
        {
            foreach (var player in _playerInputDataFilter)
            {
                ref var playerPrefab = ref _playerInputDataFilter.Get1(player);
                _player = playerPrefab;
            }

            CharacterStateMachine stateMachine = new CharacterStateMachine();
            _player.Data._stateMachine = stateMachine;

            StandingState standingState = new StandingState(_player, _player.Data._stateMachine);
            _player.Data._standingState = standingState;

            GroundState groundState = new GroundState(_player, _player.Data._stateMachine);
            _player.Data._groundState = groundState;

            JumpState jumpState = new JumpState(_player, _player.Data._stateMachine);
            _player.Data._jumpState = jumpState;

            RunState runState = new RunState(_player, _player.Data._stateMachine);
            _player.Data._runState = runState;

            AirState airState = new AirState(_player, _player.Data._stateMachine);
            _player.Data._airState = airState;

            RollState rollState = new RollState(_player, _player.Data._stateMachine);
            _player.Data._rollState = rollState;

            WallState wallState = new WallState(_player, _player.Data._stateMachine);
            _player.Data._wallState = wallState;

            _player.Data._stateMachine.Initialize(groundState);
        }

        public void Run()
        {
            _player.Data._stateMachine._currentState.LogicUpdate();
            _player.Data._stateMachine._currentState.PhysicsUpdate();
            _player.Data._stateMachine._currentState.HandleInput();
        }
    }
}