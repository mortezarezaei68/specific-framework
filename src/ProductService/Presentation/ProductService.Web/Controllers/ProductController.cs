using System.Threading.Tasks;
using Framework.Buses;
using Framework.Controller.Extensions;
using Microsoft.AspNetCore.Mvc;
using ProductModel.Command.ProductCommand;

namespace ProductService.Web.Controllers
{
    
    public class ProductController:BaseController
    {
        private readonly IEventBus _eventBus;

        public ProductController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest command)
        {
            var data=await _eventBus.Issue(command);
            return Ok(data);
        }
    }
}