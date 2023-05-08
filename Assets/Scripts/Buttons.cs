using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //string updateMode = "none";
    enum updateModes
    {
        None,
        SettingsScrollUp,
        SettingsScrollDown,
        AboutScrollDown,
        AboutScrollUp
    }
    updateModes updateMode = updateModes.None;

    Transform screen;
    int frame = 1;

    float animationsSpeed = 0.2f;
    float animationsAcceleration = 1.05f;



    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector3(85, 85, 85);
    }

    private void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector3(100, 100, 100);
        switch(gameObject.name)
        {
            // Menu AboutButton
            case ("AboutButton"): {
                    Debug.Log("About Us button is clicked");
                    break;
                }


            // Menu SettingsButton
            case ("SettingsButton"):
                {
                    Debug.Log("Settings button is clicked");
                    updateMode = updateModes.SettingsScrollUp;
                    frame = 0;
                    break;
                }


            // Menu LangButton
            case ("LangButton"):
                {
                    Debug.Log("Lang button is clicked");
                    break;
                }


            // Menu PlayButton
            case ("PlayButton"):
                {
                    Debug.Log("Play button is clicked");
                    PlayerPrefs.SetInt("color", 0);
                    
                    SceneManager.LoadScene("Game");
                    break;
                }

            default:
                break;
        }
    }


    void scrollSomeScreen(Transform chosenScreen, Vector3 move, float speed=1, float acceleration=1, int frame=1)
    {
        chosenScreen.localPosition += move * speed * (acceleration * frame);
    }


    // Start is called before the first frame update
    void Start()
    {
        screen = gameObject.transform.parent.parent;
    }

    // Update is called once per frame
    void Update()
    {
        switch(updateMode)
        {
            case updateModes.SettingsScrollUp:
                {

                    frame++;
                    if (screen.localPosition.y + (animationsSpeed*animationsAcceleration*frame) <= -1080)
                    {
                        screen.localPosition = new Vector3(0, -1080, 0);
                        frame = 0;
                        updateMode = updateModes.None;
                    } else
                    {
                        scrollSomeScreen(screen, Vector3.down, animationsSpeed, animationsAcceleration, frame);
                    }
                    break;
                }


            case updateModes.None:
                    break;

            default:
                break;
        }

        
    }
}
