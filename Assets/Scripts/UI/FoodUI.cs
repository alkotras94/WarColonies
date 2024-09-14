using UnityEngine;
using TMPro;

public class FoodUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _foodResources;

    private FoodModel _foodModel;

    public void Initialize(FoodModel foodModel)
    {
        _foodModel = foodModel;
        _foodModel.Changed += OnCountChanged;
    }

    private void OnDisable()
    {
        _foodModel.Changed -= OnCountChanged;
    }
    private void OnCountChanged()
    {
        _foodResources.text = _foodModel.Resours.ToString();
    }
}
