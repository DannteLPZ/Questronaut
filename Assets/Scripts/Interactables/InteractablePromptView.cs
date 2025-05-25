using Questronaut.Player;
using UnityEngine;

namespace Questronaut.Interaction
{
    public class InteractablePromptView : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionIcon;
        private IInteractable _interactable;
        private PlayerInteractionModel InteractionModel => PlayerInteractionModel.Instance;

        private void Awake()
        {
            _interactable = GetComponent<IInteractable>();
        }

        private void Start()
        {
            InteractionModel.OnInteractableFound += CheckView;
            InteractionModel.OnInteractableLost += HideView;
        }

        private void OnDestroy()
        {
            InteractionModel.OnInteractableFound -= CheckView;
            InteractionModel.OnInteractableLost -= HideView;
        }

        private void CheckView()
        {
            if(InteractionModel.CurrentInteractable == _interactable)
                _interactionIcon.SetActive(true);
        }

        private void HideView()
        {
            if (InteractionModel.CurrentInteractable == _interactable)
                _interactionIcon.SetActive(false);
        }

    }
}
