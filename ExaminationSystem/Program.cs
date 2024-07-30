using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExaminationSystem;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter Subject ID: ");
        int subjectId = int.Parse(Console.ReadLine());

        Console.Write("Enter Subject Name: ");
        string subjectName = Console.ReadLine();

        Subject subject = new Subject(subjectId, subjectName);

        Console.Write("Enter Exam Type (1 for Final, 2 for Practical): ");
        int examTypeInput = int.Parse(Console.ReadLine());
        ExamType examType = (ExamType)(examTypeInput - 1);

        Console.Write("Enter Number of Questions: ");
        int numberOfQuestions = int.Parse(Console.ReadLine());

        subject.CreateExam(examType, numberOfQuestions);
        
        Console.Write("Enter Exam Duration (minutes): ");
        int duration = int.Parse(Console.ReadLine());
        
        subject.Exam.Duration = duration;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            if (examType == ExamType.Final)
            {
                Console.Write($"Enter Question {i + 1} Type (1 for True/False, 2 for MCQ): ");
                int questionType = int.Parse(Console.ReadLine());

                Console.Write($"Enter Question {i + 1} Header: ");
                string header = Console.ReadLine();

                Console.Write($"Enter Question {i + 1} Body: ");
                string body = Console.ReadLine();

                Console.Write($"Enter Question {i + 1} Mark: ");
                int mark = int.Parse(Console.ReadLine());

                if (questionType == 1)
                {
                    var question = new TrueFalseQuestion
                    {
                        QuestionId = i + 1,
                        Header = header,
                        Body = body,
                        Mark = mark,
                        AnswerArray = new Answer[]
                        {
                            new Answer { AnswerId = 1, AnswerText = "True" },
                            new Answer { AnswerId = 2, AnswerText = "False" }
                        }
                    };

                    Console.Write($"Enter Correct Answer for Question {i + 1} (1 for True, 2 for False): ");
                    int correctAnswer = int.Parse(Console.ReadLine());
                    question.CorrectAnswer = question.AnswerArray[correctAnswer - 1];

                    subject.Exam.Questions[i] = question;
                }
                else if (questionType == 2)
                {
                    Console.Write($"Enter Number of Answers for Question {i + 1}: ");
                    int numberOfAnswers = int.Parse(Console.ReadLine());

                    var question = new MCQ_Question(numberOfAnswers)
                    {
                        QuestionId = i + 1,
                        Header = header,
                        Body = body,
                        Mark = mark
                    };

                    for (int j = 0; j < numberOfAnswers; j++)
                    {
                        Console.Write($"Enter Answer {j + 1} Text: ");
                        string answerText = Console.ReadLine();
                        question.AnswerArray[j] = new Answer { AnswerId = j + 1, AnswerText = answerText };
                    }

                    Console.Write($"Enter Correct Answer for Question {i + 1} (1 to {numberOfAnswers}): ");
                    int correctAnswer = int.Parse(Console.ReadLine());
                    question.CorrectAnswer = question.AnswerArray[correctAnswer - 1];

                    subject.Exam.Questions[i] = question;
                }
            }
            else if (examType == ExamType.Practical)
            {
                Console.Write($"Enter Question {i + 1} Header: ");
                string header = Console.ReadLine();

                Console.Write($"Enter Question {i + 1} Body: ");
                string body = Console.ReadLine();

                Console.Write($"Enter Question {i + 1} Mark: ");
                int mark = int.Parse(Console.ReadLine());

                Console.Write($"Enter Number of Answers for Question {i + 1}: ");
                int numberOfAnswers = int.Parse(Console.ReadLine());

                var question = new MCQ_Question(numberOfAnswers)
                {
                    QuestionId = i + 1,
                    Header = header,
                    Body = body,
                    Mark = mark
                };

                for (int j = 0; j < numberOfAnswers; j++)
                {
                    Console.Write($"Enter Answer {j + 1} Text: ");
                    string answerText = Console.ReadLine();
                    question.AnswerArray[j] = new Answer { AnswerId = j + 1, AnswerText = answerText };
                }

                Console.Write($"Enter Correct Answer for Question {i + 1} (1 to {numberOfAnswers}): ");
                int correctAnswer = int.Parse(Console.ReadLine());
                question.CorrectAnswer = question.AnswerArray[correctAnswer - 1];

                subject.Exam.Questions[i] = question;
            }
        }

        Console.Clear();
        
        foreach (var question in subject.Exam.Questions)
        {
            question.DisplayQuestion();
            question.GetUserAnswer();
        }
        
        // Show the exam details and results
        subject.Exam.ShowExam();
        subject.Exam.ShowResults();
    }


    public enum ExamType
    {
        Final,
        Practical
    }
}

