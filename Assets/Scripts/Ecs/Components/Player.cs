using Platformer.Character;
using UnityEngine;

namespace Platformer.Ecs
{
    public struct Player : IPlayer
    {
        public Transform PlayerTransform { get; set; }
        public Animator Animator { get; set; }
        public CharacterController CharacterController { get; set; }
        public CharacterData Data { get; set; }
    }
}