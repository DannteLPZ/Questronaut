using UnityEngine;

namespace Questronaut.NPC
{
    public class NPCView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private NPCModel _npcModel;

        private void Awake()
        {
            _npcModel = GetComponent<NPCModel>();
        }

        private void Start()
        {
            UpdateView();   
        }

        private void UpdateView()
        {
            _spriteRenderer.color = _npcModel.NPCData.Color;
        }
    }
}
