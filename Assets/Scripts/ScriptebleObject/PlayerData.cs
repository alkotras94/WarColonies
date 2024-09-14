using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player")]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
}
