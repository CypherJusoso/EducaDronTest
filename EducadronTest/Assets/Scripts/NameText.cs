using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameText : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    void Start()
    {
        //Si la instancia de datamanager no es null le asigno el nombre que tiene guardado a mi textMPG (nombre del jugador)
      if (DataManager.instance != null)
        {
            nameText.text = DataManager.instance.transportUsername;
        }
        else
        {
            nameText.text = "NoName";
        }
    }

}
