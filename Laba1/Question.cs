
namespace Laba1
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsUsed { get; set; }

        public bool IsDirectQuestion { get; set; }
        public virtual List<Profession> Professions { get; set; }

    }
}
