using UnityEngine;

namespace Questronaut.Interaction
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
    public class ItemData : ScriptableObject
    {
        public string Name;
        public string Description;
        public int MaxStackSize;
        public Sprite Icon;
    }
}
