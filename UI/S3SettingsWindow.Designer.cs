namespace MusicBeePlugin.UI
{
  partial class S3SettingsWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelS3AccessKeyId = new System.Windows.Forms.Label();
            this.textBoxS3AccessKeyId = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSaveClose = new System.Windows.Forms.Button();
            this.textBoxS3SecretAccessKey = new System.Windows.Forms.TextBox();
            this.labelS3SecretAccessKey = new System.Windows.Forms.Label();
            this.textBoxS3Endpoint = new System.Windows.Forms.TextBox();
            this.labelS3Endpoint = new System.Windows.Forms.Label();
            this.textBoxS3BucketName = new System.Windows.Forms.TextBox();
            this.labelS3BucketName = new System.Windows.Forms.Label();
            this.textBoxS3Prefix = new System.Windows.Forms.TextBox();
            this.labelS3Prefix = new System.Windows.Forms.Label();
            this.textBoxS3CustomDomain = new System.Windows.Forms.TextBox();
            this.labelS3CustomDomain = new System.Windows.Forms.Label();
            this.labelUrlPreview = new System.Windows.Forms.Label();
            this.textBoxUrlPreview = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.labelUrlPreview);
            this.panel2.Controls.Add(this.labelS3CustomDomain);
            this.panel2.Controls.Add(this.labelS3Prefix);
            this.panel2.Controls.Add(this.textBoxUrlPreview);
            this.panel2.Controls.Add(this.textBoxS3CustomDomain);
            this.panel2.Controls.Add(this.textBoxS3Prefix);
            this.panel2.Controls.Add(this.labelS3BucketName);
            this.panel2.Controls.Add(this.textBoxS3BucketName);
            this.panel2.Controls.Add(this.labelS3Endpoint);
            this.panel2.Controls.Add(this.textBoxS3Endpoint);
            this.panel2.Controls.Add(this.labelS3SecretAccessKey);
            this.panel2.Controls.Add(this.textBoxS3SecretAccessKey);
            this.panel2.Controls.Add(this.labelS3AccessKeyId);
            this.panel2.Controls.Add(this.textBoxS3AccessKeyId);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 329);
            this.panel2.TabIndex = 3;
            // 
            // labelS3AccessKeyId
            // 
            this.labelS3AccessKeyId.AutoSize = true;
            this.labelS3AccessKeyId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS3AccessKeyId.ForeColor = System.Drawing.Color.Black;
            this.labelS3AccessKeyId.Location = new System.Drawing.Point(13, 22);
            this.labelS3AccessKeyId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelS3AccessKeyId.Name = "labelS3AccessKeyId";
            this.labelS3AccessKeyId.Size = new System.Drawing.Size(131, 22);
            this.labelS3AccessKeyId.TabIndex = 19;
            this.labelS3AccessKeyId.Text = "Access Key ID:";
            // 
            // textBoxS3AccessKeyId
            // 
            this.textBoxS3AccessKeyId.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS3AccessKeyId.Location = new System.Drawing.Point(182, 17);
            this.textBoxS3AccessKeyId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxS3AccessKeyId.Name = "textBoxS3AccessKeyId";
            this.textBoxS3AccessKeyId.Size = new System.Drawing.Size(576, 33);
            this.textBoxS3AccessKeyId.TabIndex = 0;
            this.textBoxS3AccessKeyId.TextChanged += new System.EventHandler(this.textBoxS3AccessKeyId_TextChanged);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.buttonTest);
            this.panel3.Controls.Add(this.buttonSaveClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 329);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.MinimumSize = new System.Drawing.Size(0, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 46);
            this.panel3.TabIndex = 4;
            // 
            // buttonSaveClose
            // 
            this.buttonSaveClose.AutoSize = true;
            this.buttonSaveClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSaveClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSaveClose.Location = new System.Drawing.Point(640, 0);
            this.buttonSaveClose.Margin = new System.Windows.Forms.Padding(15);
            this.buttonSaveClose.Name = "buttonSaveClose";
            this.buttonSaveClose.Padding = new System.Windows.Forms.Padding(8);
            this.buttonSaveClose.Size = new System.Drawing.Size(146, 46);
            this.buttonSaveClose.TabIndex = 8;
            this.buttonSaveClose.Text = "Save and Close";
            this.buttonSaveClose.UseVisualStyleBackColor = true;
            this.buttonSaveClose.Click += new System.EventHandler(this.buttonSaveClose_Click);
            // 
            // textBoxS3SecretAccessKey
            // 
            this.textBoxS3SecretAccessKey.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS3SecretAccessKey.Location = new System.Drawing.Point(182, 60);
            this.textBoxS3SecretAccessKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxS3SecretAccessKey.Name = "textBoxS3SecretAccessKey";
            this.textBoxS3SecretAccessKey.PasswordChar = '*';
            this.textBoxS3SecretAccessKey.Size = new System.Drawing.Size(576, 33);
            this.textBoxS3SecretAccessKey.TabIndex = 1;
            this.textBoxS3SecretAccessKey.TextChanged += new System.EventHandler(this.textBoxS3SecretAccessKey_TextChanged);
            // 
            // labelS3SecretAccessKey
            // 
            this.labelS3SecretAccessKey.AutoSize = true;
            this.labelS3SecretAccessKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS3SecretAccessKey.ForeColor = System.Drawing.Color.Black;
            this.labelS3SecretAccessKey.Location = new System.Drawing.Point(13, 64);
            this.labelS3SecretAccessKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelS3SecretAccessKey.Name = "labelS3SecretAccessKey";
            this.labelS3SecretAccessKey.Size = new System.Drawing.Size(166, 22);
            this.labelS3SecretAccessKey.TabIndex = 19;
            this.labelS3SecretAccessKey.Text = "Secret Access Key:";
            // 
            // textBoxS3Endpoint
            // 
            this.textBoxS3Endpoint.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS3Endpoint.Location = new System.Drawing.Point(182, 103);
            this.textBoxS3Endpoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxS3Endpoint.Name = "textBoxS3Endpoint";
            this.textBoxS3Endpoint.Size = new System.Drawing.Size(576, 33);
            this.textBoxS3Endpoint.TabIndex = 2;
            this.textBoxS3Endpoint.TextChanged += new System.EventHandler(this.textBoxS3Endpoint_TextChanged);
            // 
            // labelS3Endpoint
            // 
            this.labelS3Endpoint.AutoSize = true;
            this.labelS3Endpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS3Endpoint.ForeColor = System.Drawing.Color.Black;
            this.labelS3Endpoint.Location = new System.Drawing.Point(13, 108);
            this.labelS3Endpoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelS3Endpoint.Name = "labelS3Endpoint";
            this.labelS3Endpoint.Size = new System.Drawing.Size(86, 22);
            this.labelS3Endpoint.TabIndex = 19;
            this.labelS3Endpoint.Text = "Endpoint:";
            // 
            // textBoxS3BucketName
            // 
            this.textBoxS3BucketName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS3BucketName.Location = new System.Drawing.Point(182, 146);
            this.textBoxS3BucketName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxS3BucketName.Name = "textBoxS3BucketName";
            this.textBoxS3BucketName.Size = new System.Drawing.Size(576, 33);
            this.textBoxS3BucketName.TabIndex = 3;
            this.textBoxS3BucketName.TextChanged += new System.EventHandler(this.textBoxS3BucketName_TextChanged);
            // 
            // labelS3BucketName
            // 
            this.labelS3BucketName.AutoSize = true;
            this.labelS3BucketName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS3BucketName.ForeColor = System.Drawing.Color.Black;
            this.labelS3BucketName.Location = new System.Drawing.Point(13, 152);
            this.labelS3BucketName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelS3BucketName.Name = "labelS3BucketName";
            this.labelS3BucketName.Size = new System.Drawing.Size(122, 22);
            this.labelS3BucketName.TabIndex = 19;
            this.labelS3BucketName.Text = "Bucket Name:";
            // 
            // textBoxS3Prefix
            // 
            this.textBoxS3Prefix.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS3Prefix.Location = new System.Drawing.Point(182, 189);
            this.textBoxS3Prefix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxS3Prefix.Name = "textBoxS3Prefix";
            this.textBoxS3Prefix.Size = new System.Drawing.Size(576, 33);
            this.textBoxS3Prefix.TabIndex = 4;
            this.textBoxS3Prefix.TextChanged += new System.EventHandler(this.textBoxS3Prefix_TextChanged);
            // 
            // labelS3Prefix
            // 
            this.labelS3Prefix.AutoSize = true;
            this.labelS3Prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS3Prefix.ForeColor = System.Drawing.Color.Black;
            this.labelS3Prefix.Location = new System.Drawing.Point(13, 195);
            this.labelS3Prefix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelS3Prefix.Name = "labelS3Prefix";
            this.labelS3Prefix.Size = new System.Drawing.Size(61, 22);
            this.labelS3Prefix.TabIndex = 19;
            this.labelS3Prefix.Text = "Prefix:";
            // 
            // textBoxS3CustomDomain
            // 
            this.textBoxS3CustomDomain.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxS3CustomDomain.Location = new System.Drawing.Point(182, 232);
            this.textBoxS3CustomDomain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxS3CustomDomain.Name = "textBoxS3CustomDomain";
            this.textBoxS3CustomDomain.Size = new System.Drawing.Size(576, 33);
            this.textBoxS3CustomDomain.TabIndex = 5;
            this.textBoxS3CustomDomain.TextChanged += new System.EventHandler(this.textBoxS3CustomDomain_TextChanged);
            // 
            // labelS3CustomDomain
            // 
            this.labelS3CustomDomain.AutoSize = true;
            this.labelS3CustomDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS3CustomDomain.ForeColor = System.Drawing.Color.Black;
            this.labelS3CustomDomain.Location = new System.Drawing.Point(13, 238);
            this.labelS3CustomDomain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelS3CustomDomain.Name = "labelS3CustomDomain";
            this.labelS3CustomDomain.Size = new System.Drawing.Size(142, 22);
            this.labelS3CustomDomain.TabIndex = 19;
            this.labelS3CustomDomain.Text = "Custom Domain:";
            // 
            // labelUrlPreview
            // 
            this.labelUrlPreview.AutoSize = true;
            this.labelUrlPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUrlPreview.ForeColor = System.Drawing.Color.Black;
            this.labelUrlPreview.Location = new System.Drawing.Point(13, 279);
            this.labelUrlPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUrlPreview.Name = "labelUrlPreview";
            this.labelUrlPreview.Size = new System.Drawing.Size(120, 22);
            this.labelUrlPreview.TabIndex = 19;
            this.labelUrlPreview.Text = "URL Preview:";
            // 
            // textBoxUrlPreview
            // 
            this.textBoxUrlPreview.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUrlPreview.Location = new System.Drawing.Point(182, 273);
            this.textBoxUrlPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxUrlPreview.Name = "textBoxUrlPreview";
            this.textBoxUrlPreview.ReadOnly = true;
            this.textBoxUrlPreview.Size = new System.Drawing.Size(576, 33);
            this.textBoxUrlPreview.TabIndex = 6;
            // 
            // buttonTest
            // 
            this.buttonTest.AutoSize = true;
            this.buttonTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonTest.Location = new System.Drawing.Point(0, 0);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(15);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Padding = new System.Windows.Forms.Padding(8);
            this.buttonTest.Size = new System.Drawing.Size(151, 46);
            this.buttonTest.TabIndex = 7;
            this.buttonTest.Text = "Test Connection";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // S3SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(786, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(774, 391);
            this.Name = "S3SettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Amazon S3 Settings";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label labelS3AccessKeyId;
    private System.Windows.Forms.TextBox textBoxS3AccessKeyId;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button buttonSaveClose;
    private System.Windows.Forms.Label labelS3Prefix;
    private System.Windows.Forms.TextBox textBoxS3Prefix;
    private System.Windows.Forms.Label labelS3BucketName;
    private System.Windows.Forms.TextBox textBoxS3BucketName;
    private System.Windows.Forms.Label labelS3Endpoint;
    private System.Windows.Forms.TextBox textBoxS3Endpoint;
    private System.Windows.Forms.Label labelS3SecretAccessKey;
    private System.Windows.Forms.TextBox textBoxS3SecretAccessKey;
    private System.Windows.Forms.Label labelS3CustomDomain;
    private System.Windows.Forms.TextBox textBoxS3CustomDomain;
    private System.Windows.Forms.Label labelUrlPreview;
    private System.Windows.Forms.TextBox textBoxUrlPreview;
    private System.Windows.Forms.Button buttonTest;
  }
}
