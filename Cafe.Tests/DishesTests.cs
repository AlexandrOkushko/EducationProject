using CafeDAL.EF;
using CafeDAL.Models;
using CafeDAL.Repos;
using NUnit.Framework;
using System;
using System.Linq;

namespace Cafe.Tests
{
    public class DishesTests
    {
        private DishRepo _dishRepo;


        [SetUp]
        public void Setup()
        {
            _dishRepo = new(new CafeContext());
        }

        [Test]
        public void GetAll__CountGreaterThenZero()
        {
            // ACT + ASSERT
            Assert.Greater(_dishRepo.GetAll().Count, 0);
        }

        [Test]
        public void Add_ValidDish_AreEqual()
        {
            // ARRANGE
            int dishesQuantity = _dishRepo.GetAll().Count;
            Dishes dish = new()
            {
              Name = "Test soup",
              Description = "Test soup description",
              ExpirationDate = DateTime.Today,
              IsActual = false,
              Price = 10m
            };
            
            // ACT
            _dishRepo.Add(dish);
            
            // ASSERT
            Assert.AreEqual(dishesQuantity + 1, _dishRepo.GetAll().Count);
        }

        [Test]
        public void Update_NewDescription_AreNotEqual()
        {
            // ARRANGE
            var oldDescription = _dishRepo.GetAll().Last().Description.Clone();
            var newDish = _dishRepo.GetAll().Last();

            // ACT
            newDish.Description = "new description";
            _dishRepo.Update(newDish);

            // ASSERT
            Assert.AreNotEqual(oldDescription, _dishRepo.GetAll().Last().Description);
        }
        
        [Test]
        public void Delete_LastId_AreEqual()
        {
            // ARRANGE
            var dishes = _dishRepo.GetAll();

            var oldCount = dishes.Count;
            var lastDish = dishes.Last();
            
            // ACT
            _dishRepo.Delete(lastDish);
            Console.WriteLine("lastDish.Id " + lastDish.Id);

            // ASSERT
            Assert.AreEqual(oldCount - 1, _dishRepo.GetAll().Count);
        }
        

        // ARRANGE
        // ACT
        // ASSERT
        [Test(Description = "send name = 'Суп'")]
        public void Search_Name_AllDishesWithTheSameName()
        {
            // ARRANGE
            string searchName = "Суп";
            
            // ACT
            var dishes = _dishRepo.Search(searchName);
            Console.WriteLine("%Суп% = " + dishes.Count);
            
            // ASSERT
            Assert.Greater(dishes.Count, 0);
        }
        
    }
}