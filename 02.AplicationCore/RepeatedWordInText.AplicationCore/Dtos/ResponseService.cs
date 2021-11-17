namespace RepeatedWordInText.AplicationCore.Dtos
{
    public class ResponseService<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Data{ get; set; }

        public ResponseService()
        {
            Status = false;
        }
    }

    public class ResponseService : ResponseService<object>{ }
}
