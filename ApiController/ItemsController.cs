using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using LapShopv2.Models.IContract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShopv2.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController(I_DB_TBItem item , IApiResponse apiResponse)
        {
            this.item = item;
            this.apiResponse = apiResponse;
        }
        I_DB_TBItem item;
        IApiResponse apiResponse;
        // GET: api/<ValuesController>

        [HttpGet]
        public IApiResponse Get()
        {
            apiResponse.CodeStats = "200";
            apiResponse.Data = item.GetAll();
            if (apiResponse.Data == null)
            {
                apiResponse.Errors = "No items found";
                apiResponse.CodeStats = "404";
            }
            else
            {
                apiResponse.Errors = null;
            }
            return apiResponse;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IApiResponse Get(int id)
        {
            var itemData = item.GetById(id);
            if (itemData == null)
            {
                apiResponse.Errors = "Item not found";
                apiResponse.CodeStats = "404";
            }
            else
            {
                apiResponse.Data = itemData;
                apiResponse.Errors = null;
                apiResponse.CodeStats = "200";
            }
            return apiResponse;
        }

        [HttpGet]
        [Route("GetByCategoryId/{id}")]
        public IEnumerable<VwItem> GetByCategoryId(int id)
        {
            return item.GetAllItemData(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IApiResponse Post([FromBody] TbItem NewItem)
        {
            try
            {
                if (NewItem == null)
                {
                    apiResponse.Errors = "Item data is null";
                    apiResponse.CodeStats = "400";
                    apiResponse.Data = null;
                    return apiResponse;
                }
                var addedItem = item.Save(NewItem);
                if (addedItem == null)
                {
                    apiResponse.Errors = "Failed to add item";
                    apiResponse.CodeStats = "500";
                    apiResponse.Data = null;
                }
                else
                {
                    apiResponse.Data = addedItem;
                    apiResponse.Errors = null;
                    apiResponse.CodeStats = "201"; // Created
                }
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.Errors = ex.Message;
                apiResponse.CodeStats = "500"; // Internal Server Error
                apiResponse.Data = null;
                return apiResponse;

            }
        }

        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int id)
        {
            item.Delete(id);
        }


    }
}
