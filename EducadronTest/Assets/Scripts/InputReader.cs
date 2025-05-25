using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class InputReader : MonoBehaviour
{
    public NameApi nameApi;
    public void ReadStringInput(string name)
    {
   
        //Si el input no esta vacío le asigno el string al data manager para que lo pase a la siguiente escena
        if (!string.IsNullOrEmpty(name))
        {
            DataManager.instance.transportUsername = name;
            //Llamada POST a la api
            nameApi.SendName(name);
            //Ir a la siguiente escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.LogWarning("El nombre esta vacío");
        }

    }
}
