using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    [SerializeField] private GameObject _partWood;
    [SerializeField] private GameObject _partStone;
    [SerializeField] private GameObject _partFood;
    [SerializeField] private GameObject _bow;

    public void GetAxe()
    {
        _bow.SetActive(true);
        _partFood.SetActive(false);
        _partWood.SetActive(false);
        _partStone.SetActive(false);
    }

    public void GetFood()
    {
        _bow.SetActive(false);
        _partFood.SetActive(true);
        _partWood.SetActive(false);
        _partStone.SetActive(false);
    }

    public void GetWood()
    {
        _bow.SetActive(false);
        _partFood.SetActive(false);
        _partWood.SetActive(true);
        _partStone.SetActive(false);
    }

    public void GetStone()
    {
        _bow.SetActive(false);
        _partFood.SetActive(false);
        _partWood.SetActive(false);
        _partStone.SetActive(true);
    }
}
