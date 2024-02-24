namespace Classwork_16._02._24_auth_authorization__2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }

        public string GetHeading()
        {
            string[] words = Content.Split(" ");

            string heading = string.Join(" ", words.Take(3));

            string temp = heading + "...";

            return temp;
        }
    }
}
