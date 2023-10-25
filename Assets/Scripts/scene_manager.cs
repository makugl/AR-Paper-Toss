using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_manager : MonoBehaviour
{
    [SerializeField]
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        if(score != null)
        {
            score.text = "Score: " + application.score;
        }
    }

    public void start_game()
    {
        SceneManager.LoadScene("AR-Game");
    }

    public void game_over_screen()
    {
        SceneManager.LoadScene("Game-Over-Screen");
    }

    public void start_screen()
    {
        SceneManager.LoadScene("Start-Screen");
    }
}
