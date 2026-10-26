using Microsoft.AspNetCore.Mvc;
using PracticaIntegradora4.Models.DTOs.Requests;
using PracticaIntegradora4.Models.DTOs.Responses;
using PracticaIntegradora4.Services.Interfaces;
using System.Runtime.InteropServices;

namespace PracticaIntegradora4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ProductForReadDto>> GetAll()
    {
        return Ok(_service.GetAllProducts());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ProductForReadDto> GetById(int id)
    {
        var product = _service.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<ProductForReadDto> Create(ProductForCreateDto dto)
    {
        try
        {
            var createdProduct = _service.CreateProduct(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, ProductForUpdateDto dto)
    {
        var existing = _service.GetProductById(id);
        if (existing == null)
        {
            return NotFound();
        }

        _service.UpdateProduct(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existing = _service.GetProductById(id);
        if (existing == null)
        {
            return NotFound();
        }

        _service.DeleteProduct(id);
        return NoContent();
    }

    [HttpGet("search")]
    public ActionResult<List<ProductForReadDto>> Search([FromQuery] string name)
    {
        return Ok(_service.SearchProductsByName(name ?? string.Empty));
    }

    [HttpGet("stats")]
    public ActionResult<ProductStatsDto> GetStats()
    {
        return Ok(_service.GetStats());
    }
}