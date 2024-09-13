
namespace IAmHungry.Domain
{
    public static class MealKind
    {
        public static List<string> Meat()
        {
            return new List<string>
            {
                "anglick",
                "dančí",
                "dršťk",
                "frankfurtsk",
                "hovězí",
                "játr",
                "jehně",
                "jelení",
                "kačen",
                "kachní",
                "kančí",
                "klobás",
                "krkovi",
                "krůtí",
                "kuře",
                "masem",
                "masov",
                "pancett",
                "panenk",
                "párk",
                "prosciutto",
                "řízek",
                "roštěn",
                "salám",
                "segedín",
                "sekaná",
                "škvark",
                "slanin",
                "špekáč",
                "šunk",
                "svíčková",
                "telecí",
                "utopenec",
                "uzené maso",
                "uzenin",
                "uzeným masem",
                "vepř",
                "vrabec",
                "zabíjačk",
                "žebra",
                "zvěřin"
            };
        }

        public static List<string> Fish()
        {
            return new List<string>
            {
                "candát",
                "fish",
                "losos",
                "mořsk",
                "pstruh",
                "ryb",
                "tresk",
                "tuňák",
                "vlk",
            };
        }

        public static List<string> Vege()
        {
            return new List<string>
            {
                "vege",
                "tempeh",
                "sójov",
            };
        }

        public static string Soup()
        {
            return "polévk";
        }
    }
}
