namespace ExaminationSystem;

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion()
    {
        AnswerArray = new Answer[2];
    }

    public override object Clone()
    {
        var clonedQuestion = new TrueFalseQuestion
        {
            QuestionId = this.QuestionId,
            Header = this.Header,
            Body = this.Body,
            Mark = this.Mark,
            CorrectAnswer = (Answer)this.CorrectAnswer.Clone()
        };
        clonedQuestion.AnswerArray[0] = (Answer)this.AnswerArray[0].Clone();
        clonedQuestion.AnswerArray[1] = (Answer)this.AnswerArray[1].Clone();
        return clonedQuestion;
    }

    public override void GetUserAnswer()
    {
        Console.WriteLine(ToString());
        Console.WriteLine("1. True");
        Console.WriteLine("2. False");
        Console.Write("Enter your answer (1 or 2): ");
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer == 1)
        {
            Console.WriteLine("You selected: True");
        }
        else if (userAnswer == 2)
        {
            Console.WriteLine("You selected: False");
        }
        else
        {
            Console.WriteLine("Invalid answer.");
        }
    }

   
}