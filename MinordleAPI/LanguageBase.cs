namespace MinordleAPI
{
    public class LanguageBase
    {
        public int Id { get; set; }
        public string LanguageName { get; set; } = string.Empty;// hint
        public string LanguageFamily { get; set; } = string.Empty;// hint
        public string LanguageExample { get; set; } = string.Empty;// hint
        public string YellowImg { get; set; } = string.Empty;//result
        public string GreenImg { get; set; } = string.Empty;//result
        public string? LanguageDescription { get; set; } = string.Empty;//result
        public string? audioFile { get; set; } = string.Empty;//hint


    }
}
