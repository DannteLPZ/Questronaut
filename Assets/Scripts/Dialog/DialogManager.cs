using Questronaut.NPC;
using Questronaut.Player;
using System;
using UnityEngine;

namespace Questronaut.Dialog
{
    public class DialogManager : MonoBehaviour
    {
        public event Action OnShowDialog;
        public event Action OnHideDialog;

        public static DialogManager Instance;

        private NPCData _currentNPCData;
        public NPCData CurrentNPCData => _currentNPCData;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ShowDialog(NPCData npcData)
        {
            _currentNPCData = npcData;
            PlayerBlockerModel.Instance.BlockPlayer();
            OnShowDialog?.Invoke();
        }

        public void HideDialog()
        {
            PlayerBlockerModel.Instance.UnblockPlayer();
            OnHideDialog?.Invoke();
        }
    }
}
