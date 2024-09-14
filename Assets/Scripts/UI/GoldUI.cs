using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldResources;

    private GoldModel _goldModel;

    public void Initialize(GoldModel goldModel)
    {
        _goldModel = goldModel;
        _goldModel.Changed += OnCountChanged;
    }

    private void OnDisable()
    {
        _goldModel.Changed -= OnCountChanged;
    }
    private void OnCountChanged()
    {
        _goldResources.text = _goldModel.Resours.ToString();
    }
}
