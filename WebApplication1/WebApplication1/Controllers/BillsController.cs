using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Dtos;
using AutoMapper;
using WebApplication1.Entities;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class BillsController : Controller
    {
        IBillService billService;
        IMapper mapper;
        public BillsController(IBillService billService,IMapper mapper)
        {
            this.billService = billService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await billService.Get());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BillDto billDto)
        {
            var bill = mapper.Map<Bill>(billDto);
            await billService.Create(bill);
            return Ok(bill);
        }
    }
}