using Questronaut.Interaction;
using Questronaut.StateMachine;
using System;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerBlockerModel : MonoBehaviour
    {
        public event Action<bool> OnPlayerBlocked;

        [SerializeField] private PlayerStateMachine _playerStateMachine;
        [SerializeField] private PlayerInteractionController _playerInteractionController;

        public static PlayerBlockerModel Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void BlockPlayer()
        {
            _playerInteractionController.enabled = false;
            _playerStateMachine.BlockPlayer();
            OnPlayerBlocked?.Invoke(true);
        }

        public void UnblockPlayer()
        {
            _playerInteractionController.enabled = true;
            _playerStateMachine.UnblockPlayer();
            OnPlayerBlocked?.Invoke(false);
        }
    }
}
