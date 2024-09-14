using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Resources/Unit")]
public class UnitData : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
}
