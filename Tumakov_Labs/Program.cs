using System;
using System.Collections.Generic;

namespace Tumakov_Labs
{
    enum Bank_schet
    {
        Current,
        Saving
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Task9_1();
            Task9_2();
            Task9_3();
            TaskDZ9_1();
            Console.ReadKey();
        }
        static void Task9_1()
        {
            Console.WriteLine("Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить\r\nметоды заполнения полей. Вместо этих методов создать конструкторы. Переопределить\r\nконструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор\r\nдля заполнения поля тип банковского счета, конструктор для заполнения баланса и типа\r\nбанковского счета. Каждый конструктор должен вызывать метод, генерирующий номер\r\nсчета.");
            BankAccount myAccount = new BankAccount(100000.00m, Bank_schet.Saving);
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            myAccount.AccountReplenishment(5000.00m);
            myAccount.AccountWithdrawal(2000.00m);
            Console.WriteLine("\nВторой счет: ");
            BankAccount fromAccount = new BankAccount(500.00m, Bank_schet.Current);
            fromAccount.PrintAccountInfo();
            myAccount.Trasfer(fromAccount, myAccount, 100.00m);
            Console.WriteLine("\nПосле изменения:");
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            Console.WriteLine("\nВторой счет: ");
            fromAccount.PrintAccountInfo();
        }
        static void Task9_2()
        {
            Console.WriteLine("Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию\r\nо всех банковских операциях. При изменении баланса счета создается новый объект класса\r\nBankTransaction, который содержит текущую дату и время, добавленную или снятую со\r\nсчета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса\r\nпередается один параметр – сумма. В классе банковский счет добавить закрытое поле типа\r\nSystem.Collections.Queue, которое будет хранить объекты класса BankTransaction для\r\nданного банковского счета; изменить методы снятия со счета и добавления на счет так,\r\nчтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в\r\nпеременную типа System.Collections.Queue.");
            BankAccount myAccount = new BankAccount(100000.00m, Bank_schet.Saving);
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            myAccount.AccountReplenishment(5000.00m);
            myAccount.AccountWithdrawal(2000.00m);
            Console.WriteLine("\nВторой счет: ");
            BankAccount fromAccount = new BankAccount(500.00m, Bank_schet.Current);
            fromAccount.PrintAccountInfo();
            myAccount.Trasfer(fromAccount, myAccount, 100.00m);
            Console.WriteLine("\nПосле изменения:");
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            Console.WriteLine("\nВторой счет: ");
            fromAccount.PrintAccountInfo();
            Console.WriteLine("\nИстория операций: ");
            myAccount.PrintTransactionHistory();
        }
        static void Task9_3()
        {
            Console.WriteLine("Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о\r\nпроводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод\r\nGC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод\r\nзавершения для указанного объекта.");
            BankAccount myAccount = new BankAccount(10000.00m, Bank_schet.Saving);
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            myAccount.AccountReplenishment(5000.00m);
            myAccount.AccountWithdrawal(2000.00m);
            Console.WriteLine("\nВторой счет: ");
            BankAccount fromAccount = new BankAccount(500.00m, Bank_schet.Current);
            fromAccount.PrintAccountInfo();
            myAccount.Trasfer(fromAccount, myAccount, 100.00m);
            Console.WriteLine("\nПосле изменения:");
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            Console.WriteLine("\nВторой счет: ");
            fromAccount.PrintAccountInfo();
            Console.WriteLine("\nИстория операций: ");
            myAccount.PrintTransactionHistory();
            myAccount.Dispose();
        }
        static void TaskDZ9_1()
        {
            Console.WriteLine("Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие\r\nконструкторы:\r\n1) параметры конструктора – название и автор песни, указатель на предыдущую песню\r\nинициализировать null.\r\n2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main\r\nсоздать объект mySong. Возникнет ли ошибка при инициализации объекта mySong\r\nследующим образом: Song mySong = new Song(); ?\r\nИсправьте ошибку, создав необходимый конструктор.");
            List<Song> songs = new List<Song>();
            // Song mySong = new Song();-так сделать нельзя, возникнет ошибка, т.к. нет конструктора, который принимает 0 аргументов
            Song song1 = new Song("Antonio Vivaldi", "Spring" );
            songs.Add(song1);
            Song song2 = new Song ("Antonio Vivaldi", "Spring", song1);
            songs.Add(song2);
            Song song3 = new Song ("Antonio Vivaldi", "Summer", song2);
            songs.Add(song3);
            Song song4 = new Song ("Ludwig van Beethoven", "Sonata for piano N14", song3);
            songs.Add(song4);
            foreach (Song song in songs)
            {
                song.PrintInfo();
            }
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine($"\nПервая и вторая песни одинаковы: {songs[0].Title()}");
            }
            else
            {
                Console.WriteLine($"\nПервая и вторая песни разные: {songs[0].Title()} и {songs[1].Title()}");
            }
        }
    }
}
