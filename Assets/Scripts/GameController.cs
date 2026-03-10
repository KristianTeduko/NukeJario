using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject Win;
    public GameObject Pause;

    enum gamestate
    {
        playing,
        win,
        pause
    }

    gamestate currentstate = gamestate.playing;


    public void PlayState()
    {
        StateControl(gamestate.playing);

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {

    }
    void Start()
    {
        StateControl(gamestate.playing);
    }

    public void winState()
    {
        StateControl(gamestate.win);
    }

    public void pauseState()
    {
        StateControl(gamestate.pause);
    }

    void StateControl( gamestate _gamestate)
    {


        currentstate = _gamestate;
        switch (currentstate)
        {


            case gamestate.playing:
                Win.SetActive(false);
                Pause.SetActive(false);
                Time.timeScale = 1f;
                break;

            case gamestate.win:
                Win.SetActive(true);
                Time.timeScale = 0f;
                break;

            case gamestate.pause:
                Pause.SetActive(false);
                Time.timeScale = 0f;
                break;


        }




    }
}
