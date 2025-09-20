using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TMP_Text textoNombre;

    void Start()
    {
        string nombreJugador = PlayerPrefs.GetString("NombreJugador", "Jugador");
        textoNombre.text = "Bienvenido: " + nombreJugador;
    }
}
