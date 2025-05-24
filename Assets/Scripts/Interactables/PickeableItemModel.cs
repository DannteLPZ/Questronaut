using System;
using UnityEngine;
using UnityEngine.UI;

namespace Questronaut.Interaction
{
    public class PickeableItemModel : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData _itemData;
        

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
