namespace ContactManager
{
    partial class SearchForm
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
            this.firstNameSearchFormLabel = new System.Windows.Forms.Label();
            this.firstNameSearchFormTextBox = new System.Windows.Forms.TextBox();
            this.searchSearchFormButton = new System.Windows.Forms.Button();
            this.cancelSearchFormButton = new System.Windows.Forms.Button();
            this.lastNameSearchFormTextBox = new System.Windows.Forms.TextBox();
            this.lastNameSearchFormLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNameSearchFormLabel
            // 
            this.firstNameSearchFormLabel.AutoSize = true;
            this.firstNameSearchFormLabel.Location = new System.Drawing.Point(46, 24);
            this.firstNameSearchFormLabel.Name = "firstNameSearchFormLabel";
            this.firstNameSearchFormLabel.Size = new System.Drawing.Size(57, 13);
            this.firstNameSearchFormLabel.TabIndex = 0;
            this.firstNameSearchFormLabel.Text = "First Name";
            // 
            // firstNameSearchFormTextBox
            // 
            this.firstNameSearchFormTextBox.Location = new System.Drawing.Point(27, 51);
            this.firstNameSearchFormTextBox.Name = "firstNameSearchFormTextBox";
            this.firstNameSearchFormTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameSearchFormTextBox.TabIndex = 1;
            this.firstNameSearchFormTextBox.TextChanged += new System.EventHandler(this.firstNameSearchFormTextBox_TextChanged);
            // 
            // searchSearchFormButton
            // 
            this.searchSearchFormButton.Location = new System.Drawing.Point(27, 177);
            this.searchSearchFormButton.Name = "searchSearchFormButton";
            this.searchSearchFormButton.Size = new System.Drawing.Size(75, 23);
            this.searchSearchFormButton.TabIndex = 2;
            this.searchSearchFormButton.Text = "Search";
            this.searchSearchFormButton.UseVisualStyleBackColor = true;
            this.searchSearchFormButton.Click += new System.EventHandler(this.searchSearchFormButton_Click);
            // 
            // cancelSearchFormButton
            // 
            this.cancelSearchFormButton.Location = new System.Drawing.Point(126, 177);
            this.cancelSearchFormButton.Name = "cancelSearchFormButton";
            this.cancelSearchFormButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSearchFormButton.TabIndex = 2;
            this.cancelSearchFormButton.Text = "Cancel";
            this.cancelSearchFormButton.UseVisualStyleBackColor = true;
            this.cancelSearchFormButton.Click += new System.EventHandler(this.cancelSearchFormButton_Click);
            // 
            // lastNameSearchFormTextBox
            // 
            this.lastNameSearchFormTextBox.Location = new System.Drawing.Point(27, 120);
            this.lastNameSearchFormTextBox.Name = "lastNameSearchFormTextBox";
            this.lastNameSearchFormTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameSearchFormTextBox.TabIndex = 3;
            this.lastNameSearchFormTextBox.TextChanged += new System.EventHandler(this.lastNameSearchFormTextBox_TextChanged);
            // 
            // lastNameSearchFormLabel
            // 
            this.lastNameSearchFormLabel.AutoSize = true;
            this.lastNameSearchFormLabel.Location = new System.Drawing.Point(46, 91);
            this.lastNameSearchFormLabel.Name = "lastNameSearchFormLabel";
            this.lastNameSearchFormLabel.Size = new System.Drawing.Size(58, 13);
            this.lastNameSearchFormLabel.TabIndex = 4;
            this.lastNameSearchFormLabel.Text = "Last Name";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lastNameSearchFormLabel);
            this.Controls.Add(this.lastNameSearchFormTextBox);
            this.Controls.Add(this.cancelSearchFormButton);
            this.Controls.Add(this.searchSearchFormButton);
            this.Controls.Add(this.firstNameSearchFormTextBox);
            this.Controls.Add(this.firstNameSearchFormLabel);
            this.Name = "SearchForm";
            this.Text = "Search Form";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameSearchFormLabel;
        private System.Windows.Forms.TextBox firstNameSearchFormTextBox;
        private System.Windows.Forms.Button searchSearchFormButton;
        private System.Windows.Forms.Button cancelSearchFormButton;
        private System.Windows.Forms.TextBox lastNameSearchFormTextBox;
        private System.Windows.Forms.Label lastNameSearchFormLabel;
    }
}