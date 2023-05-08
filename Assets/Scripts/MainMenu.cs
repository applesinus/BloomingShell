using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    float timer = 3.0f;
    bool initflowergrow = false;
    public GameObject[] flowerstages;

    // Start is called before the first frame update
    void Awake()
    {
        initflowergrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (initflowergrow)
        {
            timer -= Time.deltaTime % 60;
            if (Mathf.FloorToInt(timer % 60) < 0)
            {
                flowerstages[1].SetActive(false);
                flowerstages[2].SetActive(true);
                initflowergrow = false;
            }
            else if (Mathf.FloorToInt(timer % 60) < timer/3f)
            {
                flowerstages[0].SetActive(false);
                flowerstages[1].SetActive(true);
            }
            else if (Mathf.FloorToInt(timer % 60) < (timer/3f)*2)
            {
                flowerstages[0].SetActive(true);
            }
        }
    }
}
