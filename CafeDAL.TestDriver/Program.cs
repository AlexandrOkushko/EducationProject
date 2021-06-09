using CafeDAL.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace CafeDAL.TestDriver
{
    class Program
    {
        static List<Employees> _employees = new();

        static readonly string path = @"..\..\..\TestData\Data.txt";
        static void Main(string[] args)
        {
            #region Initialize
            InitializeFile();

            ShowAllEmployees("Initialize");
            #endregion

            #region Add New Record
            Employees employee4 = new()
            {
                Id = 4,
                Timestamp = null,
                FirstName = "Stepa",
                LastName = "Adminov",
                PassportId = 123456,
                INN = 404040,
                BirdthDate = new DateTime(2004, 4, 4),
                Sex = true, // man
                Phone = "12345678",
                RoleId = 1, // 1 ====> Admin
                Email = "Stepa@gmail.com",
                Password = "********",
            };

            AddNewRecord(employee4);

            ShowAllEmployees("Add New Record");
            #endregion

            #region Update Record
            employee4.INN = 12345678;

            UpdateRecord(employee4);

            ShowAllEmployees("Update Record");
            #endregion

            #region Remove Record
            RemoveRecordById(1);

            ShowAllEmployees("Remove Record");
            #endregion

            #region Serialize And Write To File
            Console.WriteLine("\n" + (SerializeAndWrite() ? "Data was serialized" : "Data couldn't be serialized"));
            #endregion

            Console.ReadKey();
        }

        private static void ShowAllEmployees(string msg)
        {
            Console.WriteLine($"* * * * * {msg} * * * * *");
            foreach (var employee in _employees)
            {
                Console.WriteLine($"Id: {employee.Id}\t First Name: {employee.FirstName}\t Last Name: {employee.LastName}\t INN: {employee.INN}");
            }
            Console.WriteLine($"{new string('-', 50)}\n");
        }

        private static void InitializeFile()
        {
            Employees employee1 = new Employees
            {
                Id = 1,
                Timestamp = null,
                FirstName = "Ivan",
                LastName = "Adminov",
                PassportId = 123456,
                INN = 101010,
                BirdthDate = new DateTime(2001, 1, 1),
                Sex = true, // man
                Phone = "12345678",
                RoleId = 1, // 1 ====> Admin
                Email = "Ivan@gmail.com",
                Password = "********",
            };
            Employees employee2 = new Employees
            {
                Id = 2,
                Timestamp = null,
                FirstName = "Petya",
                LastName = "Barmenov",
                PassportId = 123456,
                INN = 202020,
                BirdthDate = new DateTime(2002, 2, 2),
                Sex = true, // man
                Phone = "12345678",
                RoleId = 2, // 2 ====> Bartender
                Email = "Petya@gmail.com",
                Password = "********",
            };
            Employees employee3 = new Employees
            {
                Id = 3,
                Timestamp = null,
                FirstName = "Antonina",
                LastName = "Chefovna",
                PassportId = 123456,
                INN = 303030,
                BirdthDate = new DateTime(2003, 3, 3),
                Sex = false, // woman
                Phone = "12345678",
                RoleId = 3, // 3 ====> Chef
                Email = "Antonina@gmail.com",
                Password = "********",
            };

            _employees.AddRange(new[] { employee1, employee2, employee3 });

            SerializeAndWrite();

            DeserializeAndRead();
        }

        private static void DeserializeAndRead()
        {
            string json; 
            using (StreamReader streamReader = new(path))
            {
                json = streamReader.ReadToEnd();
            }

            _employees = JsonConvert.DeserializeObject<List<Employees>>(json);
        }

        private static bool SerializeAndWrite()
        {
            string json;

            try
            {
                json = JsonConvert.SerializeObject(_employees);
            }
            catch (Exception)
            {
                return false;
            }

            using (StreamWriter streamWriter = new(path, false))
            {
                streamWriter.WriteLine(json);
            }

            return true;
        }

        private static void AddNewRecord(Employees emp)
        {
            _employees.Add(emp);
        }

        private static void UpdateRecord(Employees emp)
        {
            for (int i = 0; i < _employees.Count; i++)
                if (_employees[i].Id == emp.Id)
                    _employees[i] = emp;
        }

        private static bool RemoveRecordById(int id)
        {
            return _employees.Remove(_employees.Find(x => x.Id == id));
        }
    }
}
