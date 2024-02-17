using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.StorageService.Services;
using System;
using System.Threading.Tasks;

namespace BookStore.StorageService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IS3Service _s3Service;

    public ImagesController(IS3Service s3Service)
    {
        _s3Service = s3Service;
    }

    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is null or empty");

        try
        {
            var fileKey = await _s3Service.UploadFileAsync(file);
            return Ok(fileKey);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

    [HttpDelete("delete-image/{fileName}")]
    public async Task<IActionResult> DeleteImage(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest("File name is null or empty");

        try
        {
            await _s3Service.DeleteFileAsync(fileName);
            return Ok("File deleted successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

    [HttpGet("get-image-url/{fileName}")]
    public async Task<IActionResult> GetImageUrl(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest("File name is null or empty");

        try
        {
            var url = await _s3Service.GetFileUrlAsync(fileName);
            return Ok(url);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }
}
