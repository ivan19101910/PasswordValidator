namespace PasswordValidator
{
    public struct PasswordRule
    {
        public string Password { get; set; }
        public char Letter { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
    }
}
