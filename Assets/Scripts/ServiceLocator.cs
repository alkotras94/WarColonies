using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    [field: SerializeField] public Transform ReceptionFirstPoint { get; private set; } //New unit creation point
    [field: SerializeField] public Transform PointFreeWorkers { get; private set; } //Free unit point
    [field: SerializeField] public Transform StoragePointFood { get; private set; } 
    [field: SerializeField] public Transform StoragePointWood { get; private set; }
    [field: SerializeField] public Transform StoragePointStone { get; private set; }
    [field: SerializeField] public SliderDistribution SliderDistribution { get; private set; }
    [field: SerializeField] public Player Player { get; private set; } 
    
    
    public static ServiceLocator Instance;

    void Start()
    {
        if (Instance == null)
            Instance = this; 
        else if (Instance == this) 
            Destroy(gameObject); 

        DontDestroyOnLoad(gameObject);
    }
    
}
