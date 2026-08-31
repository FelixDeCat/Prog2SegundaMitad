using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instancia;

    public Player myPLayer;

    [SerializeField] Enemy[] enemies;

    public Enemy[] GetEnemies()
    {
        return enemies;
    }

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }
}
