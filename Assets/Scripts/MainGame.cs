using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    public int lang; // lang 0: English, 1: Russian
    float red, green, blue; // rgb of turtle eyes

    // task is a class for tasks
    class Task
    {
        public int mode = 1; // mode (basic)1: neighbour, 2: mirror
        public int[] flowers = new int[2] { 1, 1 }; // two flowers (basic)of type 1
        public string[] description = {
            "This is a standart description, if you see this, something's going wrong :(",
            "Это стандартное описание, если ты его видишь, что-то пошло не по плану :("
        };
    }



    Level[] plot; // plot is the whole plot
    public int currentTurtle; // number of current turtle
    public int currentLevel; // number of current level


    // tasks is a class for a single turtle
    class Turtle
    {
        public Color eyes;
        //public Vector3Int eyes;
        public Task[] tasks; // list of tasks for this turtle
        public int turtle = 9; // number of shell parts

        public void Create()
        {
            GameObject.Find("GameField").GetComponent<MainGame>().CreateTurtle(turtle);
            return;
        }
    }



    // level is a class for a list of turtles on a level
    class Level
    {
        public Turtle[] level;
    }



    public int mode; // mode 0: standing by, 1: deleting old turtle, 2: creating new turtle, 3: planting flower
    public GameObject turtle9;
    GameObject turtle;
    public SmileFade SmileFade;
    Dictionary<string, GameObject> turtleparts; // parts of a turtle. t = tail, h = head, lfp = left front paw, rfp = right front paw, lbp = left back paw, rbp = right back paw.
    float partsposition = 0;
    bool isgoingup = false;

    
    void turtleAnimation()
    {
        if (partsposition < -10.0f)
        {
            isgoingup = true;
        } else if (partsposition > 10.0f)
        {
            isgoingup = false;
        }

        if (isgoingup)
        {
            partsposition += Time.deltaTime * 25;
        } else
        {
            partsposition -= Time.deltaTime * 25;
        }
        turtleparts["h"].transform.Rotate(Vector3.forward * partsposition / 90);
        turtleparts["t"].transform.Rotate(Vector3.forward * partsposition / -90);
        turtleparts["lfp"].transform.Rotate(Vector3.forward * partsposition / -70);
        turtleparts["lbp"].transform.Rotate(Vector3.forward * partsposition / 90);
        turtleparts["rfp"].transform.Rotate(Vector3.forward * partsposition / 70);
        turtleparts["rbp"].transform.Rotate(Vector3.forward * partsposition / -90);
    }



    // CreateTurtle creates turtle of needed type
    public void CreateTurtle(int shells)
    {
        GameObject newTurtle;
        switch (shells)
        {
            case 9:
                {
                    newTurtle = Instantiate(turtle9);
                    break;
                }

            default:
                newTurtle = null;
                break;
        }
        newTurtle.transform.SetParent(gameObject.transform);
        newTurtle.transform.localScale = new Vector3(1, 1, 1);
        newTurtle.transform.localPosition = new Vector3(0, -1080, 150);
        newTurtle.transform.name = "Turtle";
        newTurtle.transform.Find("Sprites").Find("Thead").Find("Teyes").GetComponent<SpriteRenderer>().color = plot[currentLevel].level[currentTurtle].eyes;
        turtle = newTurtle;

        turtleparts = new Dictionary<string, GameObject>()
        {
            {"t", turtle.transform.Find("Sprites").Find("Ttail").gameObject },
            {"h", turtle.transform.Find("Sprites").Find("Thead").gameObject },
            {"lfp", turtle.transform.Find("Sprites").Find("TpawFL").gameObject },
            {"rfp", turtle.transform.Find("Sprites").Find("TpawFR").gameObject },
            {"lbp", turtle.transform.Find("Sprites").Find("TpawBL").gameObject },
            {"rbp", turtle.transform.Find("Sprites").Find("TpawBR").gameObject },
        };

        mode = 2;

        // Task cards appearing
        GameObject tasksfield = gameObject.transform.parent.Find("Tasks").gameObject;
        for (int i = 0; i < plot[currentLevel].level[currentTurtle].tasks.Length; i++)
        {
            GameObject card = tasksfield.transform.Find("TaskCard" + (i + 1).ToString()).gameObject;
            card.SetActive(true);
            card.transform.Find("Text").GetComponent<Text>().text = plot[currentLevel].level[currentTurtle].tasks[i].description[0];
        }
        return;
    }



    int[,] colors; // Flower to color converter



    private void Awake()
    {
        // colors of flowers initialazing
        colors = new int[8, 3]
        {
            {167, 0, 255}, // 1 flower is velvet
            {0, 167, 255}, // 2 flower is light blue
            {255, 0, 0}, // 3 flower is red
            {0, 255, 0}, // 4 flower is green
            {255, 255, 0}, // 5 flower is yellow
            {255, 167, 0}, // 6 flower is orange
            {0, 0, 255}, // 7 flower is blue
            {0, 0, 0}, // blank color
        };

        // initialazing counters
        currentTurtle = 0;
        currentLevel = 0;


        // This is a database of all levels and turtles
        // Plot is a whole sequense of levels
        plot = new Level[1] {

            // First level
            new Level()
            {
                level = new Turtle[3] {
                    // turtle 1
                    new Turtle
                    {
                        turtle = 9,
                        eyes = new Color(255, 0, 0, 255),
                        tasks = new Task[2]
                        {
                            new Task
                            {
                                mode = 1,
                                flowers = new int[2] {1, 1},
                                description = new string[2] {
                                    "Turtle wants two velvet flowers to be close to each other!",
                                    "Черепашка хочет, чтобы два фиолетовых цветка были рядом!"
                                },
                            },
                            new Task
                            {
                                mode = 1,
                                flowers = new int[2] {6, 7},
                                description = new string[2] {
                                    "Turtle wants orange and blue flowers to be close to each other!",
                                    "Черепашка хочет, чтобы оранжевый и синий цветки были рядом!"
                                },
                            }
                        }
                    },

                    // turtle 2
                    new Turtle
                    {
                        turtle = 9,
                        eyes = new Color(0, 255, 0, 255),
                        tasks = new Task[1]
                        {
                            new Task
                            {
                                mode = 1,
                                flowers = new int[2] {2, 2},
                                description = new string[2] {
                                    "Turtle wants two light blue flowers to be close to each other!",
                                    "Черепашка хочет чтобы два голубых цветка были рядом!"
                                },
                            }
                        }
                    },


                    // turtle 3
                    new Turtle
                    {
                        turtle = 9,
                        eyes = new Color(0, 0, 0, 255),
                        tasks = new Task[1]
                        {
                            new Task
                            {
                                mode = 1,
                                flowers = new int[2] {2, 5},
                                description = new string[2] {
                                    "Turtle wants light blue and yellow flowers to be close to each other!",
                                    "Черепашка хочет, чтобы голубой и жёлтый цветки были рядом!"
                                },
                            }
                        }
                    },
                }
            }
        }
        ;
    }

    // Start is called before the first frame update
    void Start()
    {
        plot[currentLevel].level[currentTurtle].Create();
        mode = 2;
        red = 0f;
        green = 0f;
        blue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(mode)
        {
            case 0:
                break;

            // going away and destroy
            // then creating turtle
            case 1:
                {
                    turtle.transform.position = turtle.transform.position + Vector3.up * Time.deltaTime * 3;
                    turtleAnimation();

                    if (turtle.transform.localPosition.y > 1080)
                    {
                        GameObject tasksfield = gameObject.transform.parent.Find("Tasks").gameObject;
                        for (int i = 0; i < plot[currentLevel].level[currentTurtle].tasks.Length; i++)
                        {
                            GameObject card = tasksfield.transform.Find("TaskCard" + (i + 1).ToString()).gameObject;
                            card.SetActive(false);
                        }

                        Destroy(turtle.gameObject);
                        SmileFade.mode = 2;
                        mode = 2;
                        currentTurtle++;
                        plot[currentLevel].level[currentTurtle].Create();
                    }
                    break;
                }

            // deleting turtle
            case 2:
                {
                    turtle.transform.position = turtle.transform.position + Vector3.up * Time.deltaTime * 3;
                    turtleAnimation();

                    if (turtle.transform.localPosition.y >= 0)
                    {
                        turtle.transform.localPosition = new Vector3(0, 0, 150);
                        gameObject.transform.parent.Find("Smile").gameObject.SetActive(false);
                        for (int emoji = 0; emoji < 4; emoji++)
                        {
                            gameObject.transform.parent.Find("Smile").Find("smile" + emoji.ToString()).gameObject.SetActive(false);
                        }
                        mode = 0;
                    }
                    break;
                }

            // planting a flower on head of a turtle
            // and cheching the progress
            case 3:
                {
                    GameObject flower = turtle.transform.Find("Sprites").Find("Thead").Find("Tflower").gameObject;
                    if (!flower.activeInHierarchy)
                    {
                        // Exceptions
                        if (PlayerPrefs.GetInt("Shell1") == 0) PlayerPrefs.SetInt("Shell1", 8);
                        if (PlayerPrefs.GetInt("Shell4") == 0) PlayerPrefs.SetInt("Shell4", 8);
                        if (PlayerPrefs.GetInt("Shell7") == 0) PlayerPrefs.SetInt("Shell7", 8);

                        red = (colors[PlayerPrefs.GetInt("Shell1") - 1, 0] + colors[PlayerPrefs.GetInt("Shell4") - 1, 0] + colors[PlayerPrefs.GetInt("Shell7") - 1, 0]) / 3.0f / 255;
                        green = (colors[PlayerPrefs.GetInt("Shell1") - 1, 1] + colors[PlayerPrefs.GetInt("Shell4") - 1, 1] + colors[PlayerPrefs.GetInt("Shell7") - 1, 1]) / 3.0f / 255;
                        blue = (colors[PlayerPrefs.GetInt("Shell1") - 1, 2] + colors[PlayerPrefs.GetInt("Shell4") - 1, 2] + colors[PlayerPrefs.GetInt("Shell7") - 1, 2]) / 3.0f / 255;
                        Color flowercolor = new Color (red, green, blue, 1.0f);
                        flower.transform.Find("TflowerColor").GetComponent<SpriteRenderer>().color = flowercolor;
                        flower.SetActive(true);
                    }
                    flower.transform.localScale = flower.transform.localScale + new Vector3(0.01f, 0.01f, 0) * Time.deltaTime * 30;

                    if (flower.transform.localScale.x >= 1)
                    {
                        int tasksCount = plot[currentLevel].level[currentTurtle].tasks.Length;
                        int[] done = new int[tasksCount];

                        int tasksdone = 0; // count of done tasks
                        int smile = 0;
                        // 0 - vary sad (nothing's done)
                        // 1 - sad (if less than half tasks are done AND color isn't done)
                        // 2 - neutral (if more/exactly half tasks are done OR color is done)
                        // 3 - happy (if all tasks are done AND color is done)

                        TurtleMain turtlemain = turtle.GetComponent<TurtleMain>();

                        for (int i = 0; i < tasksCount; i++)
                        {
                            done[i] = 0;
                            for (int shell = 1; shell <= plot[currentLevel].level[currentTurtle].turtle; shell++)
                            {
                                if (plot[currentLevel].level[currentTurtle].tasks[i].mode == 1) {
                                    for (int neighbour = 0; neighbour < 6; neighbour++)
                                    {
                                        if (turtlemain.neighbour[0, shell-1, neighbour] != -1) {
                                            int needed1 = plot[currentLevel].level[currentTurtle].tasks[i].flowers[0];
                                            int needed2 = plot[currentLevel].level[currentTurtle].tasks[i].flowers[1];
                                            if (
                                                (
                                                needed1 == PlayerPrefs.GetInt("Shell" + shell.ToString())
                                                &&
                                                needed2 == PlayerPrefs.GetInt("Shell" + turtlemain.neighbour[0, shell-1, neighbour].ToString())
                                                )
                                                ||
                                                (
                                                needed2 == PlayerPrefs.GetInt("Shell" + shell.ToString())
                                                &&
                                                needed1 == PlayerPrefs.GetInt("Shell" + turtlemain.neighbour[0, shell-1, neighbour].ToString())
                                                )
                                               ) { done[i] = 1; }
                                        }
                                    }
                                }
                            }
                        }
                        
                        for (int i = 0; i < tasksCount; i++)
                        {
                            if (done[i] == 1) tasksdone++;
                        }

                        
                        if (
                            (red * 255 - plot[currentLevel].level[currentTurtle].eyes.r > -0.01f && red * 255 - plot[currentLevel].level[currentTurtle].eyes.r < 0.01f)
                            &&
                            (green * 255 - plot[currentLevel].level[currentTurtle].eyes.g > -0.01f && green * 255 - plot[currentLevel].level[currentTurtle].eyes.g < 0.01f)
                            &&
                            (blue * 255 - plot[currentLevel].level[currentTurtle].eyes.b > -0.01f && blue * 255 - plot[currentLevel].level[currentTurtle].eyes.b < 0.01f)
                            )
                        {

                            if (tasksdone == tasksCount) { smile = 3; } else { smile = 2; }
                        }
                        else
                        {
                            if (tasksdone == 0)
                            {
                                smile = 0;
                            }
                            else
                            {
                                if (tasksCount - tasksdone >= tasksCount / 2)
                                {
                                    smile = 1;
                                }
                                else
                                {
                                    smile = 2;
                                }
                            }
                        }


                        Debug.Log(smile);

                        gameObject.transform.parent.Find("Smile").gameObject.SetActive(true);
                        gameObject.transform.parent.Find("Smile").Find("smile" + smile.ToString()).gameObject.SetActive(true);
                        SmileFade.mode = 1;
                        mode = 1;
                        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    }
                    break;
                }

            default:
                mode = 0;
                break;
        }
    }
}
