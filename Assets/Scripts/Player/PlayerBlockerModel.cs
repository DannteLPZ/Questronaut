using Questronaut.GameFlow;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerBlockerModel : MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine _playerStateMachine;

        public static PlayerBlockerModel Instance;

        private bool _isBlocked;
        public bool IsBlocked => _isBlocked;

        private bool _isBlockedByPause;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            GameFlowManager.Instance.OnPausedToggled += CheckPause;
        }

        private void OnDestroy()
        {
            GameFlowManager.Instance.OnPausedToggled -= CheckPause;
        }

        public void BlockPlayer(bool blockByPause = false)
        {
            if (_isBlocked == true)
                return;
            _playerStateMachine.BlockPlayer();
            _isBlocked = true;
            _isBlockedByPause = blockByPause;
        }

        public void UnblockPlayer()
        {
            _playerStateMachine.UnblockPlayer();
            _isBlocked = false;
        }

        private void CheckPause()
        {
            if(GameFlowManager.Instance.IsPaused == true)
                BlockPlayer(true);
            else if(_isBlockedByPause == true)
            {
                UnblockPlayer();
                _isBlockedByPause = false;
            }
        }
    }
}
