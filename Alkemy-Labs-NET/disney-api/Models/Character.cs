using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("characters")]
public class Character
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    private int id;
    public string image;
    public string name;
    public int age;
    public double weight;
    public string history;
    public int idMovie;
    [ForeignKey("idMovie")]
    public Movie movie;

    public int Id { get => id; set => id = value; }
    public string Image { get => image; set => image = value; }
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public double Weight { get => weight; set => weight = value; }
    public string History { get => history; set => history = value; }
    public int IdMovie { get => idMovie; set => idMovie = value; }
    public Movie Movie { get => movie; set => movie = value; }
}