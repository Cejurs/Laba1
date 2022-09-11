namespace Laba1
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUsed { get; set; }

        public virtual List<Question> Questions { get; set; }


    }
}