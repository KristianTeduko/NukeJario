using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject Win;
    public GameObject Pause;
    public GameObject Lose;


    enum gamestate
    {
        playing,
        win,
        pause,
        loser
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

    public void gameOver()
    {
        StateControl(gamestate.loser);


    }


    public void winState()
    {
        StateControl(gamestate.win);
    }

    public void pauseState()
    {
        StateControl(gamestate.pause);
    }

    void StateControl(gamestate _gamestate)
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
                Pause.SetActive(true);
                Time.timeScale = 0f;
                break;


            case gamestate.loser:
                Lose.SetActive(true);
                Time.timeScale = 0f;
                break;


        }




    }
}
