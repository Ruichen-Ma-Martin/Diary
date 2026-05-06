using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    [SerializeField]private float minX, maxX;

    private void Start()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(smoothedPosition.x, minX, maxX);

            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}
