using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Player variables")]
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _angleSmoothing = 0.125f;
    [SerializeField] private float _turnSpeed = 0.25f;

    private Vector3 _movement;
    private Vector3 _direction;
    private Vector3 _velocity;

    private Camera _cam;
    private Rigidbody _rb;
    private PlayerAnimation _playerAnim;
    private GunControl _gunControl;

    [Header("References")]
    [SerializeField] private LayerMask _floorMask;

    private float _currentVelocity; // referencia no dampAngle

    #endregion

    #region Unity Methods
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _floorMask = LayerMask.GetMask("Floor");
        _playerAnim = GetComponent<PlayerAnimation>();
        _gunControl = GetComponentInChildren<GunControl>();
        _cam = Camera.main;
        
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.Instance.playerIsDead)
        {
            MovePlayer();
        }
    }

    #endregion


    #region Methods
    public void SetMovementInput(Vector3 input)
    {
        _direction = Quaternion.Euler(0f, _cam.transform.eulerAngles.y, 0f) * input.normalized;
        _velocity = _direction * _speed;
        _movement = _velocity * Time.fixedDeltaTime;
      
    }


    private void MovePlayer()
    {
        _rb.MovePosition(transform.position + _movement);
        _playerAnim.PlayerMove(_movement.magnitude);

        if(_gunControl.isShooting)
        {
            LookWhereShooting();
        }
        
        if (_movement.magnitude > 0.01 && !_gunControl.isShooting)
        {
            _rb.MoveRotation(FindDirectionAngle(_direction));
        }
    }

    private Quaternion FindDirectionAngle(Vector3 inputDirection)
    {
        float angle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref _currentVelocity, _angleSmoothing);

        return Quaternion.Euler(new Vector3(0f, smoothedAngle, 0f));


    }

    private void LookWhereShooting()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        float maxRayDistance = 100f;

        if(Physics.Raycast(ray, out RaycastHit hitinfo, maxRayDistance, _floorMask))
        {
            Vector3 hitDirection = (hitinfo.point - transform.position).normalized;

            hitDirection.y = 0; // pra ele atirar só reto

            Quaternion pointRotation = Quaternion.LookRotation(hitDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, pointRotation, _turnSpeed);

        }
    }

    #endregion
}
