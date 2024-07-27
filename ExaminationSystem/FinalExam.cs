using System;

namespace ExaminationSystem;

public class FinalExam : Exam
{

    public DateTime ExamDate { get; set; }
        public int Duration { get; set; } // Duration in minutes

        public FinalExam(int numberOfQuestions) : base(numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine($"Exam Date: {ExamDate}\nDuration: {Duration} minutes");
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
                else if (question is TrueFalseQuestion)
                {
                    Console.WriteLine($"1. True\n2. False");
                }
            }
        }

        public void ShowQuestionsAndAnswers()
        {
            Console.WriteLine($"Questions and Answers for Final Exam:");
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Header}");
                if (question is MCQ_Question mcq)
                {
                    Console.WriteLine($"Correct Answer: {mcq.CorrectAnswer.AnswerText}");
                }
                else if (question is TrueFalseQuestion tf)
                {
                    Console.WriteLine($"Correct Answer: {tf.CorrectAnswer.AnswerText}");
                }
            }
        }

        public void ShowGrade(int[] studentAnswers)
        {
            if (studentAnswers.Length != Questions.Length)
            {
                throw new ArgumentException("Number of student answers must match the number of questions.");
            }

            int totalMarks = 0;
            int obtainedMarks = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                totalMarks += Questions[i].Mark;

                if (Questions[i] is MCQ_Question mcq)
                {
                    if (mcq.AnswerArray[studentAnswers[i]].AnswerId == mcq.CorrectAnswer.AnswerId)
                    {
                        obtainedMarks += mcq.Mark;
                    }
                }
                else if (Questions[i] is TrueFalseQuestion tf)
                {
                    if (tf.AnswerArray[studentAnswers[i]].AnswerId == tf.CorrectAnswer.AnswerId)
                    {
                        obtainedMarks += tf.Mark;
                    }
                }
            }

            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Obtained Marks: {obtainedMarks}");
            Console.WriteLine($"Grade: {(obtainedMarks * 100 / totalMarks):F2}%");
        }

        public override object Clone()
        {
            var clonedExam = new FinalExam(NumOfQuestions)
            {
                TimeOfExam = this.TimeOfExam,
                ExamDate = this.ExamDate,
                Duration = this.Duration,
            };
            for (int i = 0; i < Questions.Length; i++)
            {
                clonedExam.Questions[i] = (Question)this.Questions[i].Clone();
            }
            return clonedExam;
        }

}