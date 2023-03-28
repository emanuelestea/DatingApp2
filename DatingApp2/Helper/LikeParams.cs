namespace DatingApp2.Helper
{
    public class LikeParams : PaginationParams
    {
        public int UserId { get; set; }
        public string Predicate {  get; set; }
    }
}
