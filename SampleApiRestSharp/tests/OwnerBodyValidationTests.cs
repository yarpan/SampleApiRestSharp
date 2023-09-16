using NUnit.Framework;
using System;

namespace SampleApiRestSharp
{
    public class OwnerBodyValidationTests : BaseTests
    {

        [Test]
        public void CreateOwnerOneLetterFirstNameTest()
        {
            //arrange
            var ownerController = new OwnerController();
            var requestPostDto = new OwnerDto
                {
                    address = Faker.Address.StreetAddress(),
                    firstName = "A",
                    lastName = Faker.Name.Last(),
                    city = Faker.Address.City(),
                    telephone = Faker.Identification.UkNhsNumber()
                };

            //act
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

            //assert
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostDto, Is.EqualTo(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(responsePostDto));
        }


        [Test]
        public void CreateOwnerOneLetterLastNameTest()
        {
            //arrange
            var ownerController = new OwnerController();
            var requestPostDto = new OwnerDto
            {
                address = Faker.Address.StreetAddress(),
                firstName = Faker.Name.First(),
                lastName = "B",
                city = Faker.Address.City(),
                telephone = Faker.Identification.UkNhsNumber()
            };

            //act
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

            //assert
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostDto, Is.EqualTo(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(responsePostDto));
        }


        [Test]
        public void CreateOwnerLowerCaseFirstNameTest()
        {
            //arrange
            var ownerController = new OwnerController();
            var requestPostDto = new OwnerDto
            {
                address = Faker.Address.StreetAddress(),
                firstName = "dina",
                lastName = Faker.Name.Last(),
                city = Faker.Address.City(),
                telephone = Faker.Identification.UkNhsNumber()
            };

            //act
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

            //assert
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostDto, Is.EqualTo(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(responsePostDto));
        }


        [Test]
        public void CreateOwnerLowerCaseLastNameTest()
        {
            //arrange
            var ownerController = new OwnerController();
            var requestPostDto = new OwnerDto
            {
                address = Faker.Address.StreetAddress(),
                firstName = Faker.Name.First(),
                lastName = "smith",
                city = Faker.Address.City(),
                telephone = Faker.Identification.UkNhsNumber()
            };

            //act
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

            //assert
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostDto, Is.EqualTo(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(responsePostDto));
        }


        [Test]
        public void CreateOwnerAddressWithSpecialSymbolsTest()
        {
            //arrange
            var ownerController = new OwnerController();
            var requestPostDto = new OwnerDto
            {
                address = "#68 East Mack-shire !@#$%^&*()_+-=`~.,/<>;:' str",
                firstName = Faker.Name.First(),
                lastName = Faker.Name.Last(),
                city = Faker.Address.City(),
                telephone = Faker.Identification.UkNhsNumber()
            };

            //act
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

            //assert
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostDto, Is.EqualTo(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(responsePostDto));
        }


        [Test]
        public void CreateOwnerAddressCityWithSpecialSymbolsTest()
        {
            //arrange
            var ownerController = new OwnerController();
            var requestPostDto = new OwnerDto
            {
                address = Faker.Address.StreetAddress(),
                firstName = Faker.Name.First(),
                lastName = Faker.Name.Last(),
                city = "!Chicago !@#$%^&*()_+-=`~,./<>;:'",
                telephone = Faker.Identification.UkNhsNumber()
            };

            //act
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

            //assert
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostDto, Is.EqualTo(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(responsePostDto));
        }


        [Test]
        public void CreateOwnerPhoneOneDigitTest()
        {
            //arrange
            var ownerController = new OwnerController();
            var requestPostDto = new OwnerDto
            {
                address = Faker.Address.StreetAddress(),
                firstName = Faker.Name.First(),
                lastName = Faker.Name.Last(),
                city = Faker.Address.City(),
                telephone = "0"
            };

            //act
            var responsePostRaw = ownerController.PostRequest(requestPostDto);
            var responsePostDto = ownerController.ConvertResponseToDto<OwnerDto>(responsePostRaw);

            //assert
            Assert.AreEqual(201, (int)responsePostRaw.StatusCode);
            Assert.That(responsePostDto, Is.EqualTo(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(requestPostDto));
            Console.WriteLine(ownerController.SerializeJsonString(responsePostDto));
        }




    }
}
