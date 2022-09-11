
namespace Laba1
{
    public class Game
    {
        // Запоминаем вопросы где ответ был "ДА"
        public bool IsOver { get; private set; }
        public Question CurentQuestion { get; private set; }

        public Game()
        {
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

        internal object GetAllQuestion()
        {
            var context = new ProfessionContex();
            return context.Questions.Local.ToBindingList();
        }

        internal object GetAllProfession()
        {
            var context=new ProfessionContex();
            return context.Professions.Local.ToBindingList();
        }

        internal void Yes()
        {
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
            using(var context=new ProfessionContex())
            {
                context.Professions.ToList().ForEach(p => p.IsUsed = true);
                context.Questions.ToList().ForEach(p => p.IsUsed = true);
                context.SaveChanges();
            }
        }
    }
}
