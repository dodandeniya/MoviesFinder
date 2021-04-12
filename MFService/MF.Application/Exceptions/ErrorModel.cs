namespace MF.Application.Exceptions
{
    public class ErrorModel
    {
        public ErrorModel(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; set; }
        public string Description { get; set; }
    }
}