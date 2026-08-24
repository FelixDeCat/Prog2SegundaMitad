using UnityEngine;

public class MyCamera : MonoBehaviour
{

    [SerializeField] Transform target;

    Vector3 offset = Vector3.zero;


    [Range(0.01f, 0.1f)]
    [SerializeField] float smoothQuant = 0.01f;

    void Start()
    {
        offset = transform.position - target.position;
    }

    Vector3 desired = Vector3.zero;
    private void LateUpdate()
    {
        desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, smoothQuant) ;
    }


}
