using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_type_handler : MonoBehaviour
{
    public Dropdown drop_down;
    
    [SerializeField]
    Text debug;

    // Start is called before the first frame update
    void Start()
    {
        debug.enabled = false;
        drop_down.value = PlayerPrefs.GetInt("DROPDOWNSKY");

        drop_down.onValueChanged.AddListener(delegate { 
            DropdownItemSelected(drop_down);
        });
    }

    public void DropdownItemSelected(Dropdown dropdown)
    {
        switch(dropdown.value)
         {
             case 0: 
                PlayerPrefs.SetInt("DROPDOWNSKY", 0);
                application.selected_ball = application.ball_type.slow;
                debug.text = "SLOW";
                break;

             case 1:
                PlayerPrefs.SetInt("DROPDOWNSKY", 1);
                application.selected_ball = application.ball_type.normal;
                debug.text = "NORMAL";
                break;

             case 2:
                PlayerPrefs.SetInt("DROPDOWNSKY", 2);
                application.selected_ball = application.ball_type.fast;
                debug.text = "FAST";
                break;

            case 3:
               PlayerPrefs.SetInt("DROPDOWNSKY", 3);
               application.selected_ball = application.ball_type.lightning;
               debug.text = "LIGHTNING";
               break;
         }
    }
}
