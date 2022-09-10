
namespace Laba1
{
    public class Game
    {
        // Запоминаем вопросы где ответ был "ДА"
        private List<int> QuestionIds;
        public bool IsOver { get; private set; }
        public Question CurentQuestion { get; private set; }

        public Profession Answer { get; private set; } = null!;

        public Game()
        {
            QuestionIds = new List<int>();
            CurentQuestion = FindQuestion();
            IsOver = false;
        }

        private Question FindQuestion()
        {
            using (var context = new ProfessionContex())
            {
                var question=context.Questions.Where(p => p.IsUsed == true)
                    .OrderByDescending(p => p.Professions.Count).FirstOrDefault();
                if(question == null)
                {

                    IsOver = true;
                    return null;
                }
                question.IsUsed = false;
                context.SaveChanges();
                return question;
            }
        }

        internal void Yes()
        {
            QuestionIds.Add(CurentQuestion.Id);
            MarkDropouts(true);
            CurentQuestion = FindQuestion();

        }
        // Помечаем выбывшие вопросы и профессии
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
                    var count = 0;
                    foreach(var profession in question.Professions)
                    {
                        if (profession.IsUsed==false) count++;
                    }
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
            using(var context=new ProfessionContex())
            {
                context.Professions.ToList().ForEach(p => p.IsUsed = true);
                context.Questions.ToList().ForEach(p => p.IsUsed = true);
                context.SaveChanges();
            }
        }
    }
}
