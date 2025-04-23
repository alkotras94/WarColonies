using UnityEngine;
using UnityEngine.UI;

public class ReceiverView : MonoBehaviour, IHitble
{
    [SerializeField] private UnitFactory _unitfactory;
    //type to locate the reception area for new units

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PartFood food))
        {
            _unitfactory.CanSpawn();
        }
    }
}
