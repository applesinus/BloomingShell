using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBed : MonoBehaviour
{

    // When flower with color is clicked
    private void OnMouseDown()
    {
        int color = gameObject.name[2] - 48;
        if (PlayerPrefs.GetInt("color") == color)
        {
            PlayerPrefs.SetInt("color", 0);
        } else {
            PlayerPrefs.SetInt("color", color);
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
