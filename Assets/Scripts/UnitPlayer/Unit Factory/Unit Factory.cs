using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField] private Unit _template;
    [SerializeField] private List<Transform> _transform;
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
        Unit unit = Instantiate(_template, _transform[RandomTransform()]);
        unit.Initialize(_unitData);
        return unit;
    }

    public void CanSpawn()
    {
            Spawn();
    }

    private int RandomTransform()
    {
        int i = Random.Range(0,_transform.Count);
        return i;
    }
}
