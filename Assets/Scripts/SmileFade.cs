using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileFade : MonoBehaviour
{
    public GameObject back, smile1, smile2, smile3, smile4, turtle;
    int speed = 250;
    public int mode = 0; // 0: stand by, 1: in, 2: out;

    private void Awake()
    {
        mode = 1;
    }

    private void Update()
    {
        switch (mode)
        {
            case 0:
                break;

            case 1:
                {
                    back.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    turtle.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile1.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile2.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile3.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile4.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);

                    if (back.GetComponent<SpriteRenderer>().color.a > 1.0f) mode = 0;
                    break;
                }

            case 2:
                {
                    back.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    turtle.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile1.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile2.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile3.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);
                    smile4.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime / 255.0f * speed);


                    if (back.GetComponent<SpriteRenderer>().color.a < 0.0f) mode = 0;
                    break;
                }
            default:
                break;
        }
        
    }

}
