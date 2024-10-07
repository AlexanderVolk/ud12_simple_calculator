using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    public GameObject[] DigitControllers;

    public void Display(string text)
    {
        text = string.IsNullOrEmpty(text) ? "0" : text;
        if (text.Length > DigitControllers.Length)
        {
            DisplayError();
            return;
        }
        char[] textChars = text.ToCharArray();
        char[] resultChars = new char[DigitControllers.Length];
        int leadingZeroCount = resultChars.Length - textChars.Length;

        for (int i=0; i<resultChars.Length; i++)
        {
            char c = i < leadingZeroCount ? '_' : textChars[i - leadingZeroCount];
            displayCharAtPlace(c, i);
        }
    }

    public void DisplayError()
    {
        Display("error");
    }

    private void displayCharAtPlace(char c, int place)
    {
        DigitControllers[place].GetComponent<MapController>().LoadLevel(c.ToString());
    }
}