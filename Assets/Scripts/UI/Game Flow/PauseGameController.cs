using UnityEngine;

namespace Questronaut.GameFlow
{
    public class PauseGameController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                GameFlowManager.Instance.TogglePause();
        }
    }
}
