using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_detection : MonoBehaviour
{
    [SerializeField]
    Collider ball;
    int score_value = 5;
    public AudioClip myAudio;
    AudioSource audioS;

    void Start() 
    {
        audioS = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) 
    {
        application.hit_detected = false;
        if(ball == other)
        {
            audioS.PlayOneShot(myAudio, 0.7F);
            score_update();
        }
    }

    // Update is called once per frame
    void score_update()
    {
        if(application.hit_detected)
        {
            Debug.Log("match detected!");
            return;
        }

        application.hit_detected = true;
        application.score += score_value;
    }
}
