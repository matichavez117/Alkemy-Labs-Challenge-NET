using System;

namespace Commands.Movies
{
    public class CommandEditMovie
    {
        private int idMovie;
        public string image;
        public string title;
        public DateTime creationDate;
        public int qualification;

        public string Image { get => image; set => image = value; }
        public string Title { get => title; set => title = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public int Qualification { get => qualification; set => qualification = value; }
        public int IdMovie { get => idMovie; set => idMovie = value; }
    }
}