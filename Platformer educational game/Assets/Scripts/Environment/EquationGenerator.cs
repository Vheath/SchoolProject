using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EquationGenerator : MonoBehaviour
{
    [SerializeField] private GameObject SquarePrefab;
    [SerializeField] private string equation;
    [SerializeField] private float xIntervalBetweenBlocks, yIntervalBetweenBlocks;
    [SerializeField] private int equationLength = 5;
    const float squareSize = 1.8f;
    void Start()
    {
        MakeEquation();

    }

    void Update()
    {

    }
    private void MakeEquation()
    {
        equation = equation.Replace(" ", "");
        int length = equation.Length;
        for (int i = 0; i < length; i++)
        {
            GameObject square = Instantiate(SquarePrefab, transform);
            square.transform.position = transform.position;

            square.GetComponentInChildren<TextMeshPro>().text
                = char.ToString(equation[i]);



            if (xIntervalBetweenBlocks > 0 && yIntervalBetweenBlocks > 0)
            {
                square.transform.position +=
                    new Vector3(i * (squareSize + xIntervalBetweenBlocks),
                    i * (squareSize + yIntervalBetweenBlocks), 0);
            }
            else if (xIntervalBetweenBlocks <= 0 && yIntervalBetweenBlocks > 0)
            {
                square.transform.position -=
                    new Vector3(0, i * (squareSize + yIntervalBetweenBlocks), 0);
            }
            else if (xIntervalBetweenBlocks > 0 && yIntervalBetweenBlocks <= 0)
            {
                square.transform.position +=
                    new Vector3(i * (squareSize + xIntervalBetweenBlocks), 0, 0);
            }
        }
    }

    private void GenerateRandomEquation()
    {
        int tempEq = equationLength - 2; //Без '=' и оператора будет 3 цифры
        for (int i = 0; i < equationLength; i++)
        {
            
        }
    }

}
