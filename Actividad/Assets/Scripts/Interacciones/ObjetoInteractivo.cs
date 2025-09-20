using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour, IInteractuable
{
    public void Interactuar()
    {
        Destroy(gameObject);
        FindObjectOfType<ScoreManager>().AddPoints(10);

    }
}