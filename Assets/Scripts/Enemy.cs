using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    
    void Start()
    {
        target = GameManager.instancia.myPLayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
