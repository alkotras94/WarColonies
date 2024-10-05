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
            Visit(resours);
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
        _spriteResourc.sprite = wood.ResourcesData.SpriteResourc;
        _textNameResourc.text = wood.ResourcesData.NameResourc.ToString();
        _countResourc.text = wood.ResourcesData.CountResources.ToString();

    }

    public void Visit(Stone stone)
    {
        _spriteResourc.sprite = stone.ResourcesData.SpriteResourc;
        _textNameResourc.text = stone.ResourcesData.NameResourc.ToString();
        _countResourc.text = stone.ResourcesData.CountResources.ToString();

    }

    public void Visit(Food food)
    {
        _spriteResourc.sprite = food.ResourcesData.SpriteResourc;
        _textNameResourc.text = food.ResourcesData.NameResourc.ToString();
        _countResourc.text = food.ResourcesData.CountResources.ToString();
    }

}
