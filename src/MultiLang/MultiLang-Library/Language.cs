namespace MultiLang_Library
{
    public class Language
    {
        public string Name { get; private set; }
        public string ShortName { get; private set; }

        public Language()
        {
            Name = string.Empty;
            ShortName = string.Empty;
        }
        public Language(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Language otherLanguage)
            {
                return Name.Equals(otherLanguage.Name, StringComparison.OrdinalIgnoreCase) &&
                       ShortName.Equals(otherLanguage.ShortName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name.ToLowerInvariant(), ShortName.ToLowerInvariant());
        }
    }
}
