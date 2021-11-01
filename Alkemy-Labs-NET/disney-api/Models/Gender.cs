using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mgenders")]

public class Gender
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]

    private int id;
    private string nombre;
    private string image;
    private int idMovie;
    [ForeignKey("idMovie")]
    private Movie movie;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Image { get => image; set => image = value; }
    public int IdMovie { get => idMovie; set => idMovie = value; }
    public Movie Movie { get => movie; set => movie = value; }
}