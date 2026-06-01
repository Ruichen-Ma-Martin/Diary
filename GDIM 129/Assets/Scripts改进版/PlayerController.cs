using UnityEngine;

public class PlayerController : Singleton<PlayerController> {
    [SerializeField] private bool _moveSmooth = true;

    private Vector2 _moveDirection;
    [SerializeField] private float _moveSpeed = 3f;
    public Rigidbody2D rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _diary;
    private bool _isPlayerCanMove = true;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        MoveControll();
        OpenDiary();
    }

    void MoveControll()
    {
        if (!_isPlayerCanMove) return;
        _moveDirection.x = _moveSmooth ? Input.GetAxis("Horizontal") : Input.GetAxisRaw("Horizontal");

            rb.linearVelocityX = _moveDirection.x * _moveSpeed;
        if (_moveDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_moveDirection.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    void OpenDiary()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (DiaryControl.Instance._DiaryOpen == false)
            {
                _diary.SetActive(true);
                
            }
            else
            {
                _diary.SetActive(false);
                
            }
        }
    }
}
