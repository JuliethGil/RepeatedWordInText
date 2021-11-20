namespace RepeatedWordInText.UnitTest.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RepeatedWordInText.AplicationCore.Services;
    using RepeatedWordInText.UnitTest.Stubs;
    using static RepeatedWordInText.AplicationCore.Enums.StatusEnum;

    [TestClass]
    public class ValidateTextServicesTest
    {
        private ValidateTextService Service()
        {
            return new ValidateTextService();
        }

        [TestMethod]
        public void Put_ReturnsResponseService_WhenTextEmpy()
        {
            var service = Service();
            var result = service.PostRepeatedWords(ValidateTextStub.TextRequestDtoError);

            Assert.IsFalse(result.Status);
            Assert.AreEqual("The text is empty", result.Message);
        }

        [TestMethod]
        public void Put_ReturnsResponseService_WhenExistsData()
        {
            var service = Service();
            var result = service.PostRepeatedWords(ValidateTextStub.TextRequestDto);
            
            Assert.IsTrue(result.Status);
            Assert.AreEqual(Status.sucessful.ToString(), result.Message);
        }
    }
}
