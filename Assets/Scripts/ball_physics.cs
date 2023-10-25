using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_physics : MonoBehaviour
{
    float timer_start;
    float timer_finish;
    float timer_interval;

    [SerializeField]
    float throw_force_x_y;

    [SerializeField]
    float throw_force_z;

    [SerializeField]
    CapsuleCollider trash_collider;
    Rigidbody rb;
    Vector3 init_pos;

    // Start is called before the first frame update
    void Start()
    {
        application.score = 0;
        rb = GetComponent<Rigidbody>();
        init_pos = transform.position;

        set_balltype_force();
    }

    // Update is called once per frame
    void Update()
    {
        throw_ball();
    }

    void throw_ball(){
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            timer_start = Time.time;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            timer_finish = Time.time;
            timer_interval = timer_finish - timer_start;
            rb.isKinematic = false;

            rb.AddForce(0, throw_force_x_y * 2f, throw_force_z / timer_interval * 1f);
            rb.useGravity = true;
            Invoke("reset_ball", 2);
        }
    }
    void reset_ball()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        transform.position = init_pos;
        rb.velocity = Vector3.zero;
        application.hit_detected = false;
    }

    void set_balltype_force()
    {
        switch(application.selected_ball)
        {
            case application.ball_type.slow:
                Debug.Log("balltype --> slow");
                throw_force_x_y = 4f;
                throw_force_z = 8f;
                break;

            case application.ball_type.normal:
                Debug.Log("balltype --> normal");
                throw_force_x_y = 8f;
                throw_force_z = 15f;
                break;

            case application.ball_type.fast:
                Debug.Log("balltype --> fast");
                throw_force_x_y = 10f;
                throw_force_z = 20f;
                break;

            case application.ball_type.lightning:
                Debug.Log("balltype --> lightning");
                throw_force_x_y = 15f;
                throw_force_z = 25f;
                break;
        }
    }
}
