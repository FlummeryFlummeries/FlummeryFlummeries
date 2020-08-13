using System;
using Xunit;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.Services;
using ECommerce_App.Models.ViewModels;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Generic;

namespace ECommerce_App_Testing
{
    public class FlummeryInventoryServicesTests : DatabaseTest
    {
        private IFlummeryInventory BuildFlummeryService()
        {
            return new FlummeryInventoryManagement(_storeDb);
        }

        [Fact]
        public async void CanGetAllFlummeries()
        {
            var testService = BuildFlummeryService();

            //Act
            var allFlummeries = await testService.GetAllFlummeries();

            //Assert
            Assert.NotNull(allFlummeries);
            // Should be 10 from seeded data
            Assert.Equal(10, allFlummeries.Count);
            Assert.Equal("Job Jelly", allFlummeries[0].Name);
            Assert.Equal("Lark on the Wing", allFlummeries[9].Name);
        }

        [Fact]
        public async void CanGetAFlummeryBySearch()
        {
            //Arrange
            var testService = BuildFlummeryService();

            //Act
            var matchingFlummeries = await testService.GetFlummeriesForSearch("Tryion");

            //Assert
            Assert.NotNull(matchingFlummeries[0]);
            Assert.True(matchingFlummeries.Count >= 1);
            Assert.Equal("Acme Baking", matchingFlummeries[0].Manufacturer);
        }

        [Fact]
        public async void CanGetAllFlummeriesReordered()
        {
            //Arrange
            List<string> expectedNames = new List<string>()
            {
                "Baby Cowboy",
                "Job Jelly",
                "Job Jelly",
                "Job Jelly",
                "Lark on the Wing",
                "Lark on the Wing",
                "Polka",
                "Scarce Flour",
                "Tied for First",
                "Tryion"
            };
            var testService = BuildFlummeryService();

            //Act
            var alphaFlummeries = await testService.GetFlummeriesOrderedBy("alphabetical");

            //Assert
            Assert.NotNull(alphaFlummeries);
            Assert.Equal(10, alphaFlummeries.Count );
            for (int i = 0; i < alphaFlummeries.Count; i++)
            {
                Assert.Equal(expectedNames[i], alphaFlummeries[i].Name);
            }
        }

        [Fact]
        public async void CanCreateAndSaveAFlummery()
        {
            //Arrange
            var flummery01 = new FlummeryVM
            {
                Name = "flummery01",
                Manufacturer = "acme01",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };

            var testService = BuildFlummeryService();

            var savedFlummery = await testService.CreateFlummery(flummery01);

            //Act
            var testFlummery = await testService.GetFlummeryBy(savedFlummery.Id);

            //Assert
            Assert.NotNull(testFlummery);
            Assert.Equal("flummery01", testFlummery.Name);
            Assert.Equal("acme01", testFlummery.Manufacturer);
        }

        [Fact]
        public async void CanUpdateAFlummery()
        {
            //Arrange
            var flummery01 = new FlummeryVM
            {
                Name = "flummery01",
                Manufacturer = "acme01",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };

            var testService = BuildFlummeryService();

            var savedFlummery = testService.CreateFlummery(flummery01);
            var updatedFlummery01 = new FlummeryVM
            {
                Id = savedFlummery.Id,
                Name = "update-flummery01",
                Manufacturer = "update-acme01"
            };

            //Act
            var testFlummery = await testService.UpdateFlummery(updatedFlummery01);

            //Assert
            Assert.NotNull(testFlummery);
            Assert.Equal(savedFlummery.Id, testFlummery.Id);
            Assert.Equal("update-flummery01", testFlummery.Name);
            Assert.Equal("update-acme01", testFlummery.Manufacturer);
        }

        [Fact]
        public async void CanDeleteAFlummery()
        {
            //Arrange
            var flummery01 = new FlummeryVM
            {
                Name = "flummery01",
                Manufacturer = "acme01",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };

            var testService = BuildFlummeryService();

            var savedFlummery = testService.CreateFlummery(flummery01);

            var flummeriesBeforeDelete = await testService.GetAllFlummeries();

            //Act
            await testService.DeleteFlummery(savedFlummery.Id);
            var nullFlummery = await testService.GetFlummeryBy(savedFlummery.Id);
            var flummeriesAfterDelete = await testService.GetAllFlummeries();

            //Assert
            Assert.Null(nullFlummery);
            Assert.Equal(flummeriesBeforeDelete.Count - 1, flummeriesAfterDelete.Count);
        }
    }
}
