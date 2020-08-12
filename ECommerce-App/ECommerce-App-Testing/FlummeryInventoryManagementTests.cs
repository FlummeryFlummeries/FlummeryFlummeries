using System;
using Xunit;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.Services;
using ECommerce_App.Models.ViewModels;
using Microsoft.CodeAnalysis.Operations;

namespace ECommerce_App_Testing
{
    public class FlummeryInventoryManagementTests : DatabaseTest
    {
        private IFlummeryInventory BuildFlummeryService()
        {
            return new FlummeryInventoryManagement(_storeDb);
        }

        [Fact]
        public async void CanGetAllFlummeries()
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
            var flummery02 = new FlummeryVM
            {
                Name = "flummery02",
                Manufacturer = "acme02",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };
            var flummery03 = new FlummeryVM
            {
                Name = "flummery03",
                Manufacturer = "acme03",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };
            
            var testService = BuildFlummeryService();

            var throwAway01 = await testService.CreateFlummery(flummery01);
            var throwAway02 = await testService.CreateFlummery(flummery02);
            var throwAway03 = await testService.CreateFlummery(flummery03);

            //Act
            var allFlummeries = await testService.GetAllFlummeries();

            //Assert
            Assert.NotNull(allFlummeries);
            Assert.True(allFlummeries.Count >= 3);
        }

        [Fact]
        public async void CanGetAFlummeryBySearch()
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
            var flummery02 = new FlummeryVM
            {
                Name = "flummery02",
                Manufacturer = "acme02",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };
            var flummery03 = new FlummeryVM
            {
                Name = "flummery03",
                Manufacturer = "acme03",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };

            var testService = BuildFlummeryService();

            var throwAway01 = await testService.CreateFlummery(flummery01);
            var throwAway02 = await testService.CreateFlummery(flummery02);
            var throwAway03 = await testService.CreateFlummery(flummery03);

            //Act
            var matchingFlummeries = await testService.GetFlummeriesForSearch("flummery02");

            //Assert
            Assert.NotNull(matchingFlummeries);
            Assert.True(matchingFlummeries.Count >= 1);
            bool containsTarget = false;
            foreach(var flummery in matchingFlummeries)
            {
                if (flummery.Name == "flummery02" && flummery.Manufacturer == "acme02")
                {
                    containsTarget = true;
                }
            }
            Assert.True(containsTarget);
        }

        [Fact]
        public async void CanGetAllFlummeriesReordered()
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
            var flummery02 = new FlummeryVM
            {
                Name = "flummery02",
                Manufacturer = "acme02",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };
            var flummery03 = new FlummeryVM
            {
                Name = "flummery03",
                Manufacturer = "acme03",
                Price = 9.99m,
                Calories = 1500,
                Weight = 0.25m,
                Compliment = "Damned with faint praise"
            };

            var testService = BuildFlummeryService();

            var throwAway01 = await testService.CreateFlummery(flummery01);
            var throwAway02 = await testService.CreateFlummery(flummery02);
            var throwAway03 = await testService.CreateFlummery(flummery03);

            //Act
            var revAlphaFlummeries = await testService.GetFlummeriesOrderedBy("alphabeticalRev");

            //Assert
            Assert.NotNull(revAlphaFlummeries);
            Assert.True(revAlphaFlummeries.Count >= 3);

            bool inOrder = true;
            FlummeryVM foundFlummery03 = null;
            FlummeryVM foundFlummery02 = null;
            FlummeryVM foundFlummery01 = null;
            foreach (var flummery in revAlphaFlummeries)
            {
                if (flummery.Name == "flummery03" && flummery.Manufacturer == "acme03")
                {
                    foundFlummery03 = flummery;
                    if (foundFlummery02 != null || foundFlummery01 != null)
                    {
                        inOrder = false;
                        break;
                    }
                }
                if (flummery.Name == "flummery02" && flummery.Manufacturer == "acme02")
                {
                    foundFlummery02 = flummery;
                    if (foundFlummery03 == null || foundFlummery01 != null)
                    {
                        inOrder = false;
                        break;
                    }
                }
                if (flummery.Name == "flummery01" && flummery.Manufacturer == "acme01")
                {
                    foundFlummery01 = flummery;
                    if (foundFlummery03 == null || foundFlummery02 == null)
                    {
                        inOrder = false;
                        break;
                    }
                }
            }
            Assert.True(inOrder);
            Assert.NotNull(foundFlummery03);
            Assert.NotNull(foundFlummery02);
            Assert.NotNull(foundFlummery01);
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
