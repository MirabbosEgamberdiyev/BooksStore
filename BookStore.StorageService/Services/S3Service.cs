using Amazon.S3;
using Amazon.S3.Model;


namespace BookStore.StorageService.Services;

public class S3Service : IS3Service
{
    private readonly IAmazonS3 _amazonS3;
    private const string bucketName = "mirabbos-image";

    public S3Service(IAmazonS3 amazonS3)
    {
        _amazonS3 = amazonS3;
    }

    public async Task DeleteFileAsync(string fileName)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = fileName
        };

        await _amazonS3.DeleteObjectAsync(deleteObjectRequest);
    }

    public async Task<string> GetFileUrlAsync(string fileName)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = bucketName,
            Key = fileName,
            Expires = DateTime.UtcNow.AddHours(1) // URL expiration time
        };

        string url =  _amazonS3.GetPreSignedURL(request);

        return url;
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        using var fileStream = file.OpenReadStream();
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var fileKey = bucketName + "/" + fileName;
        var putObjectRequest = new PutObjectRequest
        {
            InputStream = fileStream,
            BucketName = bucketName,
            Key = fileKey
        };
        await _amazonS3.PutObjectAsync(putObjectRequest);
        return fileKey;
    }
}
