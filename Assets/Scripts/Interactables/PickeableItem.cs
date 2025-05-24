using System;
using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Interaction
{
    public class PickeableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData _itemData;
        [SerializeField] private GameObject _interactionIcon;


        public void ShowInteraction() => _interactionIcon.SetActive(true);

        public void HideInteraction() => _interactionIcon.SetActive(false);

        public void Interact()
        {
            Debug.Log($"Picked Up Item: {_itemData.Name}");
        }
    }

    [Serializable]
    public class ItemData
    {
        public string Name;
        public string Description;
        public Image Icon;
    }
}
