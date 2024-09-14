using UnityEngine;

public abstract class ResoursView : MonoBehaviour, IHitble
{
    [field: SerializeField] public ResourcesData _resourcesData { get; private set; }
}
