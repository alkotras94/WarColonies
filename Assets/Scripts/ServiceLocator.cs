using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    [field: SerializeField] public Transform ReceptionFirstPoint { get; private set; }
    [field: SerializeField] public Transform PointFreeWorkers { get; private set; }

    public static ServiceLocator Instance;

    public FreeSquad _freeSquad;
    public WoodSquad _woodSquad;
    public StoneSquad _stoneSquad;
    public FoodSquad _foodSquad;

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
        _freeSquad = new FreeSquad();
        _woodSquad = new WoodSquad();
        _stoneSquad = new StoneSquad();
        _foodSquad = new FoodSquad();
    }
}
