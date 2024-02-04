namespace MusicBeePlugin.UI
{
  using MusicBeePlugin.S3Client;
  using System;
  using System.Drawing;
  using System.Windows.Forms;

  public partial class S3SettingsWindow : Form
  {
    private readonly Settings _settings;

    public S3SettingsWindow(Settings settings)
    {
      _settings = settings;
      InitializeComponent();
      UpdateValues(_settings);

      Shown += OnShown;
      VisibleChanged += OnVisibleChanged;
    }

    private void OnVisibleChanged(object sender, EventArgs eventArgs)
    {
      if (Visible)
      {
        UpdateValues(_settings);
      }
    }

    private void OnShown(object sender, EventArgs eventArgs)
    {
      UpdateValues(_settings);
    }

    private void UpdateValues(Settings settings)
    {
      textBoxS3AccessKeyId.Text = settings.S3AccessKeyId;
      textBoxS3SecretAccessKey.Text = settings.S3SecretAccessKey;
      textBoxS3Endpoint.Text = settings.S3Endpoint;
      textBoxS3BucketName.Text = settings.S3BucketName;
      textBoxS3Prefix.Text = settings.S3Prefix;
      textBoxS3CustomDomain.Text = settings.S3CustomDomain;

      ValidateInputs();
    }

    private void UpdateUrlPreview()
    {
      if (string.IsNullOrWhiteSpace(textBoxS3BucketName.Text))
      {
        textBoxUrlPreview.Text = "";
        return;
      }

      var endpoint = textBoxS3Endpoint.Text;
      var customDomain = textBoxS3CustomDomain.Text;

      // Detect insecure scheme and default to secure HTTPS if not present
      var insecure = customDomain.StartsWith($"{Uri.UriSchemeHttp}://") ||
        string.IsNullOrWhiteSpace(customDomain) && endpoint.StartsWith($"{Uri.UriSchemeHttp}://");

      // Strip schemes from endpoint and custom domain
      endpoint = endpoint.Replace($"{Uri.UriSchemeHttp}://", "").Replace($"{Uri.UriSchemeHttps}://", "");
      customDomain = customDomain.Replace($"{Uri.UriSchemeHttp}://", "").Replace($"{Uri.UriSchemeHttps}://", "");

      var scheme = $"{(insecure ? Uri.UriSchemeHttp : Uri.UriSchemeHttps)}://";
      var baseUrl = string.IsNullOrWhiteSpace(textBoxS3CustomDomain.Text) ? $"{endpoint}/{textBoxS3BucketName.Text}" : customDomain;
      var prefix = string.IsNullOrWhiteSpace(textBoxS3Prefix.Text) ? "" : $"{textBoxS3Prefix.Text}/";
      textBoxUrlPreview.Text = $"{scheme}{baseUrl}/{prefix}example";
    }

    private bool ValidateInputs()
    {
      // Validate the entire form for all errors. Does not enforce any type of format as they differ between various S3 implementations.
      int errors = 0;

      bool validateAccessKeyId()
      {
        if (string.IsNullOrWhiteSpace(textBoxS3AccessKeyId.Text))
        {
          textBoxS3AccessKeyId.BackColor = Color.PaleVioletRed;
          return false;
        }

        textBoxS3AccessKeyId.BackColor = Color.White;
        return true;
      }

      if (!validateAccessKeyId())
      {
        errors++;
      }

      bool validateSecretAccessKey()
      {
        if (string.IsNullOrWhiteSpace(textBoxS3SecretAccessKey.Text))
        {
          textBoxS3SecretAccessKey.BackColor = Color.PaleVioletRed;
          return false;
        }

        textBoxS3SecretAccessKey.BackColor = Color.White;
        return true;
      }

      if (!validateSecretAccessKey())
      {
        errors++;
      }

      bool validateEndpoint()
      {
        if (string.IsNullOrWhiteSpace(textBoxS3Endpoint.Text))
        {
          textBoxS3Endpoint.BackColor = Color.PaleVioletRed;
          return false;
        }

        var endpoint = textBoxS3Endpoint.Text;
        if (!endpoint.StartsWith($"{Uri.UriSchemeHttp}://") && !endpoint.StartsWith($"{Uri.UriSchemeHttps}://"))
        {
          endpoint = $"{Uri.UriSchemeHttps}://{endpoint}";
        }

        if (!ValidationHelpers.ValidateUri(endpoint))
        {
          textBoxS3Endpoint.BackColor = Color.PaleVioletRed;
          return false;
        }

        textBoxS3Endpoint.BackColor = Color.White;
        return true;
      }

      if (!validateEndpoint())
      {
        errors++;
      }

      bool validateBucketName()
      {
        if (string.IsNullOrWhiteSpace(textBoxS3BucketName.Text))
        {
          textBoxS3BucketName.BackColor = Color.PaleVioletRed;
          return false;
        }

        textBoxS3BucketName.BackColor = Color.White;
        return true;
      }

      if (!validateBucketName())
      {
        errors++;
      }

      bool validateCustomDomain()
      {
        var customDomain = textBoxS3CustomDomain.Text;
        if (!customDomain.StartsWith($"{Uri.UriSchemeHttp}://") && !customDomain.StartsWith($"{Uri.UriSchemeHttps}://"))
        {
          customDomain = $"{Uri.UriSchemeHttps}://{customDomain}";
        }

        if (!ValidationHelpers.ValidateUri(customDomain))
        {
          textBoxS3CustomDomain.BackColor = Color.PaleVioletRed;
          return false;
        }

        textBoxS3CustomDomain.BackColor = Color.White;
        return true;
      }

      if (textBoxS3CustomDomain.Text.Length > 0 && !validateCustomDomain())
      {
        errors++;
      }

      if (errors > 0)
      {
        return false;
      }

      ResetErrorIndications();

      return true; 
    }

    private void ResetErrorIndications()
    {
      textBoxS3AccessKeyId.BackColor = SystemColors.Window;
      textBoxS3SecretAccessKey.BackColor = SystemColors.Window;
      textBoxS3Endpoint.BackColor = SystemColors.Window;
      textBoxS3BucketName.BackColor = SystemColors.Window;
      textBoxS3Prefix.BackColor = SystemColors.Window;
      textBoxS3CustomDomain.BackColor = SystemColors.Window;
    }

    private void textBoxS3AccessKeyId_TextChanged(object sender, EventArgs e)
    {
      ValidateInputs();
    }

    private void textBoxS3SecretAccessKey_TextChanged(object sender, EventArgs e)
    {
      ValidateInputs();
    }

    private void textBoxS3Endpoint_TextChanged(object sender, EventArgs e)
    {
      UpdateUrlPreview();
      ValidateInputs();
    }

    private void textBoxS3BucketName_TextChanged(object sender, EventArgs e)
    {
      UpdateUrlPreview();
      ValidateInputs();
    }

    private void textBoxS3Prefix_TextChanged(object sender, EventArgs e)
    {
      UpdateUrlPreview();
      ValidateInputs();
    }

    private void textBoxS3CustomDomain_TextChanged(object sender, EventArgs e)
    {
      UpdateUrlPreview();
      ValidateInputs();
    }

    private async void buttonTest_Click(object sender, EventArgs e)
    {
      buttonTest.Enabled = false;
      buttonTest.Text = "Testing...";

      var s3Client = new S3Client(new S3Config
      {
        AccessKeyId = textBoxS3AccessKeyId.Text,
        SecretAccessKey = textBoxS3SecretAccessKey.Text,
        Endpoint = textBoxS3Endpoint.Text,
        BucketName = textBoxS3BucketName.Text,
        Prefix = textBoxS3Prefix.Text,
        CustomDomain = textBoxS3CustomDomain.Text
      });

      if (await s3Client.TestConnection())
      {
        MessageBox.Show("Connection successfully established to S3 bucket.", "Test Connection Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        MessageBox.Show("A connection could not be successfully made to the S3 bucket. Please check your credentials and configuration and try again.", "Test Connection Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      buttonTest.Enabled = true;
      buttonTest.Text = "Test Connection";
    }

    private void buttonSaveClose_Click(object sender, EventArgs e)
    {
      if (!ValidateInputs())
      {
        return;
      }

      _settings.S3AccessKeyId = textBoxS3AccessKeyId.Text;
      _settings.S3SecretAccessKey = textBoxS3SecretAccessKey.Text;
      _settings.S3Endpoint = textBoxS3Endpoint.Text;
      _settings.S3BucketName = textBoxS3BucketName.Text;
      _settings.S3Prefix = textBoxS3Prefix.Text;
      _settings.S3CustomDomain = textBoxS3CustomDomain.Text;

      ((SettingsWindow) Owner).ValidateInputs();
      Close();
    }
  }
}
