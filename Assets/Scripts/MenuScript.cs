using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    GameController gameController;

    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
    }


    public void RestartGame()
    {
        Debug.Log("käynnistts uudelleen");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        gameController.pauseState();



    }

    public void ContinueGame()
    {

        gameController.PlayState();


    }

    public void StartGame(string sceneName)
    {


        SceneManager.LoadScene(sceneName);


    }


    public void QuitGame()
    {
        Debug.Log("mennään pois");

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
