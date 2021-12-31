using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TDisplay : MonoBehaviour
{
    public TMP_Text p1Text;
    public TMP_Text p2Text;

    public TMP_Text p1LText;
    public TMP_Text p2LText;

    public void ChangeP1Health(float health)
    {
        p1Text.text = health.ToString();
    }
    public void ChangeP2Health(float health)
    {
        p2Text.text = health.ToString();

    }
    public void ChangeP1Lives(int lives)
    {
        p1LText.text = "Lives: " + lives.ToString();
    }
    public void ChangeP2Lives(int lives)
    {
        p2LText.text = "Lives: " + lives.ToString();
    }
}
