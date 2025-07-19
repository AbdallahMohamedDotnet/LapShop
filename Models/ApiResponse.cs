namespace LapShopv2.Models
{
    public class ApiResponse  : IContract.IApiResponse
    {
        public object Data { get; set; }

        public object Errors { get; set; }

        public string CodeStats { get; set; }
    }
}
