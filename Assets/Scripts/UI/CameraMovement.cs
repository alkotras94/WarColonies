using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _camera;

    private void Start()
    {
        _camera = transform;
    }
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _camera.position += Vector3.left * _speed * Time.deltaTime; ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _camera.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _camera.position += Vector3.up * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _camera.position += Vector3.down * _speed * Time.deltaTime;
        }
    }

}

