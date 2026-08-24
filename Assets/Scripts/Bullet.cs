using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float destroyTime = 1f;
    bool anim = false;

    public void Reposisionate(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        transform.forward = direction;
        anim = true;
    }


    float timer = 0f;
    void Update()
    {
        if (!anim) return; 

        transform.position = transform.position + transform.forward * Time.deltaTime * bulletSpeed;

        if (timer < destroyTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            _Destroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Box box = other.GetComponent<Box>();
        if (box != null)
        {
            box.OnHit();
            _Destroy();
        }
    }

    void _Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
