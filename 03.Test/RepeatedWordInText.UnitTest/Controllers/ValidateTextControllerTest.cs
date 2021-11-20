namespace RepeatedWordInText.UnitTest.Controllers
{
    using Grpc.Core;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RepeatedWordInText.Api.Controllers;
    using RepeatedWordInText.AplicationCore.Dtos;
    using RepeatedWordInText.AplicationCore.Interfaces;
    using RepeatedWordInText.UnitTest.Stubs;
    using System;

    [TestClass]
    public class ValidateTextControllerTest
    {
        private Mock<IValidateTextService> _mockService;

        private ValidateTextController Controller()
        {
            return new ValidateTextController(_mockService.Object)
            {
                ControllerContext = new ControllerContext()
            };
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _mockService = new Mock<IValidateTextService>();
        }

        [TestMethod]
        public void Post_ExpectdSetup_Ok()
        {
            _mockService.Setup(x => x.PostRepeatedWords(It.IsAny<TextRequestDto>())).Returns(ValidateTextStub.ResponseService);

            var controller = Controller();
            var result = controller.PostRepeatedWords(ValidateTextStub.TextRequestDto);

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            var model = okResult.Value as ResponseService;
            Assert.IsTrue(model.Status);
            _mockService.VerifyAll();
        }

        [TestMethod]
        public void Post_ExpectdSetup_BadRequest()
        {
            _mockService.Setup(x => x.PostRepeatedWords(It.IsAny<TextRequestDto>())).Returns(ValidateTextStub.ResponseServiceError);

            var controller = Controller();
            var result = controller.PostRepeatedWords(ValidateTextStub.TextRequestDtoError);

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);
            var model = okResult.Value as ResponseService;
            Assert.IsFalse(model.Status);
            _mockService.VerifyAll();
        }

        [TestMethod]
        public void Post_ExpectdSetup_InternalServerError()
        {
            _mockService.Setup(x => x.PostRepeatedWords(It.IsAny<TextRequestDto>())).Throws(new Exception());

            var controller = Controller();
            var result = controller.PostRepeatedWords(ValidateTextStub.TextRequestDtoError);

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);
            var model = okResult.Value as ResponseService;
            Assert.IsFalse(model.Status);
            _mockService.VerifyAll();
        }
    }
}
