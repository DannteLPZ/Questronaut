using Questronaut.StateMachine;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerJump : State
    {
        [SerializeField] private float _jumpSpeed;
        public float JumpSpeed => _jumpSpeed;
        public override void EnterState()
        {
            _characterAnimator.Play(_stateAnimation.name);
            _characterAnimator.speed = 0.0f;

            _characterRb.linearVelocity = new Vector2(_characterRb.linearVelocityX, _jumpSpeed);
        }

        public override void UpdateState()
        {
            float animationTime = Helper.MapValue(_characterRb.linearVelocityY, _jumpSpeed, -_jumpSpeed, 0.0f, 1.0f, true);
            _characterAnimator.Play(_stateAnimation.name, 0, animationTime);
            if (_input.IsGrounded == true)
                IsComplete = true;
        }

        public override void ExitState()
        {
            _characterAnimator.speed = 1.0f;
        }
    }
}
