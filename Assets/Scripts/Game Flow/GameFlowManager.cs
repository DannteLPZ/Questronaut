using Questronaut.Inventory;
using Questronaut.Player;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Questronaut.GameFlow
{
    public class GameFlowManager : MonoBehaviour
    {
        public event Action OnPausedToggled;

        public static GameFlowManager Instance;

        private bool _isPaused;
        public bool IsPaused => _isPaused;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void TogglePause()
        {
            _isPaused = !_isPaused;
            OnPausedToggled?.Invoke();
        }
    }
}
