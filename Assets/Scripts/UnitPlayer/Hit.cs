using UnityEngine;

public class Hit 
{
    public Vector2 Target { get; private set; }
    public ResoursView Resours { get; private set; }
    public Transform Transform { get; private set; }


    public Hit(Vector2 target, ResoursView resours, Transform transform)
    {
        Target = target;
        Resours = resours;
        Transform = transform;
    }
}
