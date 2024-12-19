using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov_Labs
{
    //Создаем класс счет в банке
    class BankAccount
    {
        /// <summary>
        /// Статическая переменная для хранения последнего сгенерированного номера счета
        /// </summary>
        private static ulong lastAccountNumber = 1234567890;
        /// <summary>
        /// Номер счета
        /// </summary>
        private readonly Guid accountNumber;
        /// <summary>
        /// Баланс
        /// </summary>
        private decimal balance;
        /// <summary>
        /// Тип банковского счета
        /// </summary>
        private Bank_schet typeBankAccount;
        /// <summary>
        /// Флаг для отслеживания вызова Dispose
        /// </summary>
        private bool disposed = false;
        // Закрытое поле для хранения операций
        private readonly Queue<BankTransaction> transactionHistory = new Queue<BankTransaction>();
        // Конструктор по умолчанию
        public BankAccount()
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = 0.00m;
            this.typeBankAccount = Bank_schet.Current;
        }
        // Метод для генерации уникального номера счета
        private Guid GenerateUniqueAccountNumber()
        {
            lastAccountNumber++;
            return Guid.NewGuid();
        }
        public Guid GetAccountNumber()
        { return accountNumber; }
        // Метод, возвращающий баланс
        public decimal GetBalance()
        {
            return balance;
        }
        // Метод,возвращающий тип банковского счета
        public Bank_schet GetTypeBankAccount()
        {
            return typeBankAccount;
        }
        // Конструктор для заполнения поля тип банковского счета
        public BankAccount(Bank_schet accountType)
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = 0.00m; 
            this.typeBankAccount = accountType;
        }
        // Конструктор для заполнения только баланса
        public BankAccount(decimal balance)
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = balance;
            this.typeBankAccount = Bank_schet.Current;
        }
        // Конструктор для заполнения баланса и типа банковского счета
        public BankAccount(decimal balance, Bank_schet accountType)
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = balance;
            this.typeBankAccount = accountType;
        }
        //Метод для пополнения счета
        public void AccountReplenishment(decimal sum)
        {
            if (sum < 0)
            {
                Console.WriteLine("Сумма пополнения должна быть больше 0");
            }
            else
            {
                balance += sum;
            }
            BankTransaction transaction = new BankTransaction(sum);
            transactionHistory.Enqueue(transaction);
        }
        //Метод для снятия со счета
        public void AccountWithdrawal(decimal sum)
        {
            if (balance - sum < 0)
            {
                Console.WriteLine("Невозможно снять такую сумму!");
            }
            else
            {
                balance -= sum;
            }
            BankTransaction transaction = new BankTransaction(sum);
            transactionHistory.Enqueue(transaction);
        }
        // Метод для вывода информации о счете
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип счета: {typeBankAccount}");
        }
        // Метод для перевода денег с одного счета на другой
        public void Trasfer(BankAccount fromAccount, BankAccount toAccount, decimal sum)
        {
            if (sum <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше 0");
                return;
            }
            if (sum > balance)
            {
                Console.WriteLine("Невозможно перевести такую сумму!");
                return;
            }
            else
            {
                fromAccount.AccountWithdrawal(sum);
                toAccount.AccountReplenishment(sum);
                Console.WriteLine($"Переведено {sum} со счета {fromAccount.GetAccountNumber()} на счет {toAccount.GetAccountNumber()}");
            }
        }
        // Метод для вывода истории операций
        public void PrintTransactionHistory()
        {
            Console.WriteLine($"История операций для счета {accountNumber}:");
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Сообщаем системе, что метод завершения не нужно вызывать
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    string filePath = $"..\\..\\{accountNumber}transaction_history.txt";
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var transaction in transactionHistory)
                        {
                            writer.WriteLine(transaction);
                        }
                    }
                    Console.WriteLine($"Данные о проводках записаны в файл: {filePath}");
                }
                disposed = true;
            }
        }
        // Деструктор (метод завершения)
        ~BankAccount()
        {
            Dispose(false);
        }
    }
}
