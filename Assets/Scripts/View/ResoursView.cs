using UnityEngine;

public abstract class ResoursView : MonoBehaviour, IHitble
{
    [field: SerializeField] public ResourcesData ResourcesData { get; private set; }
    [field: SerializeField] public Vector2 Position { get; private set; }

    private void Start()
    {
        Position = new Vector2(transform.position.x, transform.position.y);
    }
}
