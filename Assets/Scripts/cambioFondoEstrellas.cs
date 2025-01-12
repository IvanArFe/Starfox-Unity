using UnityEngine;
using UnityEngine.UI;

public class CambioFondoEstrellas : MonoBehaviour
{
    public Sprite[] fondos; // Array de sprites del fondo
    public Image fondoActual; // Referencia al componente Image que muestra el fondo
    public float tiempoCambio = 2f; // Tiempo entre cambios

    private int indiceActual = 0;
    private float temporizador;

    void Update()
    {
        temporizador += Time.deltaTime;

        // Cambia la imagen del fondo cuando el temporizador supera el tiempo de cambio
        if (temporizador >= tiempoCambio)
        {
            temporizador = 0f;
            CambiarFondo();
        }
    }

    void CambiarFondo()
    {
        // Cambia al siguiente fondo en el array
        indiceActual = (indiceActual + 1) % fondos.Length;
        fondoActual.sprite = fondos[indiceActual];
    }
}
