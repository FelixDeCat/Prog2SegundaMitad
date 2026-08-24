using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] Animator myAnimator;

    public void OnHit()
    {
        print("Me golpearon");
        myAnimator.Play("BoxHit");
    }
}
