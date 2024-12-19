using System;
namespace File_Labs
{
    internal class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
