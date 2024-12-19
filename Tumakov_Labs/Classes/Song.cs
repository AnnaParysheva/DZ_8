using System;
using System.Collections.Generic;

namespace Tumakov_Labs
{
    class Song
    {
        /// <summary>
        /// Название песни
        /// </summary>
        public string Name;
        /// <summary>
        /// Автор песни
        /// </summary>
        public string Author;
        /// <summary>
        /// Связь с предыдущей песней в списке
        /// </summary>
        public Song Prev;
        // Конструктор с параметрами название и автор песни, указатель на предыдущую песню инициализируется null
        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null; 
        }
        public Song(string name, string author, Song prev) 
        {
            Name=name;
            Author = author;
            Prev = prev;
        }

        // Метод для заполнения поля Name
        public void SetName(string name)
        {
            Name = name;
        }
        // Метод для заполнения поля Author
        public void SetAuthor(string author)
        {
            Author = author;
        }
        // Метод для заполнения поля Prev
        public void SetPrev(Song prev)
        {
            Prev = prev;
        }
        // Метод для печати названия песни и ее исполнителя
        public void PrintInfo()
        {
            Console.WriteLine($"Песня: {Name}, Исполнитель: {Author}");
        }

        // Метод, который возвращает название и исполнителя в виде строки
        public string Title()
        {
            return $"{Name} - {Author}";
        }

        // Переопределение метода Equals для сравнения двух песен
        public override bool Equals(object obj)
        {
            Song other = obj as Song;
            if (other == null)
                return false;
            return Name == other.Name && Author == other.Author;
        }

        // Переопределение метода GetHashCode 
        public override int GetHashCode()
        {
            return (Name + Author).GetHashCode();
        }
    }
}
