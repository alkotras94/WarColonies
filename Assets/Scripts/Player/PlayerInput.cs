using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetMouseButtonUp(0))
        {
            TargetPoint();
        }
    }

    private void TargetPoint()
    {
        TargetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Hit hit = new Hit(TargetPosition, null);
        _player.TransferStateMachine(hit);
    }
}
