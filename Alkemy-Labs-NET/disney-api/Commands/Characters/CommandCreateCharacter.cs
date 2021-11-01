namespace Commands.Characters
{
    public class CommandCreateCharacter
    {

        private string image;
        private string name;
        private int age;
        private double weight;
        private string history;
        private int idMovie;

        public string Image { get => image; set => image = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public double Weight { get => weight; set => weight = value; }
        public string History { get => history; set => history = value; }
        public int IdMovie { get => idMovie; set => idMovie = value; }
    }
}

