using UnityEngine;

public class CollisionInteract : MonoBehaviour
{
    public GameObject TextDetect; // UI con el mensaje (ej: "Presiona E para interactuar")
    GameObject ultimoReconocido = null;

    void Start()
    {
        TextDetect.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ver si el objeto tiene un componente que implemente IInteractuable
        IInteractuable interactuable = other.GetComponent<IInteractuable>();
        if (interactuable != null)
        {
            ultimoReconocido = other.gameObject;
            TextDetect.SetActive(true); // muestra el mensaje
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == ultimoReconocido)
        {
            TextDetect.SetActive(false);
            ultimoReconocido = null;
        }
    }

    private void Update()
    {
        if (ultimoReconocido != null)
        {
            // Si se presiona E estando dentro de la colisión, ejecuta interacción
            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractuable interactuable = ultimoReconocido.GetComponent<IInteractuable>();
                if (interactuable != null)
                {
                    interactuable.Interactuar();

                    TextDetect.SetActive(false);
                }
            }
        }
    }
}
