using Questronaut.StateMachine;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerWalk : State
    {
        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
        public override void EnterState()
        {
            _characterAnimator.Play(_stateAnimation.name);
        }

        public override void UpdateState()
        {
            _characterAnimator.speed = Helper.MapValue(_moveSpeed, 0.0f, 1.0f, 0.0f, 3.0f, true);

            if (_input.IsGrounded == false || _input.XInput == 0.0f)
                IsComplete = true;
        }

        public override void ExitState()
        {
            _characterAnimator.speed = 1.0f;
        }
    }
}
