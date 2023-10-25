using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_timer : MonoBehaviour
{
    public static float total_time;

    // Start is called before the first frame update
    void Start()
    {
        total_time = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        total_time -= Time.deltaTime;

        if(total_time <= 0f)
        {
            time_end();
        }
    }

    void time_end()
    {
        check_highscore();
        SceneManager.LoadScene("Game-Over-Screen");
    }

    public static float get_timer_value()
    {
        return total_time;
    }

    void check_highscore()
    {
        switch(application.game_diufficulty)
        {
            case application.difficulty_enum.practice:
                if(application.score > application.highscore_practice)
                {
                    application.highscore_practice = application.score;
                }
                break;

            case application.difficulty_enum.easy:
                if(application.score > application.highscore_easy)
                {
                    application.highscore_easy = application.score;
                }
                break;

            case application.difficulty_enum.normal:
                if(application.score > application.highscore_normal)
                {
                    application.highscore_normal = application.score;
                }
                break;

            case application.difficulty_enum.intermediate:
                if(application.score > application.highscore_intermediate)
                {
                    application.highscore_intermediate = application.score;
                }
                break;

            case application.difficulty_enum.hard:
                if(application.score > application.highscore_hard)
                {
                    application.highscore_hard = application.score;
                }
                break;

            case application.difficulty_enum.godmode:
                if(application.score > application.highscore_godmode)
                {
                    application.highscore_godmode = application.score;
                }
                break;
        }
    }
}
