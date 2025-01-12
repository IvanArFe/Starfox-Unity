using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Importa el espacio de nombres para IEnumerator

public class GameOverTransition : MonoBehaviour
{
    public RectTransform gameImage; // Referencia al rectTransform de "Game"
    public RectTransform overImage; // Referencia al rectTransform de "Over"
    public float transitionSpeed = 2f; // Velocidad de la transición
    public float delayBetweenImages = 0.5f; // Retardo entre ambas transiciones

    private bool gameArrived = false;

    void Start()
    {
        StartCoroutine(PlayTransition());
    }

    IEnumerator PlayTransition()
    {
        // Mover "Game" al centro
        while (Vector2.Distance(gameImage.anchoredPosition, Vector2.zero) > 0.1f)
        {
            gameImage.anchoredPosition = Vector2.Lerp(
                gameImage.anchoredPosition,
                Vector2.zero,
                transitionSpeed * Time.deltaTime
            );
            yield return null;
        }

        gameImage.anchoredPosition = Vector2.zero; // Asegurarse de que quede en el centro
        gameArrived = true;

        yield return new WaitForSeconds(delayBetweenImages);

        // Mover "Over" al centro
        while (Vector2.Distance(overImage.anchoredPosition, Vector2.zero) > 0.1f)
        {
            overImage.anchoredPosition = Vector2.Lerp(
                overImage.anchoredPosition,
                Vector2.zero,
                transitionSpeed * Time.deltaTime
            );
            yield return null;
        }

        overImage.anchoredPosition = Vector2.zero; // Asegurarse de que quede en el centro
    }
}
