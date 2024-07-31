using System;

namespace ExaminationSystem;

public class FinalExam : Exam
{
    public override void ShowExam()
    {
        Console.WriteLine("Final Exam:");
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

        Console.WriteLine("Questions and Answers:");
        foreach (var question in Questions)
        {
            question.DisplayQuestion();
            Console.WriteLine("Answers:");
            foreach (var answer in question.AnswerArray)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine($"Correct Answer: {question.CorrectAnswer.AnswerText}");
            Console.WriteLine($"Your Answer: {question.UserAnswer?.AnswerText ?? "No Answer"}");
        }

        Console.WriteLine($"Total Marks: {totalMarks}");
        Console.WriteLine($"Your Marks: {userMarks}");
        Console.WriteLine($"Final Grade: {(double)userMarks / totalMarks * 100}%");
        Console.WriteLine(IsTimeExceeded() ? "You exceeded the time limit." : "You finished within the time limit.");
    }
}