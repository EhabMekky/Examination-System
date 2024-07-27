using System;

namespace ExaminationSystem;

public class PracticalExam : Exam
{
        public PracticalExam(int numberOfQuestions) : base(numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine(this.ToString());
            foreach (var question in Questions)
            {
                Console.WriteLine(question.ToString());
                if (question is MCQ_Question mcq)
                {
                    for (int i = 0; i < mcq.AnswerArray.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {mcq.AnswerArray[i].AnswerText}");
                    }
                }
            }
        }

        public void ShowCorrectAnswers()
        {
            Console.WriteLine($"Correct Answers for Practical Exam:");
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Header}");
                if (question is MCQ_Question mcq)
                {
                    Console.WriteLine($"Correct Answer: {mcq.CorrectAnswer.AnswerText}");
                }
            }
        }

        public override object Clone()
        {
            var clonedExam = new PracticalExam(NumOfQuestions)
            {
                TimeOfExam = this.TimeOfExam,
            };
            for (int i = 0; i < Questions.Length; i++)
            {
                clonedExam.Questions[i] = (Question)this.Questions[i].Clone();
            }
            return clonedExam;
        }
    }
