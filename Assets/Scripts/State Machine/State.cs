using UnityEngine;

namespace Questronaut.StateMachine
{
    public class State : MonoBehaviour
    {
        [SerializeField] protected AnimationClip _stateAnimation;

        public bool IsComplete { get; protected set; }

        protected float _startTime;
        public float Runtime => Time.time - _startTime;

        protected Rigidbody2D _characterRb;
        protected Animator _characterAnimator;
        protected IInput _input;

        public void Setup(Rigidbody2D characterRb, Animator characterAnimator, IInput input)
        {
            _characterRb = characterRb;
            _characterAnimator = characterAnimator;
            _input = input;
        }

        public void InitializeState()
        {
            IsComplete = false;
            _startTime = Time.time;
        }

        public virtual void EnterState() { }
        public virtual void UpdateState() { }
        public virtual void FixedUpdateState() { }
        public virtual void ExitState() { }
    }

    public interface IInput
    {
        public float XInput { get; }
        public bool IsGrounded {  get; }
        public bool KeyDown(KeyCode key) => Input.GetKeyDown(key);
    }
}
