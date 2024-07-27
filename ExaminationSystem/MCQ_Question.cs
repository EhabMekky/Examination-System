namespace ExaminationSystem;

public class MCQ_Question:Question
{
    public Answer[] Answers { get; set; }
    public Answer CorrectAnswer { get; set; }


    public MCQ_Question(string header, string body, int mark) : base(header, body, mark)
    {
    }
}