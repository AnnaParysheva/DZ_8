using System;
using System.Collections.Generic;


namespace File_Labs
{
    internal class Project
    {
        /// <summary>
        /// описание проекта
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// сроки выполнения
        /// </summary>
        public DateTime CompletionDate { get; }
        /// <summary>
        /// инициатор проекта(заказчик)
        /// </summary>
        public Person Customer { get; }
        /// <summary>
        /// человек, ответственный за проект
        /// </summary>
        public Person Teamleader { get; }
        /// <summary>
        /// задачи по проекту
        /// </summary>
        public List<Task> Tasks = new List<Task>();
        /// <summary>
        /// статус
        /// </summary>
        public ProjectStatus Status { get; private set; }
        public Project(string description, DateTime completionDate, Person customer, Person teamleader)
        {
            Description = description;
            CompletionDate = completionDate;
            Customer = customer;
            Teamleader = teamleader;
            Status = ProjectStatus.Проект;
        }
        public void AddTask(Task task)
        {
            if (Status != ProjectStatus.Проект)
            {
                Console.WriteLine("Задачи можно добавлять только в статусе 'Проект'.");
                return;
            }
            Tasks.Add(task);
        }
        public void ChangeStatus(ProjectStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Проект '{Description}' переведен в статус '{Status}'.");
        }
        public bool IsCompleted()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Выполнена)
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"Проект: {Description}, Статус: {Status}, Тимлид: {Teamleader}";
        }
    }
}
