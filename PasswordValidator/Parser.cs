using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class Parser : IParser
    {
        private static readonly string RegexPattern =
            @"(?<MinCount>[\d]{1,})-(?<MaxCount>[\d]{1,})";
        private const int TermsCount = 3;
        public IEnumerable<PasswordRule> Parse(IEnumerable<string> input, out List<string> errors)
        {
            Regex reg = new Regex(RegexPattern);
            List<PasswordRule> passwords = new List<PasswordRule>();
            errors = new List<string>();

            var line = 0;
            foreach (string s in input)
            {
                ++line;
                var divided = s.Split(' ');
                if(divided.Length != TermsCount)
                {
                    errors.Add($"Line {line}: Too few terms in the password rule.");
                    continue;
                }
                var match = reg.Match(divided[1]);
                KeyValuePair<int, int> current = default;
                
                if (match.Success)
                    current =
                        new KeyValuePair<int, int>(int.Parse(match.Groups["MinCount"].ToString()), int.Parse(match.Groups["MaxCount"].ToString()));
                else
                {
                    errors.Add($"Line {line}: Error in letter count term");
                    continue;
                }
                passwords.Add(new PasswordRule
                {
                    Letter = divided[0].Single(),
                    MinCount = current.Key,
                    MaxCount = current.Value,
                    Password = divided[2]
                });

            }

            return passwords;
        }
    }
}
