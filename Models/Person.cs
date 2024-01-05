namespace MiniApiThree.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<InterestLink> InterestLinks { get; set; }
    }
}
