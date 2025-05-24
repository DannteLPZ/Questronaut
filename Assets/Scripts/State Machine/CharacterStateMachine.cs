using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Questronaut.StateMachine
{
    public abstract class CharacterStateMachine : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] protected Rigidbody2D _characterRb;
        [SerializeField] protected Animator _characterAnimator;

        protected List<State> _allStates = new();
        protected State _currentState;

        protected virtual void Awake()
        {
            _allStates = GetComponentsInChildren<State>().ToList();
            SetupStates();
        }

        protected abstract void SetupStates();
        protected abstract void SelectState();

        public void ChangeState(State newState)
        {
            if (newState != _currentState || _currentState.IsComplete == true)
            {
                if(_currentState != null)
                    _currentState.ExitState();
                _currentState = newState;
                _currentState.InitializeState();
                _currentState.EnterState();
            }
        }
    }
}
