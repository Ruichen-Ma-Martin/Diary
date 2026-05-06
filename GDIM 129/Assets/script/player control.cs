using Unity.VisualScripting;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _diary;
    private bool _isfaceright = true;

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
        openDiary();

    }
    private void Move()
    {
       float x = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(x, 0).normalized;
        _rb.linearVelocity = new Vector2(dir.x * _speed, _rb.linearVelocity.y);


        if (dir.x > 0 && !_isfaceright)
        {
            _isfaceright = true;
            Debug.Log("face right");
        }
        else if (dir.x < 0 && _isfaceright)
        {
            _isfaceright = false;
            Debug.Log("face left");
        }
    }
    private void interactive()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interact");
        }
    }
    private void openDiary()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("open");
            if (gameController.instance.isDiaryOpen)
            {
                _diary.SetActive(false);
                gameController.instance.isDiaryOpen = false;
            }
            else
            {
                _diary.SetActive(true);
                gameController.instance.isDiaryOpen = true;
            }
        }
    }
    private void youDead()
    {
        Debug.Log("you dead");
        Destroy(gameObject,1f);

    }
}
