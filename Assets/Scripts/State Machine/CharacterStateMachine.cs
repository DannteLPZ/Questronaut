using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Questronaut.StateMachine
{
    public class CharacterStateMachine : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody2D _characterRb;
        [SerializeField] private Animator _characterAnimator;

        private List<State> _allStates = new();
        private State _currentState;


        private void Awake()
        {
            _allStates = GetComponentsInChildren<State>().ToList();
            foreach (State state in _allStates)
                state.Setup(_characterRb, _characterAnimator);
        }

        public void ChangeState(State newState, bool force = false)
        {
            if (newState != _currentState || force == true)
            {
                _currentState.OnStateExit();
                _currentState = newState;
                _currentState.OnStateEnter();
            }
        }
    }
}
