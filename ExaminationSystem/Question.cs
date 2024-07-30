namespace ExaminationSystem;

public abstract class Question : IComparable<Question>
{
    public int QuestionId { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }
    public Answer[] AnswerArray { get; set; }
    public Answer CorrectAnswer { get; set; }
    public Answer UserAnswer { get; set; }

    
    public abstract void GetUserAnswer();
    public abstract void DisplayQuestion();

    public bool IsCorrect()
    {
        return UserAnswer != null && UserAnswer.AnswerId == CorrectAnswer.AnswerId;
    }

    public int CompareTo(Question other)
    {
        return QuestionId.CompareTo(other.QuestionId);
    }
}