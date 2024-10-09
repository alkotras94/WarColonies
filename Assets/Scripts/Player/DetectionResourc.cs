using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DetectionResourc : MonoBehaviour
{
    [SerializeField] private GameObject _resoursUIView;
    [SerializeField] private Image _spriteResourc;
    [SerializeField] private TMP_Text _textNameResourc;
    [SerializeField] private TMP_Text _countResourc;
    [SerializeField] private Button _buttonSource;
    [SerializeField] private Button _buttonCollect;

    private Collider2D _collider;


    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ResoursView resours))
        {
            _resoursUIView.SetActive(true);
            ResourcInformation(resours);
            //Visit(resours);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ResoursView resours))
        {
            _resoursUIView.SetActive(false);
        }
    }

    public void Visit(ResoursView resoursView)
    {
        Visit((dynamic)resoursView);
    }

    public void Visit(Wood wood)
    {

    }

    public void Visit(Stone stone)
    {

    }

    public void Visit(Food food)
    {
        
    }

    public void ResourcInformation(ResoursView resours)
    {
        _spriteResourc.sprite = resours.ResourcesData.SpriteResourc;
        _textNameResourc.text = resours.ResourcesData.NameResourc.ToString();
        _countResourc.text = resours.ResourcesData.CountResources.ToString();
    }

}
