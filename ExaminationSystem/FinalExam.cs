namespace ExaminationSystem;

public class FinalExam : Exam
{
    protected FinalExam(DateTime time, int numberOfQuestions, Question[] questions) : base(time, numberOfQuestions, questions)
    {
    }

    public override void ShowExam()
    {
        foreach (var question in Questions)
        {
            Console.WriteLine(question.ToString());
        }
    }
}