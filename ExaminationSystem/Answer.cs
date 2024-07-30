namespace ExaminationSystem;

public class Answer
{
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }

    public override string ToString()
    {
        return $"Answer {AnswerId}: {AnswerText}";
    }
}