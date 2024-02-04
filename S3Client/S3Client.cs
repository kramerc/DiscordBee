namespace MusicBeePlugin.S3Client
{
  using Amazon.S3;
  using Amazon.S3.Model;
  using MusicBeePlugin.S3Client.Types;
  using System;
  using System.Drawing;
  using System.Drawing.Imaging;
  using System.Linq;
  using System.Threading.Tasks;

  public class S3Client : IDisposable
  {
    private readonly S3Config _config;
    private readonly AmazonS3Client _client;

    public S3Client(S3Config config)
    {
      _config = config;
      var clientConfig = new AmazonS3Config
      {
        ServiceURL = config.Endpoint,
      };
      _client = new AmazonS3Client(config.AccessKeyId, config.SecretAccessKey, clientConfig);
    }

    public async Task<S3Image[]> GetAlbumImages()
    {
      var listRequest = new ListObjectsV2Request
      {
        BucketName = _config.BucketName,
        Prefix = _config.Prefix,
      };

      var response = await _client.ListObjectsV2Async(listRequest);
      return response.S3Objects.Select(obj => new S3Image
      {
        Key = obj.Key,
        Link = $"{GetBaseUrl()}/{obj.Key}",
      }).ToArray();
    }

    public async Task<S3Image> UploadImage(string hash, string dataB64)
    {
      var key = $"{_config.Prefix}/{hash}";
      var imageStream = new System.IO.MemoryStream(Convert.FromBase64String(dataB64));

      // Get content type of image for S3
      string contentType = "image/unknown";
      using (var image = Image.FromStream(imageStream))
      {
        Guid guid = image.RawFormat.Guid;
        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageDecoders())
        {
          if (codec.FormatID == guid)
          {
            contentType = codec.MimeType;
            break;
          }
        }
      }

      var putRequest = new PutObjectRequest
      {
        BucketName = _config.BucketName,
        Key = $"{_config.Prefix}/{hash}",
        ContentType = contentType,
        InputStream = imageStream,
        CannedACL = S3CannedACL.PublicRead,
      };

      var response = await _client.PutObjectAsync(putRequest);
      if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        return new S3Image
        {
          Key = key,
          Link = $"{GetBaseUrl()}/{key}",
        };
      }
      else
      {
        return null;
      }
    }

    public async Task<bool> TestConnection()
    {
      // Check if an S3 request can be successfully made
      try
      {
        var listRequest = new ListObjectsV2Request
        {
          BucketName = _config.BucketName,
          Prefix = _config.Prefix,
        };

        var response = await _client.ListObjectsV2Async(listRequest);
        return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
      }
      catch
      {
        return false;
      }
    }

    public void Dispose()
    {
      _client?.Dispose();
      GC.SuppressFinalize(this);
    }

    private string GetBaseUrl()
    {
      return _config.CustomDomain ?? _config.Endpoint;
    }
  }
}
