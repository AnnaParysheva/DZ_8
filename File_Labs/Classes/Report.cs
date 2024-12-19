using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Labs
{
    internal class Report
    {
        /// <summary>
        /// Текст отчета
        /// </summary>
        public string Text { get; }
        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// Исполнитель
        /// </summary>
        public Person Assignee { get; }
        public Report(string text, DateTime date, Person assignee)
        {
            Text = text;
            Date = date;
            Assignee = assignee;
        }
        public override string ToString()
        {
            return $"Отчет: {Text}, Дата: {Date}, Исполнитель: {Assignee}";
        }
    }
}
