using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] string nameScene;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nameScene);
        }
    }
}
