using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaJuego : MonoBehaviour
{
    // Aseg�rate de que "menuPausa" es p�blico y se asigna correctamente desde el Inspector
    public GameObject PanelPausa;  // Cambi� "menuPusa" a "menuPausa"
    public bool juegoPausado = false;

    private void Update()
    {
        // Escuchar la tecla Escape para pausar o reanudar el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Renaudar();  // Reanudar el juego si est� pausado
            }
            else
            {
                Pausar();  // Pausar el juego si no est� pausado
            }
        }
    }

    // Funci�n para reanudar el juego
    public void Renaudar()
    {
        PanelPausa.SetActive(false);  // Oculta el panel de pausa
        Time.timeScale = 1;  // Reanuda el flujo del juego
        juegoPausado = false;  // Cambia el estado a no pausado
    }

    // Funci�n para pausar el juego
    public void Pausar()
    {
        PanelPausa.SetActive(true);  // Muestra el panel de pausa
        Time.timeScale = 0;  // Detiene todas las acciones del juego
        juegoPausado = true;  // Cambia el estado a pausado
    }
}