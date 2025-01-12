using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverTransition : MonoBehaviour
{
    public RectTransform gameImage; // Referencia al RectTransform de "Game"
    public RectTransform overImage; // Referencia al RectTransform de "Over"
    public RectTransform characterImage; // Referencia al RectTransform del personaje
    public RectTransform canvas; // Referencia al RectTransform del canvas
    public float transitionSpeed = 2f; // Velocidad de la transición
    public float separation = 300f; // Separación final entre las imágenes
    public float bounceIntensity = 10f; // Intensidad del rebote
    public float bounceSpeed = 4f; // Velocidad del rebote
    public float characterDelay = 0.5f; // Retraso antes de que aparezca el personaje
    public float expansionSpeed = 1f; // Velocidad de la ampliación del personaje

    void Start()
    {
        StartCoroutine(PlayTransition());
    }

    IEnumerator PlayTransition()
    {
        // Obtener los límites del canvas
        float canvasWidth = canvas.rect.width;
        float canvasHeight = canvas.rect.height;

        // Posiciones iniciales de las imágenes
        Vector2 gameStartPos = new Vector2(-canvasWidth / 2 - 100f, 0); // Muy a la izquierda
        Vector2 overStartPos = new Vector2(canvasWidth / 2 + 100f, 0);  // Muy a la derecha
        Vector2 characterStartPos = new Vector2(0, canvasHeight / 2 + 100f); // Muy arriba

        // Posiciones finales de las imágenes
        Vector2 gameEndPos = new Vector2(-separation / 2, 0); // Más cerca del centro
        Vector2 overEndPos = new Vector2(separation / 2, 0);  // Más cerca del centro
        Vector2 characterEndPos = new Vector2(0, 0); // Centro del canvas

        // Establecer posiciones iniciales
        gameImage.anchoredPosition = gameStartPos;
        overImage.anchoredPosition = overStartPos;
        characterImage.anchoredPosition = characterStartPos;

        // Mover "Game" y "Over" simultáneamente desde fuera hasta sus posiciones finales
        while (Vector2.Distance(gameImage.anchoredPosition, gameEndPos) > 0.1f ||
               Vector2.Distance(overImage.anchoredPosition, overEndPos) > 0.1f)
        {
            gameImage.anchoredPosition = Vector2.Lerp(
                gameImage.anchoredPosition,
                gameEndPos,
                transitionSpeed * Time.deltaTime
            );

            overImage.anchoredPosition = Vector2.Lerp(
                overImage.anchoredPosition,
                overEndPos,
                transitionSpeed * Time.deltaTime
            );

            yield return null;
        }

        // Asegurarse de que "Game" y "Over" lleguen exactamente a sus posiciones finales
        gameImage.anchoredPosition = gameEndPos;
        overImage.anchoredPosition = overEndPos;

        // Aplicar un pequeño rebote a "Game" y "Over"
        for (float t = 0; t < 1f; t += Time.deltaTime * bounceSpeed)
        {
            gameImage.anchoredPosition = Vector2.Lerp(
                gameEndPos,
                new Vector2(gameEndPos.x, gameEndPos.y + bounceIntensity),
                Mathf.PingPong(t, 1f)
            );

            overImage.anchoredPosition = Vector2.Lerp(
                overEndPos,
                new Vector2(overEndPos.x, overEndPos.y + bounceIntensity),
                Mathf.PingPong(t, 1f)
            );

            yield return null;
        }

        // Esperar antes de mostrar el personaje
        yield return new WaitForSeconds(characterDelay);

        // Mover el personaje desde arriba hacia el centro
        while (Vector2.Distance(characterImage.anchoredPosition, characterEndPos) > 0.1f)
        {
            characterImage.anchoredPosition = Vector2.Lerp(
                characterImage.anchoredPosition,
                characterEndPos,
                transitionSpeed * Time.deltaTime
            );

            yield return null;
        }

        // Asegurarse de que el personaje llegue exactamente al centro
        characterImage.anchoredPosition = characterEndPos;

        // Aplicar un pequeño rebote al personaje
        for (float t = 0; t < 1f; t += Time.deltaTime * bounceSpeed)
        {
            characterImage.anchoredPosition = Vector2.Lerp(
                characterEndPos,
                new Vector2(characterEndPos.x, characterEndPos.y - bounceIntensity),
                Mathf.PingPong(t, 1f)
            );

            yield return null;
        }

        // Ampliar el personaje hasta que ocupe toda la pantalla
        Vector2 originalSize = characterImage.sizeDelta; // Tamaño inicial del personaje
        Vector2 targetSize = new Vector2(canvasWidth, canvasHeight); // Tamaño objetivo

        while (Vector2.Distance(characterImage.sizeDelta, targetSize) > 1f)
        {
            characterImage.sizeDelta = Vector2.Lerp(
                characterImage.sizeDelta,
                targetSize,
                expansionSpeed * Time.deltaTime
            );

            yield return null;
        }

        // Asegurarse de que el personaje alcance exactamente el tamaño objetivo
        characterImage.sizeDelta = targetSize;
    }
}
