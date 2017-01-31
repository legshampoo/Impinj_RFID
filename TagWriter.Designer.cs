namespace _45PPC_RFID
{
    partial class TagWriter
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
            this.UserInput = new System.Windows.Forms.TextBox();
            this.WriteButton = new System.Windows.Forms.Button();
            this.NewEpcLabel = new System.Windows.Forms.Label();
            this.EpcLengthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserInput
            // 
            this.UserInput.Location = new System.Drawing.Point(137, 59);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(330, 22);
            this.UserInput.TabIndex = 0;
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(181, 127);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(230, 85);
            this.WriteButton.TabIndex = 1;
            this.WriteButton.Text = "Write to Tag";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // NewEpcLabel
            // 
            this.NewEpcLabel.AutoSize = true;
            this.NewEpcLabel.Location = new System.Drawing.Point(253, 39);
            this.NewEpcLabel.Name = "NewEpcLabel";
            this.NewEpcLabel.Size = new System.Drawing.Size(70, 17);
            this.NewEpcLabel.TabIndex = 3;
            this.NewEpcLabel.Text = "New EPC:";
            this.NewEpcLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // EpcLengthLabel
            // 
            this.EpcLengthLabel.AutoSize = true;
            this.EpcLengthLabel.Location = new System.Drawing.Point(157, 86);
            this.EpcLengthLabel.Name = "EpcLengthLabel";
            this.EpcLengthLabel.Size = new System.Drawing.Size(292, 17);
            this.EpcLengthLabel.TabIndex = 4;
            this.EpcLengthLabel.Text = "(number of characters must be divisible by 4)";
            // 
            // TagWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 249);
            this.Controls.Add(this.EpcLengthLabel);
            this.Controls.Add(this.NewEpcLabel);
            this.Controls.Add(this.WriteButton);
            this.Controls.Add(this.UserInput);
            this.Name = "TagWriter";
            this.Text = "TagWriter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserInput;
        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.Label NewEpcLabel;
        private System.Windows.Forms.Label EpcLengthLabel;
    }
}