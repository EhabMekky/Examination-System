namespace ExaminationSystem;

public class MCQ_Question : Question
{
    public MCQ_Question(int answerArraySize)
    {
        AnswerArray = new Answer[answerArraySize];
    }

    public override object Clone()
    {
        var clonedQuestion = new MCQ_Question(AnswerArray.Length)
        {
            QuestionId = this.QuestionId,
            Header = this.Header,
            Body = this.Body,
            Mark = this.Mark,
            CorrectAnswer = (Answer)this.CorrectAnswer.Clone()
        };
        for (int i = 0; i < AnswerArray.Length; i++)
        {
            clonedQuestion.AnswerArray[i] = (Answer)this.AnswerArray[i].Clone();
        }
        return clonedQuestion;
    }

    public override void GetUserAnswer()
    {
        Console.WriteLine(ToString());
        for (int i = 0; i < AnswerArray.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {AnswerArray[i].AnswerText}");
        }
        Console.Write("Enter your answer (1 to {0}): ", AnswerArray.Length);
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer >= 1 && userAnswer <= AnswerArray.Length)
        {
            Console.WriteLine($"You selected: {AnswerArray[userAnswer - 1].AnswerText}");
        }
        else
        {
            Console.WriteLine("Invalid answer.");
        }
    }
}