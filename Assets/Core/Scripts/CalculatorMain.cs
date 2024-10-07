using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

public class CalculatorMain : MonoBehaviour
{
    public TMP_InputField FirstNumber;
    public TMP_InputField SecondNumber;
    public GameObject DisplayControllerObject;

    public void TriggerSum()
    {
        try
        {
            int result = getFirstNumber() + getSecondNumber();
            DisplayControllerObject.GetComponent<DisplayController>().Display(result.ToString());
        }
        catch (System.Exception exception)
        {
            displayError();
            throw exception;
        }
    }

    public void TriggerSubtraction()
    {
        try
        {
            int result = getFirstNumber() - getSecondNumber();
            DisplayControllerObject.GetComponent<DisplayController>().Display(result.ToString());
        }
        catch (System.Exception exception)
        {
            displayError();
            throw exception;
        }
    }

    public void TriggerMultiplication()
    {
        try
        {
            int result = getFirstNumber() * getSecondNumber();
            DisplayControllerObject.GetComponent<DisplayController>().Display(result.ToString());
        }
        catch (System.Exception exception)
        {
            displayError();
            throw exception;
        }
    }

    public void TriggerDivision()
    {
        try
        {
            int result = getFirstNumber() / getSecondNumber();
            DisplayControllerObject.GetComponent<DisplayController>().Display(result.ToString());
        } catch (DivideByZeroException exception)
        {
            Debug.LogException(exception);
            displayError();
        }
        catch (System.Exception exception)
        {
            displayError();
            throw exception;
        }
    }

    private int getFirstNumber()
    {
       return int.Parse(FirstNumber.text.Trim().ToLower());
    }

    private int getSecondNumber()
    {
        return int.Parse(SecondNumber.text.Trim().ToLower());

    }

    private void display(string text)
    {
        DisplayControllerObject.GetComponent<DisplayController>().Display(text);
    }

    private void displayError()
    {
        DisplayControllerObject.GetComponent<DisplayController>().DisplayError();
    }
}
