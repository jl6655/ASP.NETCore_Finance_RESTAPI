using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context; // Set to readonly to ensure we can't change database context
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        // 'IActionResult' is a fancy wrapper for when multiple action result return types are possible (HTTP status codes)
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList() // 'ToList()' => Deferred execution
             .Select(s => s.ToStockDto()); // 'Select' => map

            return Ok(stocks);
        }

        [HttpGet("{id}")] // '{id}' => Model binding
        public IActionResult GetById([FromRoute] int id) 
        {
            var stock = _context.Stocks.Find(id);

            if(stock == null) 
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto) 
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if(stockModel == null) 
            {
                return NotFound();
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            _context.SaveChanges();

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if(stockModel == null) 
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);
            
            _context.SaveChanges();

            return NoContent();
        }
    }
}