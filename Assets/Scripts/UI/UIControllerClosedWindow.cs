using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerClosedWindow : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObject;
    
    void Awake()
    {
        for (int i = 0; i < _gameObject.Count; i++)
        {
            _gameObject[i].SetActive(true);
        }
    }
}
