using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        board.ClearTile();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true; 
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapse = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while(elapse < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapse / duration);
            elapse += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
