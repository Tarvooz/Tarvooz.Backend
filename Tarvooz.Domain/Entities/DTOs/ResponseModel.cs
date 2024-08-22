namespace Tarvooz.Domain.Entities.DTOs
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Response { get; set; }
    }
}
