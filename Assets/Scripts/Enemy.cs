using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed = 3f;
    
    void Start()
    {
        target = GameManager.instancia.myPLayer.transform;
    }


    Vector3 dir = Vector3.zero;
    float timer = 0;
    [SerializeField] float cdAttack = 1f;
    [SerializeField] float minDistToAttack = 1f;
    void Update()
    {
        dir = target.position - transform.position;



        //if (dir.sqrMagnitude < minDistToAttack * minDistToAttack ) // Magnitud cuadrada (sin raiz cuadrada)
        //{

        //}

        if (dir.magnitude < minDistToAttack) // Magnitud completa (con raiz)
        {
            if (timer < cdAttack)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                GameManager.instancia.myPLayer.OnHit(20);

            }
        }
        else
        {
            transform.position = transform.position + dir.normalized * speed * Time.deltaTime;
        }

    }
}
