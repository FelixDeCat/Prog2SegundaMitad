using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;

    HashSet<string> loadedScenes = new HashSet<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void LoadSceneAsync(string sceneName, bool additive = false)
    {
        instance.StartCoroutine(instance._loadSceneAsync(sceneName, additive));
    }
    public static void UnLoadSceneAsync(string sceneName)
    {
        instance.StartCoroutine(instance._unloadSceneAsync(sceneName));
    }

    IEnumerator _loadSceneAsync(string sceneName, bool additive)
    {
        if (!loadedScenes.Contains(sceneName))
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);

            while (!op.isDone)
            {
                yield return null;
            }

            loadedScenes.Add(sceneName);
        } 
    }

    IEnumerator _unloadSceneAsync(string sceneName)
    {
        AsyncOperation op = SceneManager.UnloadSceneAsync(sceneName);

        while (!op.isDone)
        {
            yield return null;
        }
    }
}
