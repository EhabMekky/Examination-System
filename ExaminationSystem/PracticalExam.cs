namespace ExaminationSystem;

public class PracticalExam : Exam
{
    protected PracticalExam(DateTime time, int numberOfQuestions, Question[] questions) : base(time, numberOfQuestions, questions)
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