namespace BookStore.StorageService.Services;

public interface IS3Service
{
    public Task<string> UploadFileAsync(IFormFile file);
    public Task DeleteFileAsync(string FileName);
    public Task<string> GetFileUrlAsync(string fileName);

}
