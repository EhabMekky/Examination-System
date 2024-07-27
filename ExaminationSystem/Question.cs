namespace ExaminationSystem;

public abstract class Question: ICloneable, IComparable<Question>
{
    public int QuestionId { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }
    public Answer[] AnswerArray { get; set; }
    public Answer CorrectAnswer { get; set; }

    public abstract object Clone();

    public int CompareTo(Question? other)
    {
        if (other == null) return 1;
        return QuestionId.CompareTo(other.QuestionId);
    }

    public override string ToString()
    {
        return $"Question {QuestionId}: {Header}\n{Body}\nMarks: {Mark}";
    }
    public abstract void GetUserAnswer();
}