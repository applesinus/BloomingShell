using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Sprite[] sprites;
    // for lang:    0 = EN, 1 = RU
    // for sound:   0 = ON, 1 = OFF


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

    float animationsSpeed = 0.01f;
    float animationsAcceleration = 1.05f;


    void changeTexts(Text[] textFields, string[] newTexts)
    {
        for (int i = 0; i < textFields.Length; i++)
        {
            textFields[i].text = newTexts[i];
        }
    }


    private string soundTextOperator()
    {
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                return "Sound\nON";
            }
            else
            {
                return "Sound\nOFF";
            }
        }
        else if (PlayerPrefs.GetInt("lang") == 1) {

            if (PlayerPrefs.GetInt("sound") == 0)
            {
                return "Çâóê\nÂÊË.";
            }
            else
            {
                return "Çâóê\nÂÛÊË.";
            }
        } else
        {
            return "Here is an error, please message @dapelsin on Telegram about it";
        }
    }
    
    private string langTextOperator()
    {
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            return "Language:\nEnglish";
        }
        else if (PlayerPrefs.GetInt("lang") == 1)
        {
            return "ßçûê:\nÐóññêèé";
        }
        else
        {
            return "Here is an error, please message @dapelsin on Telegram about it";
        }
    }
    
    
    private string titleSettingsTextOperator()
    {
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            return "Settings";
        }
        else if (PlayerPrefs.GetInt("lang") == 1)
        {
            return "Íàñòðîéêè";
        }
        else
        {
            return "Here is an error, please message @dapelsin on Telegram about it";
        }
    }



    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector3(85, 85, 85);
    }

    private void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector3(100, 100, 100);
        Debug.Log("Button " + gameObject.name + " is clicked!");
        switch(gameObject.name)
        {
            // Menu AboutButton
            case ("AboutButton"): {
                    break;
                }


            // Menu SettingsButton
            case ("SettingsButton"):
                {
                    updateMode = updateModes.SettingsScrollUp;
                    frame = 0;
                    break;
                }


            // Settings LangButton
            case ("LangButton"):
                {
                    if (PlayerPrefs.GetInt("lang") == 0)
                    {
                        PlayerPrefs.SetInt("lang", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("lang", 0);
                    }

                    Text titleSettingsText = gameObject.transform.parent.Find("SettingsTitle").gameObject.GetComponent<Text>();
                    Text langText = gameObject.transform.parent.Find("SettingsTitle").Find("LangText").gameObject.GetComponent<Text>();
                    Text soundText = gameObject.transform.parent.Find("SettingsTitle").Find("SoundText").gameObject.GetComponent<Text>();
                    changeTexts(new Text[] { langText, soundText, titleSettingsText }, new string[] { langTextOperator(), soundTextOperator(), titleSettingsTextOperator() } );

                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("lang")];
                    break;
                }


            // Settings SoundButton
            case ("SoundButton"):
                {
                    if (PlayerPrefs.GetInt("sound") == 0)
                    {
                        PlayerPrefs.SetInt("sound", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("sound", 0);
                    }

                    Text soundText = gameObject.transform.parent.Find("SettingsTitle").Find("SoundText").gameObject.GetComponent<Text>();
                    changeTexts(new Text[] { soundText }, new string[] { soundTextOperator() });

                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("lang")];
                    break;
                }


            // Menu PlayButton
            case ("PlayButton"):
                {
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



    private void Awake()
    {
        // SettingsButton chechs if there's no settings yet
        if (gameObject.name == "SettingsButton")
        {
            if (!PlayerPrefs.HasKey("sound"))
            {
                PlayerPrefs.SetInt("sound", 0);
            }

            if (!PlayerPrefs.HasKey("lang"))
            {
                if (Application.systemLanguage == SystemLanguage.Russian)
                {

                    PlayerPrefs.SetInt("lang", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("lang", 0);
                }
            }
        }
    }



    void Start()
    {
        screen = gameObject.transform.parent.parent;

        switch(gameObject.name)
        {
            case ("SettingsButton"):
                {
                    // SettingsButton sets all texts according to settings
                    Text titleSettingsText = gameObject.transform.parent.Find("SettingsTitle").gameObject.GetComponent<Text>();
                    Text langText = gameObject.transform.parent.Find("SettingsTitle").Find("LangText").gameObject.GetComponent<Text>();
                    Text soundText = gameObject.transform.parent.Find("SettingsTitle").Find("SoundText").gameObject.GetComponent<Text>();

                    changeTexts(new Text[] { titleSettingsText, langText, soundText }, new string[] { titleSettingsTextOperator(), langTextOperator(), soundTextOperator() });

                    break;
                }

            case ("SoundButton"):
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("sound")];
                    break;
                }

            case ("LangButton"):
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("lang")];
                    break;
                }

            default:
                break;
        }
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
