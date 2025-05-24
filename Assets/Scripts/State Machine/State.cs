using UnityEngine;

namespace Questronaut.StateMachine
{
    public class State : MonoBehaviour
    {
        [SerializeField] protected AnimationClip _stateAnimation;
        protected Rigidbody2D _characterRb;
        protected Animator _characterAnimator;

        public void Setup(Rigidbody2D rigidbody2D, Animator animator)
        {
            _characterRb = rigidbody2D;
            _characterAnimator = animator;
        }

        public virtual void OnStateEnter()
        {
            if (_stateAnimation != null)
                _characterAnimator.Play(_stateAnimation.name);
        }
        public virtual void OnStateUpdate() { }
        public virtual void OnStateFixedUpdate() { }
        public virtual void OnStateExit() { }
    }
}
