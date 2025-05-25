using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Questronaut.Interaction
{
    [CreateAssetMenu(fileName = "Item Database", menuName = "Scriptable Objects/Item Database")]
    public class ItemDatabase : ScriptableObject
    {
        public List<ItemDataSO> items;

        private Dictionary<string, ItemDataSO> _codex;

        public void Init()
        {
            _codex = items.ToDictionary(i => i.Name, i => i);
        }

        public ItemDataSO GetItem(string id)
        {
            if (_codex == null) Init();
            return _codex.TryGetValue(id, out var item) ? item : null;
        }
    }
}
