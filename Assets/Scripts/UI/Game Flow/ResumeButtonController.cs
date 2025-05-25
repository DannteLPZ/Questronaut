using Questronaut.GameFlow;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButtonController : MonoBehaviour
{
    private Button _resumeButton;

    private void Awake()
    {
        _resumeButton = GetComponent<Button>();
    }

    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
    }
    private void OnDestroy()
    {
        _resumeButton.onClick.RemoveListener(ResumeGame);
    }

    private void ResumeGame()
    {
        GameFlowManager.Instance.TogglePause();
    }
}
