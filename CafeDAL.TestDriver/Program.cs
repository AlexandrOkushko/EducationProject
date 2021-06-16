using CafeDAL.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using CafeDAL.EF;
using CafeDAL.Repos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CafeDAL.TestDriver
{
    public class Program
    {
        static List<Employees> _employees = new();

        static void Main(string[] args)
        {
            Console.WriteLine(" * * * * * ADO.NET * * * * * \n");

            //using (var context = new CafeContext())
            //{
            //    // Migration in process 
            //}

            Console.WriteLine(" * * * * * Using a Repository * * * * * \n");
            using (var repo = new EmployeeRepo())
            {
                foreach (Employees c in repo.GetAll())
                {
                    Console.WriteLine(c);
                }
            }

            //TestConcurrency();

            Console.ReadKey();
        }


        private static void AddNewRecord(Employees employees)
        {
            using (var repo = new EmployeeRepo())
            {
                repo.Add(employees);
            }
        }

        private static void UpdateRecord(int employeeId)
        {
            using (var repo = new EmployeeRepo())
            {
                // Grab the employee, change it, save! 
                var employeeToUpdate = repo.GetOne(employeeId);
                if (employeeToUpdate == null) return;
                employeeToUpdate.INN = 12345678;
                repo.Update(employeeToUpdate);
            }
        }

        private static void RemoveRecordByCar(Employees employeeToDelete)
        {
            using (var repo = new EmployeeRepo())
            {
                repo.Delete(employeeToDelete);
            }
        }

        private static void RemoveRecordById(int employeeId, byte[] timeStamp)
        {
            using (var repo = new EmployeeRepo())
            {
                repo.Delete(employeeId, timeStamp);
            }
        }

        private static void TestConcurrency()
        {
            var repo1 = new EmployeeRepo();
            //Use a second repo to make sure using a different context
            var repo2 = new EmployeeRepo();
            var employee1 = repo1.GetOne(1);
            var employee2 = repo2.GetOne(1);
            employee1.FirstName = "NewName";
            repo1.Update(employee1);
            employee2.FirstName = "OtherName";
            try
            {
                repo2.Update(employee2);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var currentValues = entry.CurrentValues;
                var originalValues = entry.OriginalValues;
                var dbValues = entry.GetDatabaseValues();
                Console.WriteLine(" * * * * * Concurrency * * * * * ");
                Console.WriteLine("Type     First Name");
                Console.WriteLine($"Current: {currentValues[nameof(Employees.FirstName)]}");
                Console.WriteLine($"Orig:    {originalValues[nameof(Employees.FirstName)]}");
                Console.WriteLine($"db:      {dbValues[nameof(Employees.FirstName)]}");
            }
        }

    }
}
