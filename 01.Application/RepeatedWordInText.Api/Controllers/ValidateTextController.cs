namespace RepeatedWordInText.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RepeatedWordInText.AplicationCore.Dtos;
    using RepeatedWordInText.AplicationCore.Interfaces;
    using System;
    using System.Net;
    using System.Net.Mime;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class ValidateTextController : ControllerBase
    {
        private readonly IValidateTextService _service;

        public ValidateTextController(IValidateTextService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        ///<summary>
        /// Get the words in a text 
        /// </summary>
        /// <param name="text">The text</param>
        [HttpPut("RepeatedWords")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(TextRequestDto))]
        public IActionResult PutRepeatedWords([FromBody] TextRequestDto text)
        {
            ResponseService response = new ResponseService();
            try
            {
                response = _service.PutRepeatedWords(text);

                return response.Status ? Ok(response) : (IActionResult)BadRequest(response);
            }
            catch (Exception ex)
            {
                response.Message = $"{nameof(PutRepeatedWords)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
