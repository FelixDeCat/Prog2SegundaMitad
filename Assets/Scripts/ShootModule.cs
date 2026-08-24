using UnityEngine;

public class ShootModule : MonoBehaviour
{
    bool cd = false;
    float timer = 0;
    [SerializeField] float cd_timer = 0.5f;

    [SerializeField] Bullet bullet_model;
    [SerializeField] Transform shootPoint;

    public void Shoot()
    {
        if (!cd)
        {
            cd = true;
            timer = 0;
            // disparo

            Bullet bullet = GameObject.Instantiate(bullet_model);
            bullet.Reposisionate(shootPoint.position, shootPoint.forward);

        }
    }

    void Update()
    {
        if (!cd) return;

        if (timer < cd_timer)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        else
        {
            timer = 0;
            cd = false;
        }

    }
}
