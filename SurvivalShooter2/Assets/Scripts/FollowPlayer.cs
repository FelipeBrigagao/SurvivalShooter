using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    Transform player;
    Vector3 offset;

    float smoothFollow = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = new Vector3(0f, 8f, -8f);
    }

    
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFollow * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(player);
    }
}
