using Questronaut.Player;
using UnityEngine;

namespace Questronaut.Interaction
{
    public class PickeableItemView : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionIcon;
        private PickeableItemModel _itemModel;
        private PlayerInteractionModel InteractionModel => PlayerInteractionModel.Instance;

        private void Awake()
        {
            _itemModel = GetComponent<PickeableItemModel>();
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
            if(InteractionModel.CurrentInteractable == (IInteractable)_itemModel)
                _interactionIcon.SetActive(true);
        }

        private void HideView()
        {
            if (InteractionModel.CurrentInteractable == (IInteractable)_itemModel)
                _interactionIcon.SetActive(false);
        }

    }
}
