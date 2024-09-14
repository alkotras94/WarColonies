using UnityEngine;
using TMPro;

public class WoodUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _woodResources;

    private WoodModel _woodModel;

    public void Initialize(WoodModel woodModel)
    {
        _woodModel = woodModel;
        _woodModel.Changed += OnCountChanged;
    }

    private void OnDisable()
    {
        _woodModel.Changed -= OnCountChanged;
    }
    private void OnCountChanged()
    {
        _woodResources.text = _woodModel.Resours.ToString();
    }

}
