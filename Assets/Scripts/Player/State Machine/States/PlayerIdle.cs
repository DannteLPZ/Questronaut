using Questronaut.StateMachine;

namespace Questronaut.Player
{
    public class PlayerIdle : State
    {
        public override void EnterState()
        {
            _characterAnimator.Play(_stateAnimation.name);
        }

        public override void UpdateState()
        {
            if(_input.IsGrounded == false || _input.XInput != 0.0f)
                IsComplete = true;
        }
    }
}
