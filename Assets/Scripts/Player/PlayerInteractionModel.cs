using Questronaut.Interaction;
using System;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerInteractionModel : MonoBehaviour
    {
        public event Action OnInteractableFound;
        public event Action OnInteractableLost;

        private IInteractable _currentInteractable;
        public IInteractable CurrentInteractable => _currentInteractable;

        public static PlayerInteractionModel Instance;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Interact()
        {
            _currentInteractable?.Interact();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.TryGetComponent(out _currentInteractable);
            OnInteractableFound?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            collision.TryGetComponent(out IInteractable interactable);
            if(interactable != null && interactable == _currentInteractable)
            {
                OnInteractableLost?.Invoke();
                _currentInteractable = null;
            }
        }
    }
}
