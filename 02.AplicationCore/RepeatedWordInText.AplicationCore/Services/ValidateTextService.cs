namespace RepeatedWordInText.AplicationCore.Services
{
    using RepeatedWordInText.AplicationCore.Dtos;
    using RepeatedWordInText.AplicationCore.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ValidateTextService : IValidateTextService
    {

        public ValidateTextService() { }

        public ResponseService GetRepeatedWords(string text)
        {
            ResponseService response = new ResponseService();
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    response.Message = "The text is empty";

                    return response;
                }

                List<RepeatedWordDto> repeatedWords = GetWordReated(text);

                response.Data = repeatedWords;
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Internal server error.";

                return response;
            }
        }

        private List<RepeatedWordDto> GetWordReated(string text)
        {
            throw new NotImplementedException();
        }
    }
}
