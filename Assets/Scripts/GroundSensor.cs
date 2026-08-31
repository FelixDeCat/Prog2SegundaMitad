using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] Transform feet;
    [SerializeField] float radius = 0.2f;
    [SerializeField] LayerMask floor;

    public bool IsGrounded()
    {
        return Physics.CheckSphere(feet.position, radius, floor);
    }


    private void OnDrawGizmos()
    {
        if (feet == null) return;
        Gizmos.DrawSphere(feet.position, radius);
    }
}
