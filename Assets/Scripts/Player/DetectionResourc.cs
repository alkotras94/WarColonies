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

    [SerializeField] private Button _buttonSource;
    [SerializeField] private Button _buttonCollect;

    private Collider2D _collider;
    private ResoursView _resoursView;

    private FreeSquad _freeSquad;
    private WoodSquad _woodSquad;
    private StoneSquad _stoneSquad;
    private FoodSquad _foodSquad;

    public void Initialize(FreeSquad freeSquad, WoodSquad woodSquad, StoneSquad stoneSquad, FoodSquad foodSquad)
    {
        _freeSquad = freeSquad;
        _woodSquad = woodSquad;
        _stoneSquad = stoneSquad;
        _foodSquad = foodSquad;

        _collider = GetComponent<Collider2D>();
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

}
