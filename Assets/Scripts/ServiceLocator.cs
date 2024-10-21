using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    [field: SerializeField] public Transform ReceptionFirstPoint { get; private set; } //Точка создания новых юнитов
    [field: SerializeField] public Transform PointFreeWorkers { get; private set; } //Точка свободных юнитов
    [field: SerializeField] public Transform PointSourceWood { get; private set; }
    [field: SerializeField] public Transform PointSourceStone { get; private set; }
    [field: SerializeField] public Transform PointSourceFood { get; private set; } 
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
