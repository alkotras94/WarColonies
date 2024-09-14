using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField] private Unit _template;
    [SerializeField] private Transform _transform;
    [SerializeField] private ResourcesFortrres _resourcesFortrres;
    [SerializeField] private UnitData _unitData;

    public List<Unit> Spawn(int count)
    {
        List<Unit> list = new List<Unit>();

        for (int i = 0; i < count; i++)
            list.Add(Spawn());

        return list;
    }
    public Unit Spawn()
    {
        Unit unit = Instantiate(_template,_transform);
        unit.Initialize(_resourcesFortrres, _unitData);
        return unit;
    }

    public void CanSpawn(int price)
    {
        if (price >= _unitData.Price)
        {
            Spawn();
            _resourcesFortrres.WoodModel.Spend(price);
        }
        else
        {
            Debug.Log("Недостаточно денег");
        }
    }
}
