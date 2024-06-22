using UnityEngine;

namespace Platformer.Character
{
    public interface IPlayer
    {
        public Transform PlayerTransform { get; set; }
        public Animator Animator { get; set; }
        public CharacterController CharacterController { get; set; }
        public CharacterData Data { get; set; }
    }
}