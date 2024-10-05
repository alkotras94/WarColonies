using UnityEngine;

public abstract class ResourcesData : ScriptableObject
{
    [field: SerializeField] public int TimeToCollect { get; private set; }
    [field: SerializeField] public int CountResources { get; private set; }
    [field: SerializeField] public string NameResourc { get; private set; }
    [field: SerializeField] public Sprite SpriteResourc { get; private set; }

}