using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EquationGenerator : MonoBehaviour
{
    public GameObject SquarePrefab;
    private string equation;
    public float xIntervalBetweenBlocks = .5f, yIntervalBetweenBlocks = .5f;
    public int equationLength = 5;
    const float squareSize = 1.8f;
    const int addition = 1, subtraction = 2, multiply = 3, dividing = 4;
    void Start()
    {
        MakeEquation();

    }
    public void MakeEquation()
    {
        RemoveEquation();
        GameObject[] squaresArr;
        equation = GenerateRandomEquation(); //убираем лишние пробелы
        int length = equation.Length;

        squaresArr = new GameObject[length];

        for (int i = 0; i < length; i++)
        {
            squaresArr[i] = Instantiate(SquarePrefab, transform);
            squaresArr[i].transform.position = transform.position;
            squaresArr[i].GetComponentInChildren<TextMeshPro>().text
                = char.ToString(equation[i]);



            if (xIntervalBetweenBlocks > 0 && yIntervalBetweenBlocks > 0)
            {
                squaresArr[i].transform.position +=
                    new Vector3(i * (squareSize + xIntervalBetweenBlocks),
                    i * (squareSize + yIntervalBetweenBlocks), 0);
            }
            else if (xIntervalBetweenBlocks <= 0 && yIntervalBetweenBlocks > 0)
            {
                squaresArr[i].transform.position -=
                    new Vector3(0, i * (squareSize + yIntervalBetweenBlocks), 0);
            }
            else if (xIntervalBetweenBlocks > 0 && yIntervalBetweenBlocks <= 0)
            {
                squaresArr[i].transform.position +=
                    new Vector3(i * (squareSize + xIntervalBetweenBlocks), 0, 0);
            }
        }
    }
    private void RemoveEquation()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }

    private string GenerateRandomEquation()
    {
        System.Random rnd = new System.Random();

        int firstNum = rnd.Next(1, 10);
        int secondNum = rnd.Next(1, 10);

        int intOperator = rnd.Next(1, 4); // + , -, *, /
        char charOperator = ' ';
        int result = 0;
        switch (intOperator)
        {
            case addition:
                {
                    charOperator = '+';
                    result = firstNum + secondNum;
                    break;
                }
            case subtraction:
                {
                    charOperator = '-';
                    if (firstNum > secondNum) result = firstNum - secondNum;
                    else
                    {
                        result = secondNum - firstNum;
                        (firstNum, secondNum) = (secondNum, firstNum);
                    }
                    break;
                }
            case multiply:
                {
                    charOperator = 'x';
                    result = firstNum * secondNum;
                    break;
                }
            case dividing:
                {

                    charOperator = '/';
                    firstNum = firstNum * secondNum;
                    result = firstNum / secondNum;
                    break;
                }
            default:
                {
                    Debug.LogError("errorInOperatorGeneration");
                    break;
                }
        }
        // возвращаем уравнение в формате строки для дальнейшего использования
        return firstNum.ToString() + charOperator + secondNum.ToString() + '='
             + result.ToString();
    }

}
