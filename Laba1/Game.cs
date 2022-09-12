﻿
namespace Laba1
{
    public class Game
    {
        public bool IsOver { get; private set; }
        public Question CurentQuestion { get; private set; }

        public Game()
        {
            IsOver = false;
            CurentQuestion = FindQuestion();
        }

        private Question FindQuestion()
        {
            try
            {
                var context = new ProfessionContex();
                var question = context.Questions.Where(p => p.IsUsed == true)
                        .OrderByDescending(p => p.Professions.Count).FirstOrDefault();
                if (question == null)
                {
                    IsOver = true;
                    return null;
                }
                question.IsUsed = false;
                context.SaveChanges();
                return question;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
                return null;
            }
        }

        internal object GetQuestionsWithoutDirect()
        {
            try
            {
                var context = new ProfessionContex();
                return context.Questions.Where(q => q.IsDirectQuestion == false).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        internal Profession FindProfession(int id)
        {
            try
            {
                var context = new ProfessionContex();
                return context.Professions.Find(id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        internal void Add(string professionName, string questionText, List<int> addProfessionIds, List<int> addQuestionIds)
        {
            try
            {
                var context = new ProfessionContex();
                var userProfession = new Profession()
                {
                    Name = professionName,
                    IsUsed = true,
                    Questions = new List<Question>(),
                };
                var userQuestion = new Question()
                {
                    Text = questionText,
                    IsUsed = true,
                    Professions = new List<Profession>() { userProfession },
                };
                var directQuestion = new Question()
                {
                    Text = $"Выбранная профессия {professionName}?",
                    IsUsed = true,
                    Professions = new List<Profession>() { userProfession },
                    IsDirectQuestion = true,

                };
                userProfession.Questions.Add(directQuestion);
                if (addProfessionIds.Count != 0)
                {
                    var professions = new List<Profession>();
                    foreach (int id in addProfessionIds)
                    {
                        var pr = context.Professions.Find(id);
                        professions.Add(pr);
                    }
                    userQuestion.Professions.AddRange(professions);
                }
                if (addQuestionIds.Count != 0)
                {
                    var questions = new List<Question>();
                    foreach (int id in addQuestionIds)
                    {
                        var qs = context.Questions.Find(id);
                        questions.Add(qs);
                    }
                    userProfession.Questions.AddRange(questions);
                }
                context.Professions.Add(userProfession);
                context.Questions.AddRange(directQuestion, userQuestion);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        internal object GetAllProfession()
        {
            try
            {
                var context = new ProfessionContex();
                return context.Professions.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        internal void Yes()
        {
            if (CurentQuestion.IsDirectQuestion)
            {
                IsOver=true;
            }
            MarkDropouts(true);
            CurentQuestion = FindQuestion();

        }
        // Помечаем выбывшие вопросы и профессии
        // Производительность вышла из чата
        private void MarkDropouts(bool x)
        {
            using (var context = new ProfessionContex())
            {
                if (x)
                {
                    context.Professions.Where(p => p.Questions.Contains(CurentQuestion) == false)
                    .ToList().ForEach(p => p.IsUsed = false);
                }
                else
                {
                    var question = context.Questions.Single(p=>p.Id==CurentQuestion.Id);
                    context.Entry(question).Collection(c => c.Professions).Load();
                    question.Professions.ToList().ForEach(p => p.IsUsed = false);
                }
                var questions = context.Questions.Where(x => x.IsUsed == true).ToList();
                foreach(var question in questions)
                {
                    context.Entry(question).Collection(q => q.Professions).Load();
                    var count = question.Professions.Where(p => p.IsUsed == false).ToList().Count();
                    if (count == question.Professions.Count) question.IsUsed = false;
                }
                context.SaveChanges();
            }
        }

        internal void No()
        {
            MarkDropouts(false);
            CurentQuestion = FindQuestion();

        }

        internal void End()
        {
            try
            {
                var context = new ProfessionContex();
                context.Professions.ToList().ForEach(p => p.IsUsed = true);
                context.Questions.ToList().ForEach(p => p.IsUsed = true);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal List<Tuple<string,string>> GetBase()
        {
            try
            {
                var context = new ProfessionContex();
                var result = new List<Tuple<string, string>>();
                var questions = context.Questions.ToList();
                foreach (var question in questions)
                {
                    context.Entry(question).Collection(q => q.Professions).Load();
                    var professions = "";
                    foreach (var profession in question.Professions)
                    {
                        professions += ($"{profession.Name},");
                    }
                    result.Add(new Tuple<string, string>(question.Text, professions));
                }
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}
