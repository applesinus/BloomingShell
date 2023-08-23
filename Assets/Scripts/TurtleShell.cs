using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleShell : MonoBehaviour
{
    public TurtleMain turtle;
    public GameObject FlowerPrefab;
    GameObject Flower;
    int[] neighbour; // list of neighbour shells
    int shell; // shell number of this particular shell

    

    // When shell part is clicked
    private void OnMouseDown()
    {
        int color = PlayerPrefs.GetInt("color");
        if (color != 0)
        {
            // destroying already existing flower
            if (PlayerPrefs.GetInt(gameObject.name) != 0)
            {
                Destroy(gameObject.transform.Find("Flower").gameObject);
            }

            PlayerPrefs.SetInt(gameObject.name, color);

            // planting flower sequence
            GameObject plantedFlower = Instantiate(FlowerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            plantedFlower.transform.SetParent(gameObject.transform);
            plantedFlower.transform.localScale = new Vector3(1, 1, 1);
            plantedFlower.transform.localPosition = new Vector3(0, 0, -220);
            plantedFlower.transform.name = "Flower";
            Flower = plantedFlower;
            // changing sprite
            switch (color)
            {
                case 1:
                    {
                        Flower.GetComponent<Image>().sprite = turtle.flower1;
                        break;
                    }
                case 2:
                    {
                        Flower.GetComponent<Image>().sprite = turtle.flower2;
                        break;
                    }
                case 3:
                    {
                        Flower.GetComponent<Image>().sprite = turtle.flower3;
                        break;
                    }
                case 4:
                    {
                        Flower.GetComponent<Image>().sprite = turtle.flower4;
                        break;
                    }
                case 5:
                    {
                        Flower.GetComponent<Image>().sprite = turtle.flower5;
                        break;
                    }
                case 6:
                    {
                        Flower.GetComponent<Image>().sprite = turtle.flower6;
                        break;
                    }
                case 7:
                    {
                        Flower.GetComponent<Image>().sprite = turtle.flower7;
                        break;
                    }

                default:
                    break;
            }


        }
    }


    void Start()
    {
        PlayerPrefs.SetInt(gameObject.name, 0);
        shell = gameObject.name[5] - 48;

        // Creating the list of neighbours
        int counter = 0; // counter - count of neighbour shells
        for (int i = 0; i < 6; i++) {
            if (turtle.neighbour[0, shell-1, i] != -1) counter++;
        }
        int[] neighbour = new int[counter];
        for (int i=0; i<counter; i++)
        {
            neighbour[i] = turtle.neighbour[0, shell-1, i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
