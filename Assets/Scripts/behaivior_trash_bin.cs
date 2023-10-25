using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaivior_trash_bin : MonoBehaviour
{
    private Vector3 start_pos;
    public GameObject trash_bin;
    private bin_behaivior behaivior;
    public MeshRenderer bin_renderer;
    private float time_counter;
    private float random_speed;
    private float random_vertical_delta;
    private float random_horizontal_delta;
    private float random_radius;
    private int rnd_value;
    private bool wait_for_reset;
    private bool new_behaivior;

    private enum bin_behaivior {
        move_horizontal = 0,
        move_vertical = 1,
        move_circle = 2,
        smaller = 3,
        bigger = 4
    }

    // Start is called before the first frame update
    void Start()
    {
        behaivior = bin_behaivior.move_horizontal;
        start_pos = transform.position;

        time_counter = 0;
        random_speed = 0.5f;
        random_vertical_delta = 0.8f;
        random_horizontal_delta = 1.0f;
        random_radius = 0.4f;
        rnd_value = 0;
        wait_for_reset = false;
        new_behaivior = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(!wait_for_reset)
       {
            difficulty_handler();
       }
       else
       {
           behaivior_handler();
       }
    }

    private void behaivior_handler()
    {
        switch(application.game_diufficulty)
        {
            case application.difficulty_enum.practice:
                break;

            case application.difficulty_enum.easy:
                break;

            case application.difficulty_enum.normal:
                if(new_behaivior)
                {
                    change_behaivior(1);
                    new_behaivior = false;
                }
                
                break;
            
            case application.difficulty_enum.intermediate:
                if(new_behaivior)
                {
                    change_behaivior(2);
                    new_behaivior = false;
                }
                
                break;


            case application.difficulty_enum.hard:
                if(new_behaivior)
                {
                    change_behaivior(4);
                    new_behaivior = false;
                }
                break;


            case application.difficulty_enum.godmode:
                float speed_min = 0.2f;
                float speed_max = 1.5f;
                float vertical_delat_min = 0.1f;
                float vertical_delta_max = 2.4f;
                float horizontal_delta_min = 0.1f;
                float horizontal_delta_max = 2.0f;
                float radius_min = 0.1f;
                float radius_max = 2.0f;
                
                if(new_behaivior)
                {
                    random_speed = Random.Range(speed_min, speed_max);
                    random_vertical_delta = Random.Range(vertical_delat_min, vertical_delta_max);
                    random_horizontal_delta = Random.Range(horizontal_delta_min, horizontal_delta_max);
                    random_radius = Random.Range(radius_min, radius_max);
                    rnd_value = Random.Range(0, 3);
                    new_behaivior = false;
                }
                break;
        }
    }

    private void difficulty_handler()
    {
        switch(application.game_diufficulty){
            case application.difficulty_enum.practice:
                Debug.Log("trashbin difficulty --> practice");
                break;

            case application.difficulty_enum.easy:
                Debug.Log("trashbin difficulty --> easy");
                
                float delta_easy = 0.2f;
                float object_speed_easy = 0.8f;
                action(delta_easy, object_speed_easy);
                break;

            case application.difficulty_enum.normal:
                Debug.Log("trashbin difficulty --> normal");

                if(application.hit_detected)
                {
                    Invoke("set_triggers", 1);
                    Invoke("reset_bin", 2);
                }
                
                float delta_normal = 0.3f;
                float object_speed_normal = 1.0f;
                action(delta_normal, object_speed_normal);

                break;
            
            case application.difficulty_enum.intermediate:
                Debug.Log("trashbin difficulty --> hard");

                if(application.hit_detected)
                {
                    Invoke("set_triggers", 1);
                    Invoke("reset_bin", 2);
                }
                
                float delta_intermediate = 0.3f;
                float object_speed_intermediate = 1.0f;
                action(delta_intermediate, object_speed_intermediate);
                break;


            case application.difficulty_enum.hard:
                Debug.Log("trashbin difficulty --> hard");

                if(application.hit_detected)
                {
                    Invoke("set_triggers", 1);
                    Invoke("reset_bin", 2);
                }
                
                float delta_hard = 0.4f;
                float object_speed_hard = 1.2f;
                action(delta_hard, object_speed_hard);
                break;


            case application.difficulty_enum.godmode:
                Debug.Log("trashbin difficulty --> godmode");
                trash_do_random();
                break;
        }
    }

    private void action(float radius, float object_speed)
    {
        float scale = 0.33f;
        switch(behaivior)
        {
            case bin_behaivior.move_horizontal:
                trash_move_horizonal(radius, object_speed);
                break;

            case bin_behaivior.move_vertical:
                trash_move_vertical(radius, object_speed);
                break;

            case bin_behaivior.move_circle:
                trash_move_circle(radius, object_speed);
                break;

            case bin_behaivior.smaller:
                trash_get_smaller(scale);
                change_behaivior(2);
                break;

            case bin_behaivior.bigger:
                trash_get_bigger(scale);
                change_behaivior(2);
                break;
        }
    }

    private void set_triggers()
    {
        wait_for_reset = true;
        new_behaivior = true;
    }
    private void reset_bin()
    {
        application.hit_detected = false;
        wait_for_reset = false;
    }

    private void trash_move_horizonal(float delta, float object_speed)
    {
        Vector3 v = start_pos;
        v.x += delta * Mathf.Sin(Time.time * object_speed);
        transform.position = v;
    }

    private void trash_move_vertical(float delta, float object_speed)
    {
        Vector3 v = start_pos;
        v.z += delta * Mathf.Sin(Time.time * object_speed);
        transform.position = v;
    }

    private void trash_move_circle(float radius, float rotate_speed)
    {
        time_counter += Time.deltaTime * rotate_speed;
        Vector3 v = start_pos;

        v.x += Mathf.Cos(time_counter) * radius;
        v.y = Mathf.Sin(time_counter) * radius;

        transform.position = v;
    }

    private void trash_get_smaller(float scale)
    {
        trash_bin.gameObject.transform.localScale -= new Vector3(scale, scale, scale);
    
    }

    private void trash_get_bigger(float scale)
    {
        trash_bin.gameObject.transform.localScale += new Vector3(scale, scale, scale);
    }

    private void trash_do_random()
    {
        if(!wait_for_reset)
        {
            if(application.hit_detected)
            {
                Invoke("set_triggers", 1);
                Invoke("reset_bin", 2);
            }

            switch(rnd_value)
            {
                case 0:
                    trash_move_horizonal(random_horizontal_delta, random_speed);
                    break;

                case 1:
                    trash_move_vertical(random_vertical_delta, random_speed);
                    break;

                case 2:
                    trash_move_circle(random_radius, random_speed);
                    break;
            }
        }
    }

    private void change_behaivior(int max_value)
    {
        int new_behaivior = Random.Range(0, (max_value+1));

        if(new_behaivior == 0)
        {
            behaivior = bin_behaivior.move_horizontal;
        }
        else if(new_behaivior == 1)
        {
            behaivior = bin_behaivior.move_vertical;
        }
        else if(new_behaivior == 2)
        {
            behaivior = bin_behaivior.move_circle;
        }
        else if(new_behaivior == 3)
        {
            behaivior = bin_behaivior.smaller;
        }
        else if(new_behaivior == 4)
        {
            behaivior = bin_behaivior.bigger;
        }
        else
        {
            behaivior = bin_behaivior.move_horizontal;
            Debug.Log("UNDEFINED BEHAIVIOR");
        }
    }
}
