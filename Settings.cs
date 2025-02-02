namespace MusicBeePlugin
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Reflection;
  using System.Runtime.Serialization;
  using System.Xml;

  [DataContract]
  public class Settings
  {
    private string FilePath { get; set; }
    public bool IsDirty { get; private set; }

    public static readonly IReadOnlyDictionary<string, string> defaults = new Dictionary<string, string>()
    {
      {"Separator", "./-_"},
      {"LargeImageText", "MusicBee"},
      {"SmallImageText", "[Volume]%"},
      {"PresenceState", "[TrackTitle]"},
      {"PresenceDetails", "[Artist] - [Album]"},
      {"PresenceTrackCnt", "[TrackCount]"},
      {"PresenceTrackNo", "[TrackNo]"},
      {"ButtonLabel", "View Last.fm Info"},
      {"ButtonUrl", "https://www.last.fm/music/[Artist]/_/[TrackTitle]"},
      {"DiscordAppId", "409394531948298250"}, // prod
      //{"DiscordAppId", "408977077799354379"}, // dev
      {"ImgurClientId", "09bef4c058080cd"},
      {"ArtworkUploader", "Imgur"},
      {"S3AccessKeyId", ""},
      {"S3SecretAccessKey", ""},
      {"S3Endpoint", "s3.amazonaws.com"},
      {"S3BucketName", ""},
      {"S3Prefix", "DiscordBee"},
      {"S3CustomDomain", ""},
    };

    public event EventHandler<SettingChangedEventArgs> SettingChanged;

    // Don't serialize properties so only user set changes are serialized and not default values

    #region Settings

    [DataMember] private string _separator;

    public string Separator
    {
      get => _separator ?? defaults["Separator"];
      set => SetIfChanged("_separator", value);
    }

    [DataMember] private string _largeImageText;

    public string LargeImageText
    {
      get => _largeImageText ?? defaults["LargeImageText"];
      set => SetIfChanged("_largeImageText", value);
    }

    [DataMember] private string _smallImageText;

    public string SmallImageText
    {
      get => _smallImageText ?? defaults["SmallImageText"];
      set => SetIfChanged("_smallImageText", value);
    }

    [DataMember] private string _presenceState;

    public string PresenceState
    {
      get => _presenceState ?? defaults["PresenceState"];
      set => SetIfChanged("_presenceState", value);
    }

    [DataMember] private string _presenceDetails;

    public string PresenceDetails
    {
      get => _presenceDetails ?? defaults["PresenceDetails"];
      set => SetIfChanged("_presenceDetails", value);
    }

    [DataMember] private string _presenceTrackCnt;

    public string PresenceTrackCnt
    {
      get => _presenceTrackCnt ?? defaults["PresenceTrackCnt"];
      set => SetIfChanged("_presenceTrackCnt", value);
    }

    [DataMember] private string _presenceTrackNo;

    public string PresenceTrackNo
    {
      get => _presenceTrackNo ?? defaults["PresenceTrackNo"];
      set => SetIfChanged("_presenceTrackNo", value);
    }

    [DataMember] private string _discordAppId;

    public string DiscordAppId
    {
      get => _discordAppId ?? defaults["DiscordAppId"];
      set
      {
        if (value?.Equals(defaults["DiscordAppId"]) == true)
        {
          _discordAppId = null;
          return;
        }
        SetIfChanged("_discordAppId", value);
      }
    }

    [DataMember] private string _imgurClientId;

    public string ImgurClientId
    {
      get => _imgurClientId ?? defaults["ImgurClientId"];
      set
      {
        if (value?.Equals(defaults["ImgurClientId"]) == true)
        {
          _imgurClientId = null;
          return;
        }
        SetIfChanged("_imgurClientId", value);
      }
    }

    [DataMember] private string _s3AccessKeyId;

    public string S3AccessKeyId
    {
      get => _s3AccessKeyId ?? defaults["S3AccessKeyId"];
      set => SetIfChanged("_s3AccessKeyId", value);
    }

    [DataMember] private string _s3SecretAccessKey;

    public string S3SecretAccessKey
    {
      get => _s3SecretAccessKey ?? defaults["S3SecretAccessKey"];
      set => SetIfChanged("_s3SecretAccessKey", value);
    }

    [DataMember] private string _s3Endpoint;

    public string S3Endpoint
    {
      get => _s3Endpoint ?? defaults["S3Endpoint"];
      set => SetIfChanged("_s3Endpoint", value);
    }

    [DataMember] private string _s3BucketName;

    public string S3BucketName
    {
      get => _s3BucketName ?? defaults["S3BucketName"];
      set => SetIfChanged("_s3BucketName", value);
    }

    [DataMember] private string _s3Prefix;

    public string S3Prefix
    {
      get => _s3Prefix ?? defaults["S3Prefix"];
      set => SetIfChanged("_s3Prefix", value);
    }

    [DataMember] private string _s3CustomDomain;

    public string S3CustomDomain
    {
      get => _s3CustomDomain ?? defaults["S3CustomDomain"];
      set => SetIfChanged("_s3CustomDomain", value);
    }

    [DataMember] private bool? _updatePresenceWhenStopped;

    public bool UpdatePresenceWhenStopped
    {
      get => !_updatePresenceWhenStopped.HasValue || _updatePresenceWhenStopped.Value;
      set => SetIfChanged("_updatePresenceWhenStopped", value);
    }

    [DataMember] private bool? _showTime;

    public bool ShowTime
    {
      get => _showTime == true;
      set => SetIfChanged("_showTime", value);
    }

    [DataMember] private bool? _showRemainingTime;

    public bool ShowRemainingTime
    {
      get => _showRemainingTime == true;
      set => SetIfChanged("_showRemainingTime", value);
    }

    [DataMember] private bool? _textOnly;

    public bool TextOnly
    {
      get => _textOnly == true;
      set => SetIfChanged("_textOnly", value);
    }

    [DataMember] private bool? _showPlayState;

    public bool ShowPlayState
    {
      get => _showPlayState == true;
      set => SetIfChanged("_showPlayState", value);
    }

    [DataMember] private bool? _showOnlyNonPlayingState;

    public bool ShowOnlyNonPlayingState
    {
      get => _showOnlyNonPlayingState == true;
      set => SetIfChanged("_showOnlyNonPlayingState", value);
    }

    [DataMember] private bool? _uploadArtwork;

    public bool UploadArtwork
    {
      get => _uploadArtwork == true;
      set => SetIfChanged("_uploadArtwork", value);
    }

    [DataMember] private string _artworkUploader;

    public string ArtworkUploader
    {
      get => _artworkUploader ?? defaults["ArtworkUploader"];
      set
      {
        if (value?.Equals(defaults["ArtworkUploader"]) == true)
        {
          _artworkUploader = null;
          return;
        }
        SetIfChanged("_artworkUploader", value);
      }
    }

    [DataMember] private string _buttonLabel;

    public string ButtonLabel
    {
      get => string.IsNullOrEmpty(_buttonLabel) ? defaults["ButtonLabel"] : _buttonLabel;
      set
      {
        if (value?.Equals(defaults["ButtonLabel"]) == true)
        {
          _buttonLabel = null;
          return;
        }
        SetIfChanged("_buttonLabel", value);
      }
    }

    [DataMember] private string _buttonUrl;

    public string ButtonUrl
    {
      get => string.IsNullOrEmpty(_buttonUrl) ? defaults["ButtonUrl"] : _buttonUrl;
      set
      {
        if (value?.Equals(defaults["ButtonUrl"]) == true)
        {
          _buttonUrl = null;
          return;
        }
        SetIfChanged("_buttonUrl", value);
      }
    }

    [DataMember] private bool? _showButton;

    public bool ShowButton
    {
      get => _showButton == true;
      set => SetIfChanged("_showButton", value);
    }

    #endregion

    public static Settings GetInstance(string filePath)
    {
      Settings newSettings;

      try
      {
        newSettings = Load(filePath);
      }
      catch (Exception e) when (e is IOException || e is XmlException || e is InvalidOperationException)
      {
        newSettings = new Settings();
      }

      newSettings.FilePath = filePath;

      return newSettings;
    }

    private void SetIfChanged<T>(string fieldName, T value)
    {
      FieldInfo target = GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

      if (target != null)
      {
        PropertyInfo targetProp = GetType().GetProperty(GetPropertyNameForField(target.Name), BindingFlags.Instance | BindingFlags.Public);
        object old = targetProp?.GetValue(this, null);
        if (targetProp != null && !old.Equals(value))
        {
          target.SetValue(this, value);
          IsDirty = true;
          var eventArgs = new SettingChangedEventArgs
          {
            SettingProperty = targetProp.Name,
            OldValue = old,
            NewValue = value
          };
          OnSettingChanged(eventArgs);
        }
      }
    }

    private string GetPropertyNameForField(string field)
    {
      if (field.StartsWith("_"))
      {
        string tmp = field.Remove(0, 1);
        return tmp[0].ToString().ToUpper() + tmp.Substring(1);
      }
      return null;
    }

    public void Save()
    {
      if (!IsDirty)
      {
        return;
      }

      if (Path.GetDirectoryName(FilePath) != null && !Directory.Exists(Path.GetDirectoryName(FilePath)))
      {
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath) ?? throw new InvalidOperationException());
      }

      using (var writer = XmlWriter.Create(FilePath))
      {
        var serializer = new DataContractSerializer(GetType());
        serializer.WriteObject(writer, this);
        writer.Flush();
      }
    }

    private static Settings Load(string filePath)
    {
      using (var stream = File.OpenRead(filePath))
      {
        var serializer = new DataContractSerializer(typeof(Settings));
        return serializer.ReadObject(stream) as Settings;
      }
    }

    public void Delete()
    {
      if (File.Exists(FilePath))
      {
        File.Delete(FilePath);
      }

      if (Path.GetDirectoryName(FilePath) != null && Directory.Exists(Path.GetDirectoryName(FilePath)))
      {
        Directory.Delete(Path.GetDirectoryName(FilePath) ?? throw new InvalidOperationException());
      }

      Clear();
    }

    public void Clear()
    {
      foreach (var propertyInfo in GetType().GetProperties())
      {
        if (propertyInfo.PropertyType == typeof(string) && propertyInfo.Name != "FilePath")
        {
          propertyInfo.SetValue(this, null, null);
        }
      }

      // field is used for boolean settings because nullable is used internally and property would be non-nullable
      foreach (var fieldInfo in GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
      {
        if (!fieldInfo.Name.StartsWith("_"))
        {
          continue;
        }

        if (fieldInfo.FieldType == typeof(bool?))
        {
          fieldInfo.SetValue(this, null);
        }
      }

      IsDirty = false;
    }

    protected virtual void OnSettingChanged(SettingChangedEventArgs e)
    {
      SettingChanged?.Invoke(this, e);
    }

    public class SettingChangedEventArgs : EventArgs
    {
      public string SettingProperty { get; set; }
      public object OldValue { get; set; }
      public object NewValue { get; set; }
    }
  }
}
