using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private UnitFactory _unitfactory;
    [SerializeField] private Button _button;
    [SerializeField] private ResourcesFortrres _resourcesFortrres;

    private void OnEnable()
    {
        _button.onClick.AddListener(TrySpawn);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TrySpawn);
    }

    private void TrySpawn()
    {
        _unitfactory.CanSpawn(_resourcesFortrres.WoodModel.Resours);
    }
}
