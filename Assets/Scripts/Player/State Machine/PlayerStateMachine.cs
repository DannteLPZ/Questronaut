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

        [Header("Sprite Renderer")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private float _xInput;
        public float XInput => _xInput;

        private bool _isGrounded;
        public bool IsGrounded => _isGrounded;

        private bool _hasJumped;

        private PlayerIdle _idleState;
        private PlayerWalk _walkState;
        private PlayerJump _jumpState;

        protected override void SetupStates()
        {
            foreach (State state in _allStates)
                state.Setup(_characterRb, _characterAnimator, this);

            _idleState = (PlayerIdle)_allStates.FirstOrDefault(t => t is PlayerIdle);
            _walkState = (PlayerWalk)_allStates.FirstOrDefault(t => t is PlayerWalk);
            _jumpState = (PlayerJump)_allStates.FirstOrDefault(t => t is PlayerJump);

            _currentState = _idleState;
        }

        private void Update()
        {
            CheckInput();

            if (_currentState.IsComplete == true)
                SelectState();

            _currentState.UpdateState();
        }

        private void CheckInput()
        {
            _xInput = Input.GetAxis("Horizontal");

            if (_xInput > 0.1f)
                _spriteRenderer.flipX = false;
            else if (_xInput < -0.1)
                _spriteRenderer.flipX = true;


            if (((IInput)this).KeyDown(KeyCode.Space) == true && _isGrounded == true)
                _hasJumped = true;
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundMask);

            _characterRb.linearVelocityX = _xInput * _walkState.MoveSpeed;
            if(_hasJumped == true)
            {
                _characterRb.linearVelocityY = _jumpState.JumpSpeed;
                _hasJumped = false;
            }
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
