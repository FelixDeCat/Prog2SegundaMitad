using UnityEngine;

public class MyDataBase : MonoBehaviour
{
    public string[] myDataBase;

    public static MyDataBase instance;

    private void Awake()
    {
        myDataBase = new string[5] { "Jose", "Pablo", "Maria", "Marcos", "Luis" };

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


}
