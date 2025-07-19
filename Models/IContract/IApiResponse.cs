namespace LapShopv2.Models.IContract
{
    public interface IApiResponse
    {
        public object Data { get; set; }

        public object Errors { get; set; }

        public string CodeStats { get; set; }
    }
}
