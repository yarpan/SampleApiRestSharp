using NUnit.Framework;
using System;
using System.Net;


namespace SampleApiRestSharp
{
    internal class OwnerCrudTests : BaseTests
    {

        [Test]
        public void CreateNewOwnerTest()
        {
         //arrange
            var ownerController = new OwnerController();
            var requestPostDto = ownerController.GenerateRandomOwnerDto();

         //act
            //make POST request to create new Owner
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

         //assert
            Assert.IsNotNull(responsePostRaw);
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostRaw.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(responsePostRaw.ContentType, Is.EqualTo("application/json"));

            Assert.AreEqual(responsePostDto.lastName, requestPostDto.lastName);
            Assert.AreEqual(responsePostDto.firstName, requestPostDto.firstName);
        }



        [Test]
        public void CreateNewOwnerAndGetHimByIdTest()
        {
         //arrange
            var ownerController = new OwnerController();
            var requestPostDto = ownerController.GenerateRandomOwnerDto();
            //make POST request to create new Owner
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);
            //extracting ID of just created Owner
            var newCreatedId = responsePostDto.id;

         //act
            //make Get request to recieve details of Owner with specified ID
            var responseGetByIdRaw = ownerController.GetByIdRequest(newCreatedId);
            var responseGetByIdDto = ownerController.ConvertResponseToDto<OwnerDto>(responseGetByIdRaw);

         //assert
            Assert.AreEqual(HttpStatusCode.OK, responseGetByIdRaw?.StatusCode);

            Assert.AreEqual(responsePostDto?.id, responseGetByIdDto.id);
            Assert.AreEqual(responsePostDto?.firstName, responseGetByIdDto.firstName);
            Assert.AreEqual(responsePostDto?.lastName, responseGetByIdDto.lastName);
        }



        [Test]
        public void CreateNewOwnerPutUpdateAndGetHimByIdTest()
        {
         //arrange
            var ownerController = new OwnerController();
            var requestPostDto = ownerController.GenerateRandomOwnerDto();
            //make POST request to create new Owner
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);
            //extracting ID of just created Owner
            var newCreatedId = responsePostDto.id;
            //creating new data for update owner
            var requestPutDto = ownerController.GenerateRandomOwnerDto();

         //act
            //make PUT request to update details of Owner with specified ID
            var responsePutRaw = ownerController.PutByIdRequest(requestPutDto, newCreatedId);
            var responseGetByIdRaw = ownerController.GetByIdRequest(newCreatedId);
            var responseGetByIdDto = ownerController.ConvertResponseToDto<OwnerDto>(responseGetByIdRaw);

         //assert
            Assert.AreEqual(HttpStatusCode.NoContent, responsePutRaw?.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, responseGetByIdRaw?.StatusCode);

            Assert.AreEqual(responsePostDto?.id, responseGetByIdDto.id);
            Assert.AreEqual(requestPutDto?.firstName, responseGetByIdDto.firstName);
            Assert.AreEqual(requestPutDto?.lastName, responseGetByIdDto.lastName);

         //debug output
            Console.WriteLine("responsePostDto \n" + ownerController.SerializeJsonString(responsePostDto));
            Console.WriteLine("requestPutDto \n" + ownerController.SerializeJsonString(requestPutDto));
            Console.WriteLine("responseGetByIdDto \n" + ownerController.SerializeJsonString(responseGetByIdDto));
        }



        [Test]
        public void CreateNewOwnerDeleteHimAndTryGetByIdTest()
        {
         //arrange
            var ownerController = new OwnerController();
            var requestPostDto = ownerController.GenerateRandomOwnerDto();
            //make POST request to create new Owner
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);
            //extracting ID of just created Owner
            var newCreatedId = responsePostDto.id;

         //act
            //make Delete request 
            var responseDeleteRaw = ownerController.DeleteByIdRequest(newCreatedId);
            var responseGetByIdRaw = ownerController.GetByIdRequest(newCreatedId);

         //assert
            Assert.AreEqual(HttpStatusCode.NoContent, responseDeleteRaw?.StatusCode);
            Assert.AreEqual(HttpStatusCode.NotFound, responseGetByIdRaw?.StatusCode);
        }



    }
}
