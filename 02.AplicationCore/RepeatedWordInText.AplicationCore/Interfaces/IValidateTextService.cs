namespace RepeatedWordInText.AplicationCore.Interfaces
{
    using RepeatedWordInText.AplicationCore.Dtos;
    using System.Threading.Tasks;

    public interface IValidateTextService
    {

        ///<summary>
        /// Get the words in a text 
        /// </summary>
        /// <param name="text">The text</param>
        ResponseService PostRepeatedWords(TextRequestDto text);
    }
}
