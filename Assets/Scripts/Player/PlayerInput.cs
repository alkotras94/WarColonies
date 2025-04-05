using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Toggle _toggle;
    public Vector2 TargetPosition { get; private set; }
    private Player _player;

    private bool touchProcessed = false; // Flag for tracking a processed touch

    public void Initialize(Player player)
    {
        _player = player;
    }
    
    void Update()
    {
        if (_toggle.isOn)
        {
            // Checking for touch devices
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && !touchProcessed && EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    touchProcessed = true;
                    Debug.Log("The touch has started!");
                    Debug.Log("Touching the UI. The raycast is ignored.Touchpad");
                    return;
                }

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Vector2 rayOrigin = ray.origin;
                int layerMask = ~LayerMask.GetMask("UI"); // Eliminating the UI layer

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity, layerMask);
                if (touch.phase == TouchPhase.Began && !touchProcessed && hit.collider != null)
                {
                    touchProcessed = true;
                    Debug.Log("The touch has started!");
                    Debug.Log($"Hitting a touchpad object: {hit.collider.name}");
                    Raycast();
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    touchProcessed = false; // We reset the flag after the touch is completed.
                }
            }
        }
        else
        {
            // �������� ��� ����
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("The cursor is located above the UI. The Raycast is ignored.The mouse");
                    return;
                }

                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                Vector2 rayOrigin = ray.origin;
                int layerMask = ~LayerMask.GetMask("UI"); // ��������� ���� UI

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity, layerMask);
                if (hit.collider != null)
                {
                    Debug.Log($"Hitting an object with the mouse: {hit.collider.name}");
                    Raycast();
                }
            }
        }
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

