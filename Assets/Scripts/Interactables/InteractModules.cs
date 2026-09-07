using UnityEngine;

public class InteractModules : MonoBehaviour
{
    [SerializeField] LayerMask mask_interactable;

    [SerializeField] float radius = 5f;

    Interactable mostClose = null;

    float minDist = 0;
    float dist = 0;

    void Update()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, mask_interactable);

        mostClose = null;

        minDist = float.MaxValue;

        for (int i = 0; i < cols.Length; i++)
        {
            Interactable interact = cols[i].GetComponent<Interactable>();
            if (interact != null)
            {
                interact.CancelPeek();

                dist = Vector3.Distance(this.transform.position, interact.transform.position);

                if (dist < minDist)
                {
                    minDist = dist;
                    mostClose = interact;
                }
            }
        }

        if (mostClose != null)
        {
            mostClose.Peek();

            if (Input.GetButtonDown("Interact"))
            {
                mostClose.Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, radius * 2);
    }
}
