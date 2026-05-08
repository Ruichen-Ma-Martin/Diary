using UnityEngine;

public class CameraTargetController : MonoBehaviour {
    private Camera _mainCamera;
    private Transform _playerTransform;

    public float OffsetDistance = 1f;

    private Vector3 _followDirection;

    public void Start() {
        _mainCamera = Camera.main;
        _playerTransform = Singleton<PlayerController>.Instance.transform;
    }

    private void Update() {
        _followDirection = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - _playerTransform.position;

        if (_followDirection.magnitude > OffsetDistance)
            _followDirection = _followDirection.normalized * OffsetDistance;

        transform.position = _playerTransform.position + _followDirection;
    }
}
