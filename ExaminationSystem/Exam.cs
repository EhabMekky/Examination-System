namespace ExaminationSystem;

public abstract class Exam
{
    public DateTime ExamTime { get; set; }
    public int NumOfQuestions { get; set; }
    public Question[] Questions { get; set; }
    
    protected Exam(DateTime time, int numberOfQuestions, Question[] questions)
    {
        ExamTime = time;
        NumOfQuestions = numberOfQuestions;
        Questions = questions;
    }

    public abstract void ShowExam();
}