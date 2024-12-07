using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private UnitFactory _unitfactory;
    [SerializeField] private Button _button;

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
        _unitfactory.CanSpawn();
    }
}
