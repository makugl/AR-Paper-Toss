using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficluty_handler : MonoBehaviour
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
                application.game_diufficulty = application.difficulty_enum.practice;
                debug.text = "PRACTICE";
                break;

             case 1:
                PlayerPrefs.SetInt("DROPDOWNSKY", 1);
                application.game_diufficulty = application.difficulty_enum.easy;
                debug.text = "EASY";
                break;

             case 2:
                PlayerPrefs.SetInt("DROPDOWNSKY", 2);
                application.game_diufficulty = application.difficulty_enum.normal;
                debug.text = "NORMAL";
                break;

            case 3:
               PlayerPrefs.SetInt("DROPDOWNSKY", 3);
               application.game_diufficulty = application.difficulty_enum.intermediate;
               debug.text = "INTERMEDIATE";
               break;

             case 4:PlayerPrefs.SetInt("DROPDOWNSKY", 4);
                application.game_diufficulty = application.difficulty_enum.hard;
                debug.text = "HARD";
                break;

             case 5:PlayerPrefs.SetInt("DROPDOWNSKY", 5);
                application.game_diufficulty = application.difficulty_enum.godmode;
                debug.text = "GODMODE";
                break;
         }
    }
}
