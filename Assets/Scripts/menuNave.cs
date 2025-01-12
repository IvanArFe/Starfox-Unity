using UnityEngine;

public class MovimientoYRotacion : MonoBehaviour
{
    public float velocidadMovimientoX = 5f; // Velocidad de movimiento en el eje X
    public float velocidadMovimientoY = 5f; // Velocidad de movimiento en el eje Y
    public float velocidadMovimientoZ = 5f; // Velocidad de movimiento en el eje Z

    public float velocidadRotacionX = 50f; // Velocidad de rotación en el eje X
    public float velocidadRotacionY = 50f; // Velocidad de rotación en el eje Y
    public float velocidadRotacionZ = 50f; // Velocidad de rotación en el eje Z

    void Update()
    {
        // Movimiento en los tres ejes (X, Y, Z)
        float movimientoX = velocidadMovimientoX * Time.deltaTime;
        float movimientoY = velocidadMovimientoY * Time.deltaTime;
        float movimientoZ = velocidadMovimientoZ * Time.deltaTime;

        // Aplicar movimiento
        transform.Translate(movimientoX, movimientoY, movimientoZ);

        // Rotación en los tres ejes (X, Y, Z)
        transform.Rotate(velocidadRotacionX * Time.deltaTime, velocidadRotacionY * Time.deltaTime, velocidadRotacionZ * Time.deltaTime);
    }
}
