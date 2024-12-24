using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public Vector2 TargetPosition { get; private set; }
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    void Update()
    {
        if (Application.isEditor || SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Raycast();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Raycast();
                }
            }
        }

        /*if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Raycast();
        }*/
    }

    private void TargetPoint()
    {
        TargetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Hit hit = new Hit(TargetPosition, null, _player.transform);
        _player.TransferStateMachine(hit);
    }

    private void Raycast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (raycastHit.collider.TryGetComponent(out IHitble hitble))
        {
            TargetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Hit hit = new Hit(TargetPosition, null, _player.transform);
            _player.TransferStateMachine(hit);
        }
    }
}

