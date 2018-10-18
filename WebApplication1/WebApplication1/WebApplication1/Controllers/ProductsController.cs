using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Entities;
using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Dtos.Queries;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        IProductService productService;
        IMapper mapper;
        public ProductsController(IMapper mapper, IProductService productService)
        {
            this.mapper = mapper;
            this.productService = productService;
        }
        /*[HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.Get();
        }*/
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] ProductQuery query)
        {
            return Ok(await productService.Get(query));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await productService.Get(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            await productService.Create(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            await productService.Update(id, product);
            return Ok(product);
        }
    }
}