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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Win.SetActive(false);
        Pause.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {

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


        switch (currentstate)
        {


            case gamestate.playing:
                Win.SetActive(false);
                Pause.SetActive(false);
                break;

            case gamestate.win:
                Win.SetActive(true);
                break;

            case gamestate.pause:
                Pause.SetActive(false);
                break;

        }




    }
}
