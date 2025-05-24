using Questronaut.StateMachine;
using System.Linq;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerStateMachine : CharacterStateMachine, IInput
    {
        [Header("Player Movement")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundMask;

        private float _xInput;
        public float XInput => _xInput;

        private bool _isGrounded;
        public bool IsGrounded => _isGrounded;

        private State _idleState;
        private State _walkState;
        private State _jumpState;

        protected override void SetupStates()
        {
            foreach (State state in _allStates)
                state.Setup(_characterRb, _characterAnimator, this);

            _idleState = _allStates.FirstOrDefault(t => t is PlayerIdle);
            _walkState = _allStates.FirstOrDefault(t => t is PlayerWalk);
            _jumpState = _allStates.FirstOrDefault(t => t is PlayerJump);

            _currentState = _idleState;
        }

        private void Update()
        {
            _xInput = Input.GetAxis("Horizontal");

            if (_currentState.IsComplete == true)
                SelectState();

            _currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundMask);
        }

        protected override void SelectState()
        {
            switch (_currentState)
            {
                case PlayerIdle:
                    if (_isGrounded == true)
                        ChangeState(_walkState);
                    else
                        ChangeState(_jumpState);
                    break;
                case PlayerWalk:
                    if(_isGrounded == true)
                        ChangeState(_idleState);
                    else
                        ChangeState(_jumpState);
                    break;
                case PlayerJump:
                        ChangeState(_idleState);
                    break;
            }
        }

        
    }
}
