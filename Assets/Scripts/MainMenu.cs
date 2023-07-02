using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextAsset JSON;
    public GameObject textfield;

    [System.Serializable]
    public class Player
    {
        public string pop;
        public int kek;
    }

    [System.Serializable]
    public class Playerlist
    {
        public Player[] player;
    }

    public Playerlist newplayerlist;


    float timer = 1.8f;
    bool initflowergrow = false;
    public GameObject[] flowerstages;

    // Start is called before the first frame update
    void Awake()
    {
        initflowergrow = true;
    }

    private void Start()
    {
        newplayerlist = new Playerlist();
        newplayerlist = JsonUtility.FromJson<Playerlist>(JSON.text);
        textfield.GetComponent<Text>().text = newplayerlist.player[1].kek.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (initflowergrow)
        {
            timer -= Time.deltaTime % 60f;
            if (Mathf.FloorToInt(timer % 60f) < 0)
            {
                flowerstages[1].SetActive(false);
                flowerstages[2].SetActive(true);
                initflowergrow = false;
            }
            else if (Mathf.FloorToInt(timer % 60f) < timer/3f)
            {
                flowerstages[0].SetActive(false);
                flowerstages[1].SetActive(true);
            }
            else if (Mathf.FloorToInt(timer % 60f) < (timer/3f)*2)
            {
                flowerstages[0].SetActive(true);
            }
        }
    }
}
