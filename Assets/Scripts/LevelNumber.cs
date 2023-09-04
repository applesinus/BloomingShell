using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour
{

    private void Start()
    {
        gameObject.transform.Find("Number").gameObject.GetComponent<Text>().text = gameObject.name[11..];
    }

    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    private void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    private void OnMouseUpAsButton()
    {
        PlayerPrefs.SetInt("color", 0);
        PlayerPrefs.SetInt("AwakeLevel", 0);
        PlayerPrefs.SetInt("AwakeTurtle", System.Int32.Parse(gameObject.name[11..])-1);

        SceneManager.LoadScene("Game");
    }
}
