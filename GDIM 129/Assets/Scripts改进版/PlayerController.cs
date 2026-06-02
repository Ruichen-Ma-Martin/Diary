using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController> {
    [SerializeField] private bool _moveSmooth = true;

    private Vector2 _moveDirection;
    [SerializeField] private float _moveSpeed = 3f;
    public Rigidbody2D rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
   
    public bool _isPlayerCanMove = true;
    private int _San;
    [SerializeField] private TMP_Text _SanText;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        _San = 100;
        DialogueLog.OnDialogueEnd += UpdateSanText;

    }

    private void Update() {
        MoveControll();
        OpenDiary();

         _SanText.text = "San: " + _San;
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
            DiaryControl.Instance.OpeanDiary();
        }
    }
    void UpdateSanText()
    {
        _San += DialogueLog.Instance._currentSanValue;
       
    }
}
