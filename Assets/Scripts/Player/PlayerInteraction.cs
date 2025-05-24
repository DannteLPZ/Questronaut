using Questronaut.Interaction;
using UnityEngine;

namespace Questronaut.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private IInteractable _currentInteractable;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) == true)
                _currentInteractable?.Interact();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.TryGetComponent(out _currentInteractable);
            if (_currentInteractable != null)
                _currentInteractable.ShowInteraction();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            collision.TryGetComponent(out IInteractable interactable);
            if(interactable != null && interactable == _currentInteractable)
            {
                _currentInteractable.HideInteraction();
                _currentInteractable = null;
            }
        }
    }
}
