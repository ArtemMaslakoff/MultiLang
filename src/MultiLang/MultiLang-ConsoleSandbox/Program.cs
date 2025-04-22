using MultiLang_Library;

internal class Program
{
    private static void Main(string[] args)
    {
        // Определение списка языков
        var languages = new List<Language>
        {
            new Language("Russian", "RU"),
            new Language("English", "ENG")
        };
        
        LanguageManager.SetLanguages(languages);
        //

        LanguageManager.SwitchLanguage("ENG");

        // Определение переводов для текстовой переменной
        MLString ArtemName = new MLString(new Dictionary<Language, string>
        {
            { new Language("Russian", "RU"), "Артем" },
            { new Language("English", "ENG"), "Artem" }
        });
        //

        Console.WriteLine(ArtemName);
    }
}