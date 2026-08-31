using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float lookForce = 0.3f;
    [SerializeField] Transform root;
    [SerializeField] ShootModule shoot_module;

    [SerializeField] Rigidbody rig;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] GroundSensor groundSensor;
    
    void Start()
    {
        /// puedo obtenerlo de esta manera automatica (si no me queda opcion)
       // rig = GetComponent<Rigidbody>();

        rig.interpolation = RigidbodyInterpolation.Interpolate;


        /// cuantos enemigos hay?
        /// 
        //GameManager.instancia.GetEnemies().Length;
    }


    Vector3 input = Vector3.zero;
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        if (input.sqrMagnitude > 0.1f)
        {
            //root.forward = input;
            root.forward = Vector3.Slerp(root.forward, input, lookForce);
        }

        // movimiento por transform
        //transform.position += input.normalized * Time.deltaTime * speed;

        if (Input.GetButtonDown("Fire1"))
        {
            shoot_module.Shoot();
        }

        if (Input.GetButtonDown("Jump") && groundSensor.IsGrounded())
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

    }


    float auxY = 0f;
    private void FixedUpdate()
    {
        //transform.position += input.normalized * Time.deltaTime * speed;
        auxY = rig.linearVelocity.y;
        
        rig.linearVelocity = input.normalized * Time.deltaTime * speed;

        rig.linearVelocity = new Vector3(rig.linearVelocity.x, auxY, rig.linearVelocity.z);
    }


}
