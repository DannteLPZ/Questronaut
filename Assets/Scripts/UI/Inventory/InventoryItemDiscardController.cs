using UnityEngine;

namespace Questronaut.Inventory
{
    public class InventoryItemDiscardController : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                PlayerInventoryModel.Instance.RemoveItem();
            }
        }
    }
}
