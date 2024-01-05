namespace MiniApiThree.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<InterestLink> InterestLinks { get; set; }
    }
}
