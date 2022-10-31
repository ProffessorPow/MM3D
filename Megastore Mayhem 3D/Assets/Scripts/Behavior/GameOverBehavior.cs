using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBehavior : MonoBehaviour
{
    public UnityEvent endGame;

    public int sceneToLoad;
    
    public void GameOver()
    {
        endGame.Invoke();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
