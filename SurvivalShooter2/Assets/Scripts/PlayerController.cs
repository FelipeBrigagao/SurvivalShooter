using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 3.5f;
    float angleSmoothing = 0.125f;
    Vector3 movement;
    Vector3 direction;
    Vector3 velocity;
    float turnSpeed = 0.25f;
    bool playerDead = false;

    Camera cam;
    Rigidbody rb;
    LayerMask floorMask;
    Animator anim;

    float currentVelocity; // referencia no dampAngle

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        PlayerStats.OnPlayerDeath += PlayerDied;
    }

    
    void Update()
    {
        Vector3 inputs = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");
        direction = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f) * inputs.normalized;
        velocity = direction * speed;
        movement = velocity * Time.fixedDeltaTime;


    }

    private void FixedUpdate()
    {
        if (!playerDead)
        {
            MovePlayer();
            anim.SetFloat("Speed", movement.magnitude);

        }
    }



    private void MovePlayer()
    {
        rb.MovePosition(transform.position + movement);


        if(Input.GetButton("Fire1"))
        {
            LookWhereShooting();
        }
        
        if (movement.magnitude > 0.01 && !Input.GetButton("Fire1"))
        {
            
            rb.MoveRotation(FindDirectionAngle(direction));

        }
    }

    private Quaternion FindDirectionAngle(Vector3 inputDirection)
    {
        float angle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref currentVelocity, angleSmoothing);

        return Quaternion.Euler(new Vector3(0f, smoothedAngle, 0f));


    }

    private void LookWhereShooting()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        float maxRayDistance = 100f;

        if(Physics.Raycast(ray, out RaycastHit hitinfo, maxRayDistance, floorMask))
        {
            //Da pra usar o lookAt, mas dessa maneira a rotação é suavizada

            Vector3 hitDirection = (hitinfo.point - transform.position).normalized;

            hitDirection.y = 0; // pra ele atirar só reto

            Quaternion pointRotation = Quaternion.LookRotation(hitDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, pointRotation, turnSpeed);


        }


    }


    void PlayerDied()
    {
        playerDead = true;
    }


    private void OnDestroy()
    {
        PlayerStats.OnPlayerDeath -= PlayerDied;
    }

}
