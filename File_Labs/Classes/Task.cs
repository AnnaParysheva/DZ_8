using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Labs
{
    internal class Task
    {
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Сроки задачи
        /// </summary>
        public DateTime CompletionDate { get; }
        /// <summary>
        /// Инициатор задачи
        /// </summary>
        public Person Initiator { get; }
        /// <summary>
        /// Исполнитель
        /// </summary>
        public Person Assignee { get; private set; }
        /// <summary>
        /// Статус задачи
        /// </summary>
        public TaskStatus Status { get; private set; }
        /// <summary>
        /// Отчеты по задачи
        /// </summary>
        public List<Report> Reports { get; } = new List<Report>();
        public Task(string description, DateTime completionDate, Person initiator)
        {
            Description = description;
            CompletionDate = completionDate;
            Initiator = initiator;
            Status = TaskStatus.Назначена;
        }
        // Метод для назначения задачи исполнителю
        public void AssignTo(Person assignee)
        {
            Assignee = assignee;
            Status = TaskStatus.Назначена;
            Console.WriteLine($"Задача '{Description}' назначена исполнителю {assignee}.");
        }
        // Метод для взятия задачи в работу
        public void StartWork()
        {
            if (Assignee == null)
            {
                Console.WriteLine("Задача не имеет исполнителя.");
                return;
            }
            Status = TaskStatus.В_работе;
            Console.WriteLine($"Задача '{Description}' взята в работу исполнителем {Assignee}.");
        }
        // Метод для делегирования задачи
        public void DelegateTo(Person newAssignee)
        {
            Assignee = newAssignee;
            Status = TaskStatus.Назначена;
            Console.WriteLine($"Задача '{Description}' передана исполнителю {newAssignee}.");
        }
        // Метод для отклонения задачи
        public void Reject()
        {
            Assignee = null;
            Console.WriteLine($"Задача '{Description}' отклонена.");
        }
        // Метод для создания отчета
        public void CreateReport(string text, DateTime date, Person assignee)
        {
            if (Status != TaskStatus.В_работе)
            {
                Console.WriteLine("Отчет можно создать только для задачи в статусе 'В работе'.");
                return;
            }
            Reports.Add(new Report(text, date, assignee));
            Status = TaskStatus.На_проверке;
            Console.WriteLine($"Отчет по задаче '{Description}' создан и отправлен на проверку.");
        }
        // Метод для утверждения отчета
        public void ApproveReport()
        {
            if (Status != TaskStatus.На_проверке)
            {
                Console.WriteLine("Отчет можно утвердить только для задачи в статусе 'На проверке'.");
                return;
            }
            Status = TaskStatus.Выполнена;
            Console.WriteLine($"Отчет по задаче '{Description}' утвержден. Задача выполнена.");
        }
        // Метод для возврата отчета на доработку
        public void ReturnReport()
        {
            if (Status != TaskStatus.На_проверке)
            {
                Console.WriteLine("Отчет можно вернуть на доработку только для задачи в статусе 'На проверке'.");
                return;
            }
            Status = TaskStatus.В_работе;
            Console.WriteLine($"Отчет по задаче '{Description}' возвращен на доработку.");
        }
        public override string ToString()
        {
            return $"Задача: {Description}, Статус: {Status}, Исполнитель: {Assignee}";
        }
    }
}
