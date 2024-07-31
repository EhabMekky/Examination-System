using System;

namespace ExaminationSystem;

public class PracticalExam : Exam
{
    public override void ShowExam()
    {
        Console.WriteLine("Practical Exam:");
        Console.WriteLine($"Duration: {Duration} minutes");
        foreach (var question in Questions)
        {
            question.DisplayQuestion();
        }
    }

    public override void ShowResults()
    {
        int totalMarks = CalculateTotalMarks();
        int userMarks = CalculateUserMarks();
        TimeSpan timeTaken = CalculateTimeTaken();

        Console.WriteLine("Right Answers:");
        foreach (var question in Questions)
        {
            question.DisplayQuestion();
            Console.WriteLine($"Correct Answer: {question.CorrectAnswer.AnswerText}");
            Console.WriteLine($"Your Answer: {question.UserAnswer?.AnswerText ?? "No Answer"}");
        }

        Console.WriteLine($"Total Marks: {totalMarks}");
        Console.WriteLine($"Your Marks: {userMarks}");
        Console.WriteLine($"Final Grade: {(double)userMarks / totalMarks * 100}%");
    }
}

