using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class virtual_button_script : MonoBehaviour, IVirtualButtonEventHandler
{
    [SerializeField]
    Text current_score;

    [SerializeField]
    Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        current_score.enabled = false;
        current_score.text = "Score: " + application.score.ToString();
        highscore.enabled = false;
        GameObject virtual_button = GameObject.Find("score_button");

        virtual_button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        current_score.text = "Score: " + application.score.ToString();
        current_score.enabled = true;

        switch(application.game_diufficulty)
        {
            case application.difficulty_enum.practice:
                highscore.text = "Highscore: " + application.highscore_practice;
                break;

            case application.difficulty_enum.easy:
                highscore.text = "Highscore: " + application.highscore_easy;
                break;

            case application.difficulty_enum.normal:
                highscore.text = "Highscore: " + application.highscore_normal;
                break;

            case application.difficulty_enum.intermediate:
                highscore.text = "Highscore: " + application.highscore_intermediate;
                break;

            case application.difficulty_enum.hard:
                highscore.text = "Highscore: " + application.highscore_hard;
                break;

            case application.difficulty_enum.godmode:
                highscore.text = "Highscore: " + application.highscore_godmode;
                break;
        }
        highscore.enabled = true;

        var cube = GameObject.Find("button_cube");
        cube.GetComponent<Renderer>().material.color = new Color(0,255,0);
        Debug.Log("Button pressed!");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        current_score.enabled = false;
        highscore.enabled = false;
        var cube = GameObject.Find("button_cube");
        cube.GetComponent<Renderer>().material.color = new Color(255,0,0);
        Debug.Log("Button released!");
    }

}
