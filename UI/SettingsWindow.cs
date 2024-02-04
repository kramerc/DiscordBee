namespace MusicBeePlugin.UI
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Linq;
  using System.Windows.Forms;

  public partial class SettingsWindow : Form
  {
    private readonly Plugin _parent;
    private PlaceholderTableWindow _placeholderTableWindow;
    private readonly Settings _settings;
    private bool _defaultsRestored;

    public SettingsWindow(Plugin parent, Settings settings)
    {
      _parent = parent;
      _settings = settings;
      InitializeComponent();
      UpdateValues(_settings);
      Text += " (v" + parent.GetVersionString() + ")";

      FormClosing += OnFormClosing;
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

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason != CloseReason.UserClosing)
      {
        return;
      }

      Hide();
      e.Cancel = true;
    }

    private void UpdateValues(Settings settings)
    {
      textBoxTrackNo.Text = settings.PresenceTrackNo;
      textBoxTrackCnt.Text = settings.PresenceTrackCnt;
      textBoxDetails.Text = settings.PresenceDetails;
      textBoxState.Text = settings.PresenceState;
      textBoxLargeImage.Text = settings.LargeImageText;
      textBoxSmallImage.Text = settings.SmallImageText;
      textBoxSeparator.Text = settings.Separator;
      textBoxDiscordAppId.Text = settings.DiscordAppId.Equals(Settings.defaults["DiscordAppId"]) ? "" : settings.DiscordAppId;
      textBoxImgurClientId.Text = settings.ImgurClientId.Equals(Settings.defaults["ImgurClientId"]) ? "" : settings.ImgurClientId;
      checkBoxPresenceUpdate.Checked = settings.UpdatePresenceWhenStopped;
      checkBoxShowTime.Checked = settings.ShowTime;
      checkBoxShowRemainingTime.Checked = settings.ShowRemainingTime;
      checkBoxTextOnly.Checked = settings.TextOnly;
      checkBoxShowPlayState.Checked = settings.ShowPlayState;
      checkBoxShowOnlyNonPlayingState.Checked = settings.ShowOnlyNonPlayingState;
      checkBoxArtworkUpload.Checked = settings.UploadArtwork;
      comboBoxArtworkUploader.SelectedIndex = comboBoxArtworkUploader.FindString(settings.ArtworkUploader);
      customButtonLabel.Text = settings.ButtonLabel;
      customButtonUrl.Text = settings.ButtonUrl;
      customButtonToggle.Checked = settings.ShowButton;

      ValidateInputs();
    }

    private void buttonPlaceholders_Click(object sender, EventArgs e)
    {
      _placeholderTableWindow = new PlaceholderTableWindow();
      _placeholderTableWindow.UpdateTable(_parent.GenerateMetaDataDictionary());
      _placeholderTableWindow.Show(this);
    }

    private void buttonRestoreDefaults_Click(object sender, EventArgs e)
    {
      _settings.Clear();
      UpdateValues(_settings);
      _defaultsRestored = true;
    }

    private void buttonSaveClose_Click(object sender, EventArgs e)
    {
      if (!ValidateInputs())
      {
        return;
      }

      _settings.PresenceTrackNo = textBoxTrackNo.Text;
      _settings.PresenceTrackCnt = textBoxTrackCnt.Text;
      _settings.PresenceDetails = textBoxDetails.Text;
      _settings.PresenceState = textBoxState.Text;
      _settings.LargeImageText = textBoxLargeImage.Text;
      _settings.SmallImageText = textBoxSmallImage.Text;
      _settings.Separator = textBoxSeparator.Text;
      _settings.DiscordAppId = string.IsNullOrWhiteSpace(textBoxDiscordAppId.Text) ? null : textBoxDiscordAppId.Text;
      _settings.ImgurClientId = string.IsNullOrWhiteSpace(textBoxImgurClientId.Text) ? null : textBoxImgurClientId.Text;
      _settings.UpdatePresenceWhenStopped = checkBoxPresenceUpdate.Checked;
      _settings.ShowTime = checkBoxShowTime.Checked;
      _settings.ShowRemainingTime = checkBoxShowRemainingTime.Checked;
      _settings.TextOnly = checkBoxTextOnly.Checked;
      _settings.ShowPlayState = checkBoxShowPlayState.Checked;
      _settings.ShowOnlyNonPlayingState = checkBoxShowOnlyNonPlayingState.Checked;
      _settings.UploadArtwork = checkBoxArtworkUpload.Checked;
      _settings.ArtworkUploader = comboBoxArtworkUploader.SelectedItem.ToString();
      _settings.ButtonUrl = customButtonUrl.Text;
      _settings.ButtonLabel = customButtonLabel.Text;
      _settings.ShowButton = customButtonToggle.Checked;

      if (_defaultsRestored && !_settings.IsDirty)
      {
        _settings.Delete();
        _defaultsRestored = false;
      }

      _settings.Save();
      Hide();
    }

    internal bool ValidateInputs()
    {
      bool ContainsDigitsOnly(string s)
      {
        foreach (char c in s)
        {
          if (c < '0' || c > '9')
          {
            return false;
          }
        }
        return true;
      }

      bool validateDiscordId()
      {
        if (textBoxDiscordAppId.Text.Length < 18 || textBoxDiscordAppId.Text.Length > 19
          || textBoxDiscordAppId.Text.Equals(Settings.defaults["DiscordAppId"])
          || !ContainsDigitsOnly(textBoxDiscordAppId.Text))
        {
          textBoxDiscordAppId.BackColor = Color.PaleVioletRed;
          return false;
        }
        textBoxDiscordAppId.BackColor = Color.White;
        return true;
      }

      if (textBoxDiscordAppId.Text.Length > 0 && !validateDiscordId())
      {
        return false;
      }

      bool validateImgurClientId()
      {
        if (textBoxImgurClientId.Text.Length != Settings.defaults["ImgurClientId"].Length
          || textBoxImgurClientId.Text.Equals(Settings.defaults["ImgurClientId"]))
        {
          textBoxImgurClientId.BackColor = Color.PaleVioletRed;
          return false;
        }
        textBoxImgurClientId.BackColor = Color.White;
        return true;
      }

      bool validateS3()
      {
        if (string.IsNullOrWhiteSpace(_settings.S3AccessKeyId) ||
              string.IsNullOrWhiteSpace(_settings.S3SecretAccessKey) ||
              string.IsNullOrWhiteSpace(_settings.S3BucketName))
        {
          buttonS3Settings.BackColor = Color.PaleVioletRed;
          return false;
        }
        buttonS3Settings.BackColor = Color.White;
        return true;
      }

      if (checkBoxArtworkUpload.Checked && comboBoxArtworkUploader.SelectedItem != null)
      {
        comboBoxArtworkUploader.BackColor = Color.White;

        switch (comboBoxArtworkUploader.SelectedItem.ToString())
        {
          case "Imgur":
            if (textBoxImgurClientId.Text.Length > 0 && !validateImgurClientId())
            {
              return false;
            }
            break;
          case "Amazon S3":
            if (!validateS3())
            {
              return false;
            }
            break;
          default:
            comboBoxArtworkUploader.BackColor = Color.PaleVioletRed;
            return false;
        }
      }

      bool validateUri()
      {
        if (!ValidationHelpers.ValidateUri(customButtonUrl.Text))
        {
          customButtonUrl.BackColor = Color.PaleVioletRed;
          return false;
        }

        customButtonUrl.BackColor = Color.FromArgb(114, 137, 218);
        return true;
      }

      if (!validateUri())
      {
        return false;
      }

      ResetErrorIndications();

      return true;
    }

    private void ResetErrorIndications()
    {
      textBoxDiscordAppId.BackColor = SystemColors.Window;
      textBoxImgurClientId.BackColor = SystemColors.Window;
      buttonS3Settings.BackColor = SystemColors.Window;
      customButtonUrl.BackColor = Color.FromArgb(114, 137, 218);
    }

    private void textBoxDiscordAppId_TextChanged(object sender, EventArgs e)
    {
      ValidateInputs();
    }

    private void checkBoxArtworkUpload_CheckedChanged(object sender, EventArgs e)
    {
      ValidateInputs();
    }

    private void customButtonUrl_TextChanged(object sender, EventArgs e)
    {
      ValidateInputs();
    }

    private void textBoxImgurClientId_TextChanged(object sender, EventArgs e)
    {
      ValidateInputs();
    }

    private void comboBoxArtworkUploader_SelectedIndexChanged(object sender, EventArgs e)
    {
      ValidateInputs();

      if (comboBoxArtworkUploader.SelectedIndex == comboBoxArtworkUploader.FindString("Amazon S3"))
      {
        labelImgurClientId.Visible = false;
        textBoxImgurClientId.Visible = false;
        buttonS3Settings.Visible = true;
      }
      else
      {
        labelImgurClientId.Visible = true;
        textBoxImgurClientId.Visible = true;
        buttonS3Settings.Visible = false;
      }
    }

    private void buttonS3Settings_Click(object sender, EventArgs e)
    {
      var s3SettingsWindow = new S3SettingsWindow(_settings);
      s3SettingsWindow.ShowDialog(this);
    }
  }
}
