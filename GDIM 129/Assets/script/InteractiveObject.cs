using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private GameObject _interactiveUI;

    void Update()
    {
        checkinteractiveStart();
    }

    void checkinteractiveStart()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < 1.5f)
        {
            _interactiveUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("interact");
            }
        }
        else
        {
            _interactiveUI.SetActive(false);
        }
    }
}
