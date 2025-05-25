using UnityEngine;

namespace Questronaut.NPC
{
    [CreateAssetMenu(fileName = "NPC Data", menuName ="Scriptable Objects/NPC Data")]
    public class NPCData : ScriptableObject
    {
        [TextArea]
        public string Dialog;
        public Color Color;
        public Sprite BorderSprite;
        public Sprite FillSprite;
    }
}
