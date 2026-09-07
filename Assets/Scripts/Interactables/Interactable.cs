using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] string interactName;

    [SerializeField] TextMeshProUGUI objectName;
    [SerializeField] CanvasGroup group;

    [SerializeField] Animator myAnim;

    void Start()
    {
        group.alpha = 0;
    }


    public void Peek()
    {
        group.alpha = 1;
        objectName.text = interactName;
    }

    public void CancelPeek()
    {
        group.alpha = 0;
    }

    public void Interact()
    {
        myAnim.Play("OnInteract");
    }
}
