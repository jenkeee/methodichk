using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumTarget : MonoBehaviour
{
    public int Score = 0;
    public GameObject ScoreText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) Count();
    }
    public void Count()
    {
        Score++;
        ScoreText.GetComponent<Text>().text = "закидано какахами: " + Score.ToString() + "/ 4.";
    }
}
