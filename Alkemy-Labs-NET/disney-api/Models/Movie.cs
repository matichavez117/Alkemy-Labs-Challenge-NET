using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("movies")]

public class Movie
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]

    private int id;
    public string image;
    public string title;
    public DateTime creationDate;
    public int qualification;

    public int Id { get => id; set => id = value; }
    public string Image { get => image; set => image = value; }
    public string Title { get => title; set => title = value; }
    public DateTime CreationDate { get => creationDate; set => creationDate = value; }
    public int Qualification { get => qualification; set => qualification = value; }
}