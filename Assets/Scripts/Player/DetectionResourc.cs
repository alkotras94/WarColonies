using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DetectionResourc : MonoBehaviour
{
    [SerializeField] private GameObject _resoursUIView;
    [SerializeField] private Image _spriteResourc;
    [SerializeField] private TMP_Text _textNameResourc;
    [SerializeField] private TMP_Text _countResourc;

    [SerializeField] private GameObject _popapUIResours;
    [SerializeField] private Image _spriteResourcPopap;
    [SerializeField] private TMP_Text _nameResourcPopap;

    [SerializeField] private Button _buttonSource;
    [SerializeField] private Button _buttonCollect;

    [SerializeField] private GameObject _partWood;
    [SerializeField] private GameObject _partStone;
    [SerializeField] private GameObject _partFood;
    [SerializeField] private GameObject _bow;

    [SerializeField] private GameObject _partWoodPrefabs;
    [SerializeField] private GameObject _partStonePrefabs;
    [SerializeField] private GameObject _partFoodPrefabs;

    private Collider2D _collider;
    private ResoursView _resoursView;
    private PlayerStateMachine _playerStateMachine;

    private FreeSquad _freeSquad;
    private WoodSquad _woodSquad;
    private StoneSquad _stoneSquad;
    private FoodSquad _foodSquad;

    public void Initialize(FreeSquad freeSquad, WoodSquad woodSquad, StoneSquad stoneSquad, FoodSquad foodSquad, PlayerStateMachine playerStateMachine)
    {
        _freeSquad = freeSquad;
        _woodSquad = woodSquad;
        _stoneSquad = stoneSquad;
        _foodSquad = foodSquad;

        _collider = GetComponent<Collider2D>();

        _playerStateMachine = playerStateMachine;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ResoursView resours))
        {
            _resoursUIView.SetActive(true);
            _resoursView = resours;
            ResourcInformation(resours);
            //_buttonSource.onClick.AddListener(StartVisit);

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ResoursView resours))
        {
            //_buttonSource.onClick.RemoveListener(StartVisit);
            _resoursUIView.SetActive(false);
        }
    }

    public void StartVisit()
    {
        Visit(_resoursView);
    }

    public void Visit(ResoursView resoursView)
    {
        Debug.Log("Visit");
        Visit((dynamic)resoursView);
    }

    public void Visit(Wood wood)
    {
        Debug.Log("Visit wood");
        _woodSquad.SetRecorcePoint(wood);
    }

    public void Visit(Stone stone)
    {
        Debug.Log("Visit stone");
        _stoneSquad.SetRecorcePoint(stone);
    }

    public void Visit(Food food)
    {
        Debug.Log("Visit food");
        _foodSquad.SetRecorcePoint(food);
    }

    public void ResourcInformation(ResoursView resours)
    {
        _spriteResourc.sprite = resours.ResourcesData.SpriteResourc;
        _textNameResourc.text = resours.ResourcesData.NameResourc.ToString();
        _countResourc.text = resours.ResourcesData.CountResources.ToString();
    }

    public void Collect()
    {
        //Hit hit = new Hit(_resoursView.Position, _resoursView, null);

        if (_resoursView is Wood)
        {
            Debug.Log("Visit Wood Player");
            _bow.SetActive(false);
            _partWood.SetActive(true);
            _partStone.SetActive(false);
            _partFood.SetActive(false);
            _popapUIResours.SetActive(true);
            _spriteResourcPopap.sprite = _resoursView.ResourcesData.SpriteResourc;
            _nameResourcPopap.text = "Wood";
        }
        if (_resoursView is Stone)
        {
            Debug.Log("Visit Stone Player");
            _bow.SetActive(false);
            _partWood.SetActive(false);
            _partStone.SetActive(true);
            _partFood.SetActive(false);
            _popapUIResours.SetActive(true);
            _spriteResourcPopap.sprite = _resoursView.ResourcesData.SpriteResourc;
            _nameResourcPopap.text = "Stone";
        }
        if (_resoursView is Food)
        {
            Debug.Log("Visit food Player");
            _bow.SetActive(false);
            _partWood.SetActive(false);
            _partStone.SetActive(false);
            _partFood.SetActive(true);
            _popapUIResours.SetActive(true);
            _spriteResourcPopap.sprite = _resoursView.ResourcesData.SpriteResourc;
            _nameResourcPopap.text = "Food";
        }
    }

    public void Quit()
    {
        if (_resoursView is Wood)
        {
            Debug.Log("Quit Wood Player");
            DisableObjectPlayer();
            GameObject obj = Instantiate(_partWoodPrefabs, _partWood.transform.position, Quaternion.identity, null);
            Destroy(obj, 2f);
        }
        if (_resoursView is Stone)
        {
            Debug.Log("Quit Stone Player");
            DisableObjectPlayer();
            GameObject obj = Instantiate(_partStonePrefabs, _partStone.transform.position, Quaternion.identity, null);
            Destroy(obj, 2f);
        }
        if (_resoursView is Food)
        {
            Debug.Log("Quit food Player");
            DisableObjectPlayer();
            GameObject obj = Instantiate(_partFoodPrefabs, _partFood.transform.position, Quaternion.identity, null);
            Destroy(obj, 2f);
        }

    }

    private void DisableObjectPlayer()
    {
        _bow.SetActive(true);
        _partWood.SetActive(false);
        _partStone.SetActive(false);
        _partFood.SetActive(false);
        _popapUIResours.SetActive(false);
    }

}
