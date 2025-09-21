using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaJuego : MonoBehaviour
{
    // Asegúrate de que "menuPausa" es público y se asigna correctamente desde el Inspector
    public GameObject PanelPausa;  // Cambié "menuPusa" a "menuPausa"
    public bool juegoPausado = false;

    private void Update()
    {
        // Escuchar la tecla Escape para pausar o reanudar el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Renaudar();  // Reanudar el juego si está pausado
            }
            else
            {
                Pausar();  // Pausar el juego si no está pausado
            }
        }
    }

    // Función para reanudar el juego
    public void Renaudar()
    {
        PanelPausa.SetActive(false);  // Oculta el panel de pausa
        Time.timeScale = 1;  // Reanuda el flujo del juego
        juegoPausado = false;  // Cambia el estado a no pausado
    }

    // Función para pausar el juego
    public void Pausar()
    {
        PanelPausa.SetActive(true);  // Muestra el panel de pausa
        Time.timeScale = 0;  // Detiene todas las acciones del juego
        juegoPausado = true;  // Cambia el estado a pausado
    }
}