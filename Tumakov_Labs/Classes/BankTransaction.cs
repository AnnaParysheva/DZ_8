using System;
namespace Tumakov_Labs
{
    class BankTransaction
    {
        /// <summary>
        /// Дата и время операции
        /// </summary>
        public DateTime TransactionTime { get; }
        /// <summary>
        /// Сумма операции
        /// </summary>
        public decimal Amount { get; }
        public BankTransaction(decimal amount)
        {
            TransactionTime = DateTime.Now;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"Дата: {TransactionTime}, Сумма: {Amount}";
        }
    }
}
