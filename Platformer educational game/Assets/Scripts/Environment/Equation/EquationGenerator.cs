using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EquationGenerator : MonoBehaviour
{
    public GameObject SquarePrefab;
    public float xIntervalBetweenBlocks, yIntervalBetweenBlocks;
    public int extraDigitCount;
    private List<Block> equationList = new List<Block>();
    const float squareSize = 1.8f;
    const int addition = 1, subtraction = 2, multiply = 3, dividing = 4;
    private int removingCount = 0;
    void Start()
    {
        MakeEquation();

    }
    public void MakeEquation()
    {
        RemoveEquation();
        GenerateRandomEquation();

        AddExtraDigits();
        int length = equationList.Count;
        GameObject[] squaresArr = new GameObject[length]; //Массив блоков, из которых строится уравнение

        for (int i = 0; i < length; i++)
        {
            // Создаем блок, и помещаем в массив 
            squaresArr[i] = Instantiate(SquarePrefab, transform);
            squaresArr[i].transform.position = transform.position;
            squaresArr[i].GetComponentInChildren<TextMeshPro>().text
                = char.ToString(equationList[i].Character);

            // Распологаем блоки относительно друг друга в зависимости от заданных параметров
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
        for (int i = 0; i < length; i++)
        {
            if (equationList[i].IsExtra == true)
            {
                squaresArr[i].tag = "Extra Equation Block";
            }
        }

    }


    private void GenerateRandomEquation()
    {
        System.Random rnd = new System.Random();

        int firstNum = rnd.Next(1, 8);
        int secondNum = rnd.Next(1, 8);
        int intOperator = rnd.Next(1, 4); // +, -, *, /
        char charOperator = ' ';
        int result = 0;

        switch (intOperator)
        {
            //Совершаем разные действия над числами в зависимости от оператора
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
                    Debug.LogError("Error In Operator Generation");
                    break;
                }
        }

        // уравнение в формате строки
        string equation = firstNum.ToString() + charOperator
            + secondNum.ToString() + '=' + result.ToString();

        // Перемещаем уравнение в список пользовательского типа для удобства
        for (int i = 0; i < equation.Length; i++)
        {
            equationList.Add(new Block(equation[i], false));
        }

    }
    private void AddExtraDigits()
    {
        System.Random rnd = new System.Random();

        for (int i = 0; i < extraDigitCount; i++)
        {
            int extraDigit = rnd.Next(1, 10);
            int extraDigitPos = rnd.Next(0, equationList.Count);

            equationList.Insert(extraDigitPos, new Block(extraDigit.ToString()[0], true));
        }
    }

    public void Choice(GameObject block)
    {
        if (block.CompareTag("Equation Block"))
        {

        }
        else if (block.CompareTag("Extra Equation Block"))
        {
            block.GetComponent<DestroyBlock>().DestroyWithFX();
            ++removingCount;
            if (removingCount == extraDigitCount)
            {
                GetComponent<LevelFinishing>().FinishLevel();
            }
        }
    }
    private void RemoveEquation()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
        removingCount = 0;
        if (equationList.Count > 0)
        {
            for (int i = equationList.Count - 1; i >= 0; i--)
            {
                equationList.Remove(equationList[i]);
                Debug.Log(equationList.Count);
            }
        }
    }

    class Block
    {
        public char Character;
        public bool IsExtra = false;
        public Block(char character, bool isExtra)
        { Character = character; IsExtra = isExtra; }
    }
}
