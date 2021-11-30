using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform _player;

    private Vector3 _offset;

    private float _smoothFollow = 3f;


    #endregion

    #region Unity Methods
    void Start()
    {
        _player = PlayerManager.Instance._currentPlayer.transform;
        _offset = new Vector3(0f, 8f, -8f);
    }

    
    void FixedUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothFollow * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(_player);
    }
    #endregion
}
