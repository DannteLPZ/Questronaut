using Questronaut.Player;
using UnityEngine;

namespace Questronaut.Interaction
{
    public class PlayerInteractionController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) == true)
                PlayerInteractionModel.Instance.Interact();
        }
    }
}
