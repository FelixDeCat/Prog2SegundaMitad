using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed = 3f;
    [SerializeField] Animator anim;

    [SerializeField] AnimEvents animEvents;
    void Start()
    {
        target = GameManager.instancia.myPlayer.transform;

        //// Tengo que subscribir a ANIM EVENT : "Attack"
        animEvents.Subscribe("Attack", AtaqueVerdadero);
        //animEvents.Subscribe("PickUp", SpawnObject);
        //animEvents.Subscribe("HandOnFloor", GenerateFireAura);
    }
    
    void AtaqueVerdadero()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }
    //void SpawnObject()
    //{
    //    Debug.Log("Spawneo en mi mano");
    //}
    //void GenerateFireAura()
    //{
    //    Debug.Log("Spawneo en mi mano");
    //}


    Vector3 dir = Vector3.zero;
    float timer = 0;
    [SerializeField] float cdAttack = 1f;
    [SerializeField] float minDistToAttack = 1f;
    [SerializeField] float minDistToFollow = 5f;

    bool isAttacking = false;
    void Update()
    {
        dir = target.position - transform.position;

        if (dir.magnitude < minDistToFollow)
        {
            if (dir.magnitude < minDistToAttack) // Magnitud completa (con raiz)
            {
                if (!isAttacking)
                {
                    anim.SetBool("isAttacking", true);
                    isAttacking = true;
                }

                //if (timer < cdAttack)
                //{
                //    timer += Time.deltaTime;
                //}
                //else
                //{
                //    anim.Play("Attack");
                //    timer = 0;
                //    GameManager.instancia.myPlayer.OnHit(20);
                //}
            }
            else
            {
                anim.SetFloat("Movement", dir.magnitude);
                transform.position = transform.position + dir.normalized * speed * Time.deltaTime;
            }

            transform.forward = dir;
        }
        else
        {
            anim.SetFloat("Movement", 0);
        }
    }
}
