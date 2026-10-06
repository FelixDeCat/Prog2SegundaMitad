using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] string sceneToUnLoad;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            if(!string.IsNullOrEmpty(sceneToLoad)) MySceneManager.LoadSceneAsync(sceneToLoad, true);


            // esto se podria llamar desde otro trigger unicamente para descargas

            if (!string.IsNullOrEmpty(sceneToUnLoad)) MySceneManager.UnLoadSceneAsync(sceneToUnLoad);
        }


    }
}
