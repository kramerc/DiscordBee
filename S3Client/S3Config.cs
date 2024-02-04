namespace MusicBeePlugin.S3Client
{
  using System;
  using System.Reflection;

  public class S3Config
  {
    public string AccessKeyId { get; set; }
    public string SecretAccessKey { get; set; }

    private readonly string _endpoint;
    public string Endpoint
    {
      get => _endpoint;
      set => PrefixSchemeIfNecessary("_endpoint", value);
    }

    public string BucketName { get; set; }
    public string Prefix { get; set; }

    private readonly string _customDomain;
    public string CustomDomain {
      get => _customDomain;
      set => PrefixSchemeIfNecessary("_customDomain", value);
    }

    private void PrefixSchemeIfNecessary(string fieldName, string value)
    {
      FieldInfo target = GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
      if (target == null)
      {
        return;
      }

      if (string.IsNullOrEmpty(value))
      {
        target.SetValue(this, value);
        return;
      }

      if (value.StartsWith($"{Uri.UriSchemeHttp}://") || value.StartsWith($"{Uri.UriSchemeHttps}://"))
      {
        target.SetValue(this, value);
        return;
      }

      target.SetValue(this, $"{Uri.UriSchemeHttps}://{value}");
    }
  }
}
