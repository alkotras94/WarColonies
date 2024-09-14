using UnityEngine;

public abstract class ResourcesData : ScriptableObject
{
    [field: SerializeField] public int TimeToCollect { get; private set; }
    [field: SerializeField] public int CountResources { get; private set; }
}