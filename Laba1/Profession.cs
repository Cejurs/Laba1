namespace Laba1
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsUsed { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = null!;

    }
}