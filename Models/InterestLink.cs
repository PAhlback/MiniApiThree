namespace MiniApiThree.Models
{
    public class InterestLink
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public virtual Person Person { get; set; }
        public virtual Interest Interest { get; set; }
    }
}
