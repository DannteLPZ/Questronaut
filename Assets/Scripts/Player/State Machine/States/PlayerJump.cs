using Questronaut.StateMachine;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerJump : State
    {
        [SerializeField] private float _jumpSpeed;
        public override void EnterState()
        {
            _characterAnimator.Play(_stateAnimation.name);
            _characterRb.linearVelocity = new Vector2(_characterRb.linearVelocityX, _jumpSpeed);
        }

        public override void UpdateState()
        {
            if (_input.IsGrounded == true || _characterRb.linearVelocityY <= 0.0f)
                IsComplete = true;
        }
    }
}
