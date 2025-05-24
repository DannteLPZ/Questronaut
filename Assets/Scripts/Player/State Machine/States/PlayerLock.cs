using Questronaut.StateMachine;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerLock : State
    {
        private Vector2 _currentVelocity;
        public override void EnterState()
        {
            _characterAnimator.speed = 0.0f;
            _currentVelocity = _characterRb.linearVelocity;
            _characterRb.linearVelocity = Vector2.zero;
            _characterRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void ExitState()
        {
            _characterAnimator.speed = 1.0f;
            _characterRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            _characterRb.linearVelocity = _currentVelocity;
        }
    }
}
