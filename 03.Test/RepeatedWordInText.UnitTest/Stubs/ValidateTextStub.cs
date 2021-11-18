namespace RepeatedWordInText.UnitTest.Stubs
{
    using RepeatedWordInText.AplicationCore.Dtos;
    using System.Collections.Generic;
    using static RepeatedWordInText.AplicationCore.Enums.StatusEnum;

    public class ValidateTextStub
    {
        public static readonly TextRequestDto TextRequestDto = new TextRequestDto()
        {
            Text = "Este mensaje este"
        };

        public static readonly TextRequestDto TextRequestDtoError = new TextRequestDto()
        {
            Text = string.Empty
        };

        public static readonly RepeatedWordDto RepeatedWordDtoEste = new RepeatedWordDto()
        {
            Word = "ESTE",
            NumberOfRepetitions = 2
        };

        public static readonly RepeatedWordDto RepeatedWordDtoMensaje = new RepeatedWordDto()
        {
            Word = "MENSAJE",
            NumberOfRepetitions = 1
        };

        public static readonly List<RepeatedWordDto> RepeatedWordsDto = new List<RepeatedWordDto>()
        {
            RepeatedWordDtoEste,
            RepeatedWordDtoMensaje
        };

        public static readonly ResponseService ResponseService = new ResponseService()
        {
            Message = Status.sucessful.ToString(),
            Status = true,
            Data = RepeatedWordsDto,
        };

        public static readonly ResponseService ResponseServiceError = new ResponseService()
        {
            Message = Status.failed.ToString(),
        };
    }
}
