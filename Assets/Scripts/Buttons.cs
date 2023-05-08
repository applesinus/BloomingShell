using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    
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
                    break;
                }


            // Menu LangButton
            case ("LangButton"):
                {
                    Debug.Log("Settings button is clicked");
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
