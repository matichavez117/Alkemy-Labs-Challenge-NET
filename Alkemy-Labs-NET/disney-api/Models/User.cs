using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]

public class User
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]

    private int id;
    public string email;
    public string username;
    public string password;

    public int Id { get => id; set => id = value; }
    public string Email { get => email; set => email = value; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
}