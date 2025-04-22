namespace MultiLang_Library
{
    public static class LanguageManager
    {
        public static Language CurrentLanguage { get; private set; }
        public static List<Language> Languages { get; private set; }

        public static event Action? LanguageChanged;

        static LanguageManager()
        {
            Languages = new List<Language>();
            CurrentLanguage = new Language("", "");
        }

        public static void SetLanguages(List<Language> languages)
        {
            if (languages == null) throw new ArgumentNullException(nameof(languages));
            Languages = languages;

            CurrentLanguage = Languages[0];
        }

        public static void SwitchLanguage(string languageShortName)
        {
            var newLanguage = Languages.FirstOrDefault(lang => lang.ShortName.Equals(languageShortName, StringComparison.OrdinalIgnoreCase));
            if (newLanguage != null)
            {
                CurrentLanguage = newLanguage;
                OnLanguageChanged();
            }
        }

        private static void OnLanguageChanged()
        {
            LanguageChanged?.Invoke();
        }
    }
}
