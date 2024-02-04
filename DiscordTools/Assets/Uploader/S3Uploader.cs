namespace MusicBeePlugin.DiscordTools.Assets.Uploader
{
  using MusicBeePlugin.S3Client;
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.IO;
  using System.Threading;
  using System.Threading.Tasks;

  public class S3Uploader : IAssetUploader
  {
    private readonly S3Client _client;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public S3Uploader(S3Config config)
    {
      _client = new S3Client(config);
    }

    public Task<bool> DeleteAsset(AlbumCoverData assetData)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      _client.Dispose();
    }

    public async Task<Dictionary<string, string>> GetAssets()
    {
      var ret = new Dictionary<string, string>();
      var images = await _client.GetAlbumImages();

      foreach (var image in images)
      {
        var hash = Path.GetFileName(image.Key);
        if (string.IsNullOrEmpty(hash))
        {
          continue;
        }
        ret[hash] = image.Link;
      }

      return ret;
    }

    public async Task<bool> Init()
    {
      Debug.WriteLine(" ---> Waiting for semaphore");
      await _semaphore.WaitAsync();
      Debug.WriteLine(" <--- Waiting for semaphore");
      try
      {
        // Nothing to do.
      }
      finally
      {
        Debug.WriteLine(" ---> Releasing semaphore");
        _semaphore.Release();
      }
      return true;
    }

    public bool IsAssetCached(AlbumCoverData assetData)
    {
      return false;
    }

    public UploaderHealthInfo GetHealth()
    {
      // The S3 API does not have rate limit headers, so we assume it's always healthy
      var health = new UploaderHealthInfo
      {
        IsHealthy = true
      };
      return health;
    }

    public async Task<UploadResult> UploadAsset(AlbumCoverData assetData)
    {
      var uploaded = await _client.UploadImage(assetData.Hash, assetData.ImageB64);
      return new UploadResult { Hash = assetData.Hash, Link = uploaded.Link };
    }
  }
}
