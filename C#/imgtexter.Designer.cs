namespace image_folder_to_text
{
    partial class imgtexter
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
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.folderButton = new System.Windows.Forms.Button();
            this.severButton = new System.Windows.Forms.Button();
            this.severNotButton = new System.Windows.Forms.Button();
            this.numerationButton = new System.Windows.Forms.Button();
            this.numerationNotButton = new System.Windows.Forms.Button();
            this.bigButtonContainer = new System.Windows.Forms.SplitContainer();
            this.middleContainer = new System.Windows.Forms.SplitContainer();
            this.numContainer = new System.Windows.Forms.SplitContainer();
            this.severContainer = new System.Windows.Forms.SplitContainer();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bigButtonContainer)).BeginInit();
            this.bigButtonContainer.Panel1.SuspendLayout();
            this.bigButtonContainer.Panel2.SuspendLayout();
            this.bigButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.middleContainer)).BeginInit();
            this.middleContainer.Panel1.SuspendLayout();
            this.middleContainer.Panel2.SuspendLayout();
            this.middleContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numContainer)).BeginInit();
            this.numContainer.Panel1.SuspendLayout();
            this.numContainer.Panel2.SuspendLayout();
            this.numContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.severContainer)).BeginInit();
            this.severContainer.Panel1.SuspendLayout();
            this.severContainer.Panel2.SuspendLayout();
            this.severContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.bigButtonContainer);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.consoleBox);
            this.mainContainer.Size = new System.Drawing.Size(553, 724);
            this.mainContainer.SplitterDistance = 180;
            this.mainContainer.TabIndex = 0;
            // 
            // folderButton
            // 
            this.folderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.folderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.folderButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.folderButton.Location = new System.Drawing.Point(0, 0);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(553, 87);
            this.folderButton.TabIndex = 0;
            this.folderButton.Text = "Выбрать папку";
            this.folderButton.UseVisualStyleBackColor = false;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // severButton
            // 
            this.severButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.severButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.severButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.severButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.severButton.Location = new System.Drawing.Point(0, 1);
            this.severButton.Name = "severButton";
            this.severButton.Size = new System.Drawing.Size(275, 40);
            this.severButton.TabIndex = 1;
            this.severButton.Text = "с разрывом страницы";
            this.severButton.UseVisualStyleBackColor = false;
            this.severButton.Click += new System.EventHandler(this.severButton_Click);
            // 
            // severNotButton
            // 
            this.severNotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.severNotButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.severNotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.severNotButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.severNotButton.Location = new System.Drawing.Point(1, 0);
            this.severNotButton.Name = "severNotButton";
            this.severNotButton.Size = new System.Drawing.Size(272, 42);
            this.severNotButton.TabIndex = 2;
            this.severNotButton.Text = "без разрыва страницы";
            this.severNotButton.UseVisualStyleBackColor = false;
            this.severNotButton.Click += new System.EventHandler(this.severNotButton_Click);
            // 
            // numerationButton
            // 
            this.numerationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numerationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numerationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numerationButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.numerationButton.Location = new System.Drawing.Point(0, 0);
            this.numerationButton.Name = "numerationButton";
            this.numerationButton.Size = new System.Drawing.Size(275, 43);
            this.numerationButton.TabIndex = 3;
            this.numerationButton.Text = "с нумерацией страниц";
            this.numerationButton.UseVisualStyleBackColor = false;
            this.numerationButton.Click += new System.EventHandler(this.numerationButton_Click);
            // 
            // numerationNotButton
            // 
            this.numerationNotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numerationNotButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.numerationNotButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.numerationNotButton.FlatAppearance.BorderSize = 0;
            this.numerationNotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numerationNotButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.numerationNotButton.Location = new System.Drawing.Point(1, 0);
            this.numerationNotButton.Name = "numerationNotButton";
            this.numerationNotButton.Size = new System.Drawing.Size(272, 43);
            this.numerationNotButton.TabIndex = 4;
            this.numerationNotButton.Text = "без нумерации страниц";
            this.numerationNotButton.UseVisualStyleBackColor = false;
            this.numerationNotButton.Click += new System.EventHandler(this.numerationNotButton_Click);
            // 
            // bigButtonContainer
            // 
            this.bigButtonContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigButtonContainer.Location = new System.Drawing.Point(0, 0);
            this.bigButtonContainer.Name = "bigButtonContainer";
            this.bigButtonContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // bigButtonContainer.Panel1
            // 
            this.bigButtonContainer.Panel1.Controls.Add(this.folderButton);
            // 
            // bigButtonContainer.Panel2
            // 
            this.bigButtonContainer.Panel2.Controls.Add(this.middleContainer);
            this.bigButtonContainer.Size = new System.Drawing.Size(553, 180);
            this.bigButtonContainer.SplitterDistance = 87;
            this.bigButtonContainer.TabIndex = 0;
            // 
            // middleContainer
            // 
            this.middleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleContainer.Location = new System.Drawing.Point(0, 0);
            this.middleContainer.Name = "middleContainer";
            this.middleContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // middleContainer.Panel1
            // 
            this.middleContainer.Panel1.Controls.Add(this.numContainer);
            // 
            // middleContainer.Panel2
            // 
            this.middleContainer.Panel2.Controls.Add(this.severContainer);
            this.middleContainer.Size = new System.Drawing.Size(553, 89);
            this.middleContainer.SplitterDistance = 43;
            this.middleContainer.TabIndex = 0;
            // 
            // numContainer
            // 
            this.numContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numContainer.Location = new System.Drawing.Point(0, 0);
            this.numContainer.Name = "numContainer";
            // 
            // numContainer.Panel1
            // 
            this.numContainer.Panel1.Controls.Add(this.numerationButton);
            // 
            // numContainer.Panel2
            // 
            this.numContainer.Panel2.Controls.Add(this.numerationNotButton);
            this.numContainer.Size = new System.Drawing.Size(553, 43);
            this.numContainer.SplitterDistance = 276;
            this.numContainer.TabIndex = 0;
            // 
            // severContainer
            // 
            this.severContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.severContainer.Location = new System.Drawing.Point(0, 0);
            this.severContainer.Name = "severContainer";
            // 
            // severContainer.Panel1
            // 
            this.severContainer.Panel1.Controls.Add(this.severButton);
            // 
            // severContainer.Panel2
            // 
            this.severContainer.Panel2.Controls.Add(this.severNotButton);
            this.severContainer.Size = new System.Drawing.Size(553, 42);
            this.severContainer.SplitterDistance = 276;
            this.severContainer.TabIndex = 0;
            // 
            // consoleBox
            // 
            this.consoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.consoleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consoleBox.ForeColor = System.Drawing.SystemColors.Info;
            this.consoleBox.Location = new System.Drawing.Point(0, 1);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(553, 539);
            this.consoleBox.TabIndex = 0;
            this.consoleBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(553, 724);
            this.Controls.Add(this.mainContainer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.bigButtonContainer.Panel1.ResumeLayout(false);
            this.bigButtonContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bigButtonContainer)).EndInit();
            this.bigButtonContainer.ResumeLayout(false);
            this.middleContainer.Panel1.ResumeLayout(false);
            this.middleContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.middleContainer)).EndInit();
            this.middleContainer.ResumeLayout(false);
            this.numContainer.Panel1.ResumeLayout(false);
            this.numContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numContainer)).EndInit();
            this.numContainer.ResumeLayout(false);
            this.severContainer.Panel1.ResumeLayout(false);
            this.severContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.severContainer)).EndInit();
            this.severContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Button severNotButton;
        private System.Windows.Forms.Button severButton;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Button numerationNotButton;
        private System.Windows.Forms.Button numerationButton;
        private System.Windows.Forms.SplitContainer severContainer;
        private System.Windows.Forms.SplitContainer bigButtonContainer;
        private System.Windows.Forms.SplitContainer middleContainer;
        private System.Windows.Forms.SplitContainer numContainer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.RichTextBox consoleBox;
    }
}

