namespace ExaminationSystem;

public class Answer : ICloneable
{
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }

    public object Clone()
    {
        return new Answer { AnswerId = this.AnswerId, AnswerText = this.AnswerText };
    }

    public override string ToString()
    {
        return $"Answer {AnswerId}: {AnswerText}";
    }
}