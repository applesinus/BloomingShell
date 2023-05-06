using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOK : MonoBehaviour
{
    public MainGame MainGame;

    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector3(85, 85, 85);
    }
    private void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector3(100, 100, 100);
        MainGame.mode = 3;
    }
}
