namespace SimpleBlog.Domain.Blogs
{
    public class Base
    {
        public Base()
        {
            CreationDate = DateTime.Now;    
        }
        public int Id { get; private set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        //public User CreatedBy { get; set; }
    }
}