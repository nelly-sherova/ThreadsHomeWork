using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsHomeWork
{

    class Client
    {
        public int Id {set; get;} = 0;
        public string Name {get; set;}
        public int Age {get; set;}
        public decimal Balance {get; set;}
         public void Insert(int id, string name, int age, decimal balance)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Balance = balance;
            Program.clients.Add(new Client(){Id = id, Name = name, Age = age, Balance = balance});
            Program.balances.Add(new Client(){Id = id, Name = name, Age = age, Balance = balance});
            System.Console.WriteLine("Успешно добавлено клиент с Id " + id);
            return;
        }

    }
    class Program
    {
        public static List<Client> clients = new List<Client>();
        public static List<Client> balances = new List<Client>();
        
        
        static void Main(string[] args)
        {
            int id = 0;
            balances.AddRange(clients);
            Client client = new Client();
            id++;
            Console.Write("Введите Имя: "); string name = Console.ReadLine();
            Console.Write("Введите возраст: "); int.TryParse(Console.ReadLine(), out int age);
            Console.Write("Введите баланс: "); decimal.TryParse(Console.ReadLine(), out decimal balance);
            Thread newInsertThread = new Thread(new ThreadStart(() => {client.Insert(id, name, age, balance); }));
            newInsertThread.Start();
        }
    }
}
