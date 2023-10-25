using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class application : MonoBehaviour
{
    //definition of different game difficulties
    public enum difficulty_enum
    {
        practice = 0,
        easy = 1,
        normal = 2,
        intermediate = 3,
        hard = 4,
        godmode = 5
    }

    //definition of different ballspeed types
    public enum ball_type
    {
        slow = 0,
        normal = 1,
        fast = 2,
        lightning = 3
    }

    public static bool hit_detected = false;
    public static int score;
    public static difficulty_enum game_diufficulty = difficulty_enum.practice;
    public static ball_type selected_ball = ball_type.normal;
    public static int highscore_practice = 0;
    public static int highscore_easy = 0;
    public static int highscore_normal = 0;
    public static int highscore_intermediate = 0;
    public static int highscore_hard = 0;
    public static int highscore_godmode = 0;
}