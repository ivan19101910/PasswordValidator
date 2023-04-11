namespace PasswordValidator
{
    internal interface IParser
    {
        IEnumerable<PasswordRule> Parse(IEnumerable<string> input, out List<string> errors);
    }
}
