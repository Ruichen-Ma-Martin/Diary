using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Singleton<PlayerController> {
    [SerializeField] private bool _moveSmooth = true;

    private Vector2 _moveDirection;
    [SerializeField] private float _moveSpeed = 3f;
    public Rigidbody2D rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _idie;
    [SerializeField] private Sprite _walk;
    public bool _isPlayerCanMove = true;
    //public int _San;
    [SerializeField] private TMP_Text _SanText;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        
        DialogueLog.OnDialogueEnd += UpdateSanText;
        GlobalData._SanStock = GlobalData._SanValue;
        //GlobalData._SanValue = GlobalData._SanStock;//kesha

    }

    private void Update() {
        testuse();
        MoveControll();
        OpenDiary();
        if (GlobalData._SanValue <= 0)
        {
            SceneManager.LoadScene("DeadMain");
        }

        _SanText.text = "San: " + GlobalData._SanValue;
    }

    void MoveControll()
    {
        if (!_isPlayerCanMove) return;
        _moveDirection.x = _moveSmooth ? Input.GetAxis("Horizontal") : Input.GetAxisRaw("Horizontal");

        Vector2 dir = new Vector2(_moveDirection.x, 0).normalized;
        transform.Translate(dir * _moveSpeed * Time.deltaTime);
       // rb.linearVelocityX = _moveDirection.x * _moveSpeed;
        if (_moveDirection.x < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_moveDirection.x > 0)
        {
            _spriteRenderer.flipX = true;
        }

        if(Mathf.Abs(_moveDirection.x) > 0.01f)
        {
            _spriteRenderer.sprite = _walk;
        }
        else
        {
            _spriteRenderer.sprite = _idie;
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
        GlobalData._SanValue += DialogueLog.Instance._currentSanValue;
       
    }

    void testuse()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GlobalData._SanValue -= 80;
        }
    }
}
