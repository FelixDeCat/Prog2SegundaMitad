using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float lookForce = 0.3f;
    [SerializeField] Transform root;

    [SerializeField] ShootModule shoot_module;


    void Start()
    {
        
    }


    Vector3 input = Vector3.zero;
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        if (input.sqrMagnitude > 0.1f)
        {
            root.forward = Vector3.Slerp(root.forward, input, lookForce);
        }

        transform.position += input.normalized * Time.deltaTime * speed;

        if (Input.GetButtonDown("Fire1"))
        {
            shoot_module.Shoot();
        }

    }
}
