using System;

namespace Commands.Movies
{
    public class CommandCreateMovie
    {
        private string image;
        private string title;
        private DateTime creationDate;
        private int qualification;

        public string Image { get => image; set => image = value; }
        public string Title { get => title; set => title = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public int Qualification { get => qualification; set => qualification = value; }
    }
}