namespace MinordleAPI
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int HighScore { get; set; } = 0;

        public List<int> GameResults { get; set; } = new List<int>();
        public int streak { get; set; } = 0;

        public string ProfilePicturePath { get; set; } = string.Empty;
    }
}
