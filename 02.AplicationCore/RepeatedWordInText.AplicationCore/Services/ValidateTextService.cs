namespace RepeatedWordInText.AplicationCore.Services
{
    using RepeatedWordInText.AplicationCore.Dtos;
    using RepeatedWordInText.AplicationCore.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static RepeatedWordInText.AplicationCore.Enums.StatusEnum;

    public class ValidateTextService : IValidateTextService
    {

        public ValidateTextService() { }

        public ResponseService PostRepeatedWords(TextRequestDto text)
        {
            ResponseService response = new ResponseService();
            if (text == null || string.IsNullOrEmpty(text.Text))
            {
                response.Message = "The text is empty";

                return response;
            }
            response.Data = GetWordReated(text.Text);
            response.Message = Status.sucessful.ToString();
            response.Status = true;

            return response;
        }

        private List<RepeatedWordDto> GetWordReated(string text)
        {
            string TextClean = text.ToUpper().Replace(".", "").Replace(",", "").Replace(";", "");
            List<string> words = TextClean.Split(' ').ToList();
            List<string> distinctWords = words.Distinct().ToList();
            List<RepeatedWordDto> repeatedWordsDto = new List<RepeatedWordDto>();
            foreach (string word in distinctWords)
            {
                RepeatedWordDto repeatedWordDto = new RepeatedWordDto
                {
                    Word = word,
                    NumberOfRepetitions = words.Count(x => x == word)
                };
                repeatedWordsDto.Add(repeatedWordDto);
            }

            return repeatedWordsDto;
        }
    }
}
