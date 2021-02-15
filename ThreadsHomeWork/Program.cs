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
        public void SelectById(int id)
        {
            for (int i = 0; i < Program.clients.Count; i++)
            {
                if (id == Program.clients[i].Id)
                {
                    Console.WriteLine(Program.clients[i].Id);
                    Console.WriteLine(Program.clients[i].Name);
                    Console.WriteLine(Program.clients[i].Age);
                    Console.WriteLine(Program.clients[i].Balance); 
                }
            }
        }
        public void Select()
        {
            for (int i = 0; i < Program.clients.Count; i++) Console.WriteLine($"{Program.clients[i].Id},\t {Program.clients[i].Name},\t {Program.clients[i].Age},\t {Program.clients[i].Balance}");
                
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
            //Update
            Console.Write("Введите Id"); int idd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите баланс: ");  decimal ballance = Convert.ToDecimal(Console.ReadLine());
            Thread newUpdateThread = new Thread(new ThreadStart(() => {client.Update(idd, ballance); }));
            newUpdateThread.Start();
            //Select by Id
            Console.Write("Введите Id: "); int id1 = Convert.ToInt32(Console.ReadLine());
            Thread newSelectByIdThread = new Thread(new ThreadStart(() => {client.SelectById(id1);}));
            newSelectByIdThread.Start();
            id++;
            Console.Write("Введите Имя: "); string name1 = Console.ReadLine();
            Console.Write("Введите возраст: "); int.TryParse(Console.ReadLine(), out int age1);
            Console.Write("Введите баланс: "); decimal.TryParse(Console.ReadLine(), out decimal balance1);
            Thread newInsertThread1 = new Thread(new ThreadStart(() => {client.Insert(id, name1, age1, balance1); }));
            newInsertThread1.Start();
            Thread newSelectThread = new Thread(new ThreadStart(() => {client.Select();}));
            newSelectThread.Start();

        }
    }
}
