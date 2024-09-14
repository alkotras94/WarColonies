using UnityEngine;
using TMPro;

public class StoneUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _stoneResources;

    private StoneModel _stoneModel;

    public void Initialize(StoneModel stoneModel)
    {
        _stoneModel = stoneModel;
        _stoneModel.Changed += OnCountChanged;
    }

    private void OnDisable()
    {
        _stoneModel.Changed -= OnCountChanged;
    }
    private void OnCountChanged()
    {
        _stoneResources.text = _stoneModel.Resours.ToString();
    }
}
