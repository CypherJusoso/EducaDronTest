using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string username;
    public string transportUsername {  get => username; set => username = value; }
    public static DataManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
