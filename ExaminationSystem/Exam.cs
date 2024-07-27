using System;

namespace ExaminationSystem;

public abstract class Exam
{
    public TimeSpan TimeOfExam { get; set; }
    public int NumOfQuestions { get; set; }
    public Question[] Questions { get; set; }
    
    public ExamType Type { get; set; }
    
    
    public Exam(int numberOfQuestions)
    {
        NumOfQuestions = numberOfQuestions;
        Questions = new Question[numberOfQuestions];
    }

    public abstract void ShowExam();
    public abstract object Clone();

    public override string ToString()
    {
        return $"Exam: Questions: {NumOfQuestions}, Exam Time: {TimeOfExam} ";
    }

    public enum ExamType
    {
        Final,
        Practical
    }
}