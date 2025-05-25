using Questronaut.Interaction;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemCounterManager : MonoBehaviour
{
    private List<PickeableItemModel> _allPickups = new();
    private void Awake()
    {
        _allPickups = FindObjectsByType<PickeableItemModel>(FindObjectsSortMode.None).ToList();
    }
}
