using System.ComponentModel;

namespace MultiLang_Library
{
    public class MLString : INotifyPropertyChanged
    {
        private Language _currentLanguage;

        public Dictionary<Language, string> Values { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MLString()
        {
            Values = new Dictionary<Language, string>();
            foreach (var language in LanguageManager.Languages)
            {
                Values.Add(language, "");
            }
            _currentLanguage = LanguageManager.CurrentLanguage;

            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        public MLString(Dictionary<Language, string> values)
        {
            Values = new Dictionary<Language, string>(values);
            _currentLanguage = LanguageManager.CurrentLanguage;

            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        public string CurrentValue
        {
            get
            {
                if (Values.TryGetValue(_currentLanguage, out var value))
                {
                    return value;
                }
                return string.Empty;
            }
        }

        private void OnLanguageChanged()
        {
            _currentLanguage = LanguageManager.CurrentLanguage;
            OnPropertyChanged(nameof(CurrentValue));
        }

        public void SwitchLanguage(Language newLanguage)
        {
            _currentLanguage = newLanguage;
            OnPropertyChanged(nameof(CurrentValue));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return CurrentValue;
        }
    }
}
