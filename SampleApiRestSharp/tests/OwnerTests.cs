using NUnit.Framework;
using RestSharp;
using SampleApiRestSharp;
using System;
using Faker;

namespace SampleApiRestSharp
{
    internal class OwnerTests : BaseTests
    {


        [Test]
        public void CreateNewOwnerTest()
        {
            var ownerController = new OwnerController();
            var requestOwnerDto = ownerController.GenerateRandomOwnerDto();
            var responseOwnerDto = ownerController.PostRequest(requestOwnerDto);

            //Assertion with FluentAssertions
            //response?.Name.Should().Be("Keyboard");

            Assert.IsNotNull(responseOwnerDto);

            Assert.AreEqual(responseOwnerDto.address, requestOwnerDto.address);
            Assert.AreEqual(responseOwnerDto.firstName, requestOwnerDto.firstName);


        }




        [Test]
        public void CreateNewOwnerAndGetHimByIdTest()
        {
            var ownerController = new OwnerController();
            var requestForCreatingOwnerDto = ownerController.GenerateRandomOwnerDto();
            var responseNewCreatedOwnerDto = ownerController.PostRequest(requestForCreatingOwnerDto);

            Console.WriteLine("response.firstName - " + responseNewCreatedOwnerDto.firstName);
            Console.WriteLine("response.lastName - " + responseNewCreatedOwnerDto.lastName);
            Console.WriteLine("response.telephone - " + responseNewCreatedOwnerDto.telephone);
            Console.WriteLine("response.id - " + responseNewCreatedOwnerDto.id);

            var newCreatedOwnerId = responseNewCreatedOwnerDto.id;

            var responseGetOwnerByIdDto = ownerController.GetByIdRequest(newCreatedOwnerId);

            Console.WriteLine("response.firstName - " + responseGetOwnerByIdDto.firstName);
            Console.WriteLine("response.lastName - " + responseGetOwnerByIdDto.lastName);
            Console.WriteLine("response.telephone - " + responseGetOwnerByIdDto.telephone);
            Console.WriteLine("response.id - " + responseGetOwnerByIdDto.id);


        }




        [Test]
        public void OwnerPostTest2()
        {
 




        }

























    }
}
