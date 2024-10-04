using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemQuiz : MonoBehaviour
{
    public TextAsset QuestionSet;

    private string[] soal;

    private string[,] questionBank;


    private int questionIndex;
    private int totalQuestions;
    private bool fetchQuestion;
    private char correctAnswer;

    public Text textQuestion, textOptionA, textOptionB, textOptionC, textOptionD;

    private bool isResult;
    private float timer;
    public float gradingTime;

    private int correctAnswers, incorrectAnswers;
    private float  nilai;

    public GameObject resultPanel, imgGrading, imgResult, CorrectObj, IncorrectObj;

    public Text textResult;

    void Start()
    {
        Debug.Log("Start hanya Jalan ketika baru mulai");

        timer = gradingTime;

        soal = QuestionSet.ToString().Split('#');

        questionBank = new string[soal.Length, 6];
        totalQuestions = soal.Length;
        ProcessQuestions();

        fetchQuestion = true; 
        DisplayQuestion();

        print(questionBank[1,3]);
    }

    void Update()
    {
        Debug.Log("Update Jalan setiap frame");

        if(resultPanel.activeSelf)
        {
            gradingTime -= Time.deltaTime;

            if (isResult)
            {
                imgGrading.SetActive(true);
                imgResult.SetActive(false);

                if (gradingTime <= 0)
                {
                    textResult.text = "Benar : " + correctAnswers + "\nSalah : " + incorrectAnswers + "\n\nNilai : " + CalculateScore();
                      
                    imgGrading.SetActive(false);
                    imgResult.SetActive(true);

                    gradingTime = 0;

                }
            } 
            else
            {
                imgGrading.SetActive(true);
                imgResult.SetActive(false);

                if (gradingTime <= 0)
                {
                    resultPanel.SetActive(false);
                    gradingTime = timer;

                    DisplayQuestion();
                }
            }
        }
    }

    private void ProcessQuestions()
    {
        for (int i=0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');
            for(int j = 0; j < tempSoal.Length; j++)
            {
                questionBank[i, j] = tempSoal[j];
                continue;
            }
            continue;
        }
    }

    private void DisplayQuestion()
    {
        if (questionIndex<totalQuestions)
        {
            if(fetchQuestion)
            {
                textQuestion.text = questionBank[questionIndex, 0];
                textOptionA.text = questionBank[questionIndex, 1];
                textOptionB.text = questionBank[questionIndex, 2];
                textOptionC.text = questionBank[questionIndex, 3];
                textOptionD.text = questionBank[questionIndex, 4];
                correctAnswer = questionBank[questionIndex, 5][0];

                fetchQuestion = false;
            }
        }
    }
   
    public void Option(string ChooseOption)
    {
       VerifyAnswer(ChooseOption[0]);
        
       if(questionIndex == totalQuestions - 1)
        {
            isResult = true;
        }
        else
        {
            questionIndex++;
            fetchQuestion = true;
        }

        resultPanel.SetActive(true);
    }

    private float CalculateScore()
    {
        return nilai = (float)correctAnswers / totalQuestions * 100;
    }

    public void VerifyAnswer(char huruf)
    {
        if (huruf.Equals(correctAnswer))
        {
            CorrectObj.SetActive(true);
            IncorrectObj.SetActive(false);
            correctAnswers++;
        }
        else
        {
            IncorrectObj.SetActive(true);
            CorrectObj.SetActive(false);
            incorrectAnswers++;
        }
    }
}
