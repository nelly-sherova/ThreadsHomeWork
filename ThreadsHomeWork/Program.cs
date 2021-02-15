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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Успешно добавлен клиент с Id " + id);
        }
        public void Update(int id, decimal balance)
        {
            for (int i = 0; i < Program.clients.Count; i++) if (id == Program.clients[i].Id) Program.clients[i].Balance = balance; 
        }
    }
    class Program
    {
        public static List<Client> clients = new List<Client>();
        public static List<Client> balances = new List<Client>();
        
        
        static void Main(string[] args)
        {
            // Insert
            int id = 0;
            balances.AddRange(clients);
            Client client = new Client();
            id++;
            Console.Write("Введите Имя: "); string name = Console.ReadLine();
            Console.Write("Введите возраст: "); int.TryParse(Console.ReadLine(), out int age);
            Console.Write("Введите баланс: "); decimal.TryParse(Console.ReadLine(), out decimal balance);
            Thread newInsertThread = new Thread(new ThreadStart(() => {client.Insert(id, name, age, balance); }));
            newInsertThread.Start();
            Console.Write("Введите Id"); int idd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите баланс: ");  decimal ballance = Convert.ToDecimal(Console.ReadLine());
            Thread newUpdateThread = new Thread(new ThreadStart(() => {client.Update(idd, ballance); }));
            newUpdateThread.Start();
            
        }
    }
}
