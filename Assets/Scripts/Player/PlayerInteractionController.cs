using Questronaut.GameFlow;
using Questronaut.Player;
using UnityEngine;

namespace Questronaut.Interaction
{
    public class PlayerInteractionController : MonoBehaviour
    {
        private bool CanInput => !GameFlowManager.Instance.IsPaused && !PlayerBlockerModel.Instance.IsBlocked;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) == true && CanInput == true)
                PlayerInteractionModel.Instance.Interact();
        }
    }
}
