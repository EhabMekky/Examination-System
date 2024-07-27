namespace ExaminationSystem;

public class TrueFalseQuestion : Question
{
    public bool CorrectAnswer { get; set; }

    public TrueFalseQuestion(string header, string body, int mark, bool correctAnswer) : base(header, body, mark)
    {
        CorrectAnswer = correctAnswer;
    }
}