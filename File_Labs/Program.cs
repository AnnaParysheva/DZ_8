using File_Labs;
using System;
using System.Collections.Generic;

namespace File_Labs
{
    enum ProjectStatus
    {
        Проект, 
        Исполнение, 
        Закрыт
    }
    enum TaskStatus
    {
        Назначена, 
        В_работе, 
        На_проверке,
        Выполнена
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Console.ReadKey();
        }
        static void Task1()
        {
            List<Person> team = new List<Person>
            {
                new Person("Аня"),
                new Person("Настя"),
                new Person("Петр"),
                new Person("Ксюша"),
                new Person("Игорь"),
                new Person("Катя"),
                new Person("Никита"),
                new Person("Паша"),
                new Person("Вася"),
                new Person("Надя")
            };
            // Создаем проект
            Person initiator = new Person("Заказчик Иван");
            Person teamLead = new Person("Тимлид Дмитрий");
            Project project = new Project("Разработка приложения",DateTime.Now.AddDays(30), initiator, teamLead);
            Task task1 = new Task("Реализовать функционал авторизации", DateTime.Now.AddDays(5), initiator);
            Task task2 = new Task("Разработать дизайн интерфейса", DateTime.Now.AddDays(7), initiator);
            Task task3 = new Task("Написать тестовые сценарии", DateTime.Now.AddDays(3), initiator);
            Task task4 = new Task("Оптимизировать базу данных", DateTime.Now.AddDays(10), initiator);
            Task task5 = new Task("Разработать API", DateTime.Now.AddDays(15), initiator);
            Task task6 = new Task("Тестирование приложения", DateTime.Now.AddDays(20), initiator);
            Task task7 = new Task("Настройка CI/CD", DateTime.Now.AddDays(25), initiator);
            Task task8 = new Task("Документирование кода", DateTime.Now.AddDays(28), initiator);
            Task task9 = new Task("Презентация проекта", DateTime.Now.AddDays(30), initiator);
            Task task10 = new Task("Подготовка к релизу", DateTime.Now.AddDays(30), initiator);
            // Добавляем задачи в проект
            project.AddTask(task1);
            project.AddTask(task2);
            project.AddTask(task3);
            project.AddTask(task4);
            project.AddTask(task5);
            project.AddTask(task6);
            project.AddTask(task7);
            project.AddTask(task8);
            project.AddTask(task9);
            project.AddTask(task10);
            // Назначаем задачи исполнителям
            task1.AssignTo(team[0]);
            task2.AssignTo(team[1]);
            task3.AssignTo(team[2]);
            task4.AssignTo(team[3]);
            task5.AssignTo(team[4]);
            task6.AssignTo(team[5]);
            task7.AssignTo(team[6]);
            task8.AssignTo(team[7]);
            task9.AssignTo(team[8]);
            task10.AssignTo(team[9]);
            // Переводим проект в статус "Исполнение"
            project.ChangeStatus(ProjectStatus.Исполнение);
            // Исполнители берут задачи в работу
            task1.StartWork();
            task2.StartWork();
            task3.StartWork();
            task4.StartWork();
            task5.StartWork();
            task6.StartWork();
            task7.StartWork();
            task8.StartWork();
            task9.StartWork();
            task10.StartWork();
            // Делегирование задачи
            task1.DelegateTo(team[1]);
            // Отказываемся от задачи
            task2.Reject(); 
            // Создаем отчеты
            task1.CreateReport("Реализация авторизации завершена", DateTime.Now, team[0]);
            task3.CreateReport("Тестовые сценарии написаны", DateTime.Now, team[2]);
            task4.CreateReport("База данных оптимизирована", DateTime.Now, team[3]);
            task5.CreateReport("API разработано", DateTime.Now, team[4]);
            task6.CreateReport("Тестирование завершено", DateTime.Now, team[5]);
            task7.CreateReport("CI/CD настроен", DateTime.Now, team[6]);
            task8.CreateReport("Документация готова", DateTime.Now, team[7]);
            task9.CreateReport("Презентация подготовлена", DateTime.Now, team[8]);
            task10.CreateReport("Релиз подготовлен", DateTime.Now, team[9]);
            // Утверждаем отчеты
            task1.ApproveReport();
            task3.ApproveReport();
            task4.ApproveReport();
            task5.ApproveReport();
            task6.ApproveReport();
            task7.ApproveReport();
            task8.ApproveReport();
            task9.ApproveReport();
            task10.ApproveReport();
            // Проверяем, закрыт ли проект
            if (project.IsCompleted())
            {
                project.ChangeStatus(ProjectStatus.Закрыт);
                Console.WriteLine("Проект закрыт.");
            }
        }
    }
}
