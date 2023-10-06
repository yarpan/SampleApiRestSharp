using NUnit.Framework;


namespace SampleApiRestSharp
{
    internal class OwnerHeadersTests : BaseTests
    {

        [Test]
        public void GetOwnersListWithHeaderLanguageUpperCaseTest()
        {
         //arrange
            var ownerController = new OwnerController();
         //act
            //make Get request with custom headers
            var responseGetOwnerListRaw = ownerController.getListCustomHeaderRequest("ACCEPT-LANGUAGE", "EN-US");
            OwnerDto[] responseGetOwnerListDto = ownerController.ConvertResponseToDto<OwnerDto[]>(responseGetOwnerListRaw);
        //assert
            Assert.AreEqual(200, (int)responseGetOwnerListRaw.StatusCode);
            Assert.AreNotEqual(0, responseGetOwnerListDto.Length);
        }


        [Test]
        public void GetOwnersListWithHeaderLanguageLowerCaseTest()
        {
        //arrange
            var ownerController = new OwnerController();
        //act
            //make Get request with custom headers
            var responseGetOwnerListRaw = ownerController.getListCustomHeaderRequest("accept-language", "en-us");
            OwnerDto[] responseGetOwnerListDto = ownerController.ConvertResponseToDto<OwnerDto[]>(responseGetOwnerListRaw);
        //assert
            Assert.AreEqual(200, (int)responseGetOwnerListRaw.StatusCode);
            Assert.AreNotEqual(0, responseGetOwnerListDto.Length);
        }


        [Test]
        public void GetOwnersListWithHeaderAcceptedCapsTest()
        {
        //arrange
            var ownerController = new OwnerController();
        //act
            //make Get request with custom headers
            var responseGetOwnerListRaw = ownerController.getListCustomHeaderRequest("ACCEPTED", "APPLICATION/JSON");
            OwnerDto[] responseGetOwnerListDto = ownerController.ConvertResponseToDto<OwnerDto[]>(responseGetOwnerListRaw);
        //assert
            Assert.AreEqual(200, (int)responseGetOwnerListRaw.StatusCode);
            Assert.AreNotEqual(0, responseGetOwnerListDto.Length);
        }


        [Test]
        public void GetOwnersListWithHeaderAcceptedCamelCaseTest()
        {
        //arrange
            var ownerController = new OwnerController();
        //act
            //make Get request with custom headers
            var responseGetOwnerListRaw = ownerController.getListCustomHeaderRequest("aCcePtEd", "aPpLiCaTiOn/jSoN");
            OwnerDto[] responseGetOwnerListDto = ownerController.ConvertResponseToDto<OwnerDto[]>(responseGetOwnerListRaw);
        //assert
            Assert.AreEqual(200, (int)responseGetOwnerListRaw.StatusCode);
            Assert.AreNotEqual(0, responseGetOwnerListDto.Length);
        }

    }

}
