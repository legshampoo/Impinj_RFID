namespace _45PPC_RFID
{
    partial class Application
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
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ReaderInfo = new System.Windows.Forms.TextBox();
            this.TagConsole = new System.Windows.Forms.TextBox();
            this.TagsFound = new System.Windows.Forms.TableLayoutPanel();
            this.TagWriterButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.ColumnCount = 3;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.MainPanel.Controls.Add(this.ConnectButton, 0, 0);
            this.MainPanel.Controls.Add(this.ReaderInfo, 0, 1);
            this.MainPanel.Controls.Add(this.TagConsole, 1, 1);
            this.MainPanel.Controls.Add(this.TagWriterButton, 2, 0);
            this.MainPanel.Controls.Add(this.TagsFound, 1, 2);
            this.MainPanel.Location = new System.Drawing.Point(12, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 3;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.6453F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.35471F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPanel.Size = new System.Drawing.Size(1004, 663);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectButton.Location = new System.Drawing.Point(0, 0);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(224, 104);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click_1);
            // 
            // ReaderInfo
            // 
            this.ReaderInfo.Location = new System.Drawing.Point(3, 107);
            this.ReaderInfo.Multiline = true;
            this.ReaderInfo.Name = "ReaderInfo";
            this.ReaderInfo.ReadOnly = true;
            this.ReaderInfo.Size = new System.Drawing.Size(212, 296);
            this.ReaderInfo.TabIndex = 1;
            // 
            // TagConsole
            // 
            this.TagConsole.Location = new System.Drawing.Point(227, 107);
            this.TagConsole.Multiline = true;
            this.TagConsole.Name = "TagConsole";
            this.TagConsole.ReadOnly = true;
            this.TagConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TagConsole.Size = new System.Drawing.Size(629, 296);
            this.TagConsole.TabIndex = 2;
            // 
            // TagsFound
            // 
            this.TagsFound.BackColor = System.Drawing.SystemColors.Control;
            this.TagsFound.ColumnCount = 1;
            this.TagsFound.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TagsFound.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TagsFound.Location = new System.Drawing.Point(227, 410);
            this.TagsFound.Name = "TagsFound";
            this.TagsFound.RowCount = 1;
            this.TagsFound.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TagsFound.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TagsFound.Size = new System.Drawing.Size(629, 250);
            this.TagsFound.TabIndex = 3;
            // 
            // TagWriterButton
            // 
            this.TagWriterButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.TagWriterButton.Location = new System.Drawing.Point(879, 3);
            this.TagWriterButton.Name = "TagWriterButton";
            this.TagWriterButton.Size = new System.Drawing.Size(122, 98);
            this.TagWriterButton.TabIndex = 4;
            this.TagWriterButton.Text = "Write To Tags";
            this.TagWriterButton.UseVisualStyleBackColor = true;
            this.TagWriterButton.Click += new System.EventHandler(this.TagWriterButton_Click);
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 687);
            this.Controls.Add(this.MainPanel);
            this.Name = "Application";
            this.Text = "Application";
            this.Load += new System.EventHandler(this.Application_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox ReaderInfo;
        private System.Windows.Forms.TextBox TagConsole;
        private System.Windows.Forms.TableLayoutPanel TagsFound;
        private System.Windows.Forms.Button TagWriterButton;
    }
}

