using Questronaut.Dialog;
using Questronaut.Interaction;
using UnityEngine;

namespace Questronaut.NPC
{
    public class NPCModel : MonoBehaviour, IInteractable
    {
        [SerializeField] private NPCData _npcData;
        public NPCData NPCData => _npcData;

        public void Interact()
        {
            DialogManager.Instance.ShowDialog(_npcData);
        }
    }
}
