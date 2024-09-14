using UnityEngine;

public class ResourcesFortrres : MonoBehaviour
{
    [SerializeField] private WoodUI _woodUI;
    [SerializeField] private StoneUI _stoneUI;
    [SerializeField] private FoodUI _foodUI;
    [SerializeField] private GoldUI _goldUI;

    public WoodModel WoodModel { get; private set; }
    public StoneModel StoneModel { get; private set; }
    public FoodModel FoodModel { get; private set; }
    public GoldModel GoldModel { get; private set; }

    private void Awake()
    {
        WoodModel = new WoodModel();
        StoneModel = new StoneModel();
        FoodModel = new FoodModel();
        GoldModel = new GoldModel();

        _woodUI.Initialize(WoodModel);
        _stoneUI.Initialize(StoneModel);
        _foodUI.Initialize(FoodModel);
        _goldUI.Initialize(GoldModel);
    }

    public void Visit(ResoursView resoursView, int value)
    {
        Visit((dynamic)resoursView, (dynamic)value);
    }

    public void Visit(Wood resoursView, int value)
    {
        WoodModel.Add(value);
    }

    public void Visit(Stone resoursView, int value)
    {
        StoneModel.Add(value);
    }

    public void Visit(Food resoursView, int value)
    {
        FoodModel.Add(value);
    }
}
