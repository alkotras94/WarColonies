using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    [field: SerializeField] public Transform ReceptionFirstPoint { get; private set; }
    [field: SerializeField] public Transform PointFreeWorkers { get; private set; }

    public static ServiceLocator Instance;

    void Start()
    {
        if (Instance == null)
            Instance = this; 
        else if (Instance == this) 
            Destroy(gameObject); 

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        
    }
}
