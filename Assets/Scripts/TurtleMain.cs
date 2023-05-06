using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMain : MonoBehaviour
{

    public Sprite flower1, flower2, flower3, flower4, flower5, flower6, flower7;

    public int[,,] neighbour;

    private void Awake()
    {
        // List of neighbours of all shell parts from all turtles
        neighbour = new int[1, 9, 6]
        {
            // 9 parts shell
            {
                {2, 4, 5, 7, 8, -1 }, //1
                {1, 3, 5, 6, 8, 9 }, //2
                {2, 6, 9, -1, -1, -1 }, //3
                {1, 5, -1, -1, -1, -1 }, //4
                {1, 2, 4, 6, -1, -1 }, //5
                {2, 3, 5, -1, -1, -1 }, //6
                {1, 8, -1, -1, -1, -1 }, //7
                {1, 2, 7, 9, -1, -1 }, //8
                {2, 3, 8, -1, -1, -1 } //9
            }
        };
    }
}
