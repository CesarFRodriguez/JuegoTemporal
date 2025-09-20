using UnityEngine;
using UnityEngine.UI;
using TMPro; // Para usar TextMeshPro
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField inputNombre; // Referencia al InputField

    public void GuardarNombreYContinuar()
    {
        string nombreJugador = inputNombre.text;

        if (!string.IsNullOrEmpty(nombreJugador))
        {
            // Guardar el nombre en PlayerPrefs (memoria simple de Unity)
            PlayerPrefs.SetString("NombreJugador", nombreJugador);
            PlayerPrefs.Save();

            // Cambiar a la segunda escena
            SceneManager.LoadScene("SampleScene"); // Cambia "Juego" por el nombre de tu segunda escena
        }
        else
        {
            Debug.Log("El nombre no puede estar vacío");
        }
    }
}
