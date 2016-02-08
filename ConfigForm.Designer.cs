namespace TrayLightControl {
    partial class ConfigForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.labelIP = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.buttonIPFind = new System.Windows.Forms.Button();
            this.labelGroupNames = new System.Windows.Forms.Label();
            this.textGroup1 = new System.Windows.Forms.TextBox();
            this.textGroup2 = new System.Windows.Forms.TextBox();
            this.textGroup3 = new System.Windows.Forms.TextBox();
            this.textGroup4 = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(13, 13);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(115, 13);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "Wifi Bridge IP Address:";
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(134, 10);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(129, 20);
            this.textIP.TabIndex = 1;
            this.textIP.Text = "0.0.0.0";
            // 
            // buttonIPFind
            // 
            this.buttonIPFind.Location = new System.Drawing.Point(269, 10);
            this.buttonIPFind.Name = "buttonIPFind";
            this.buttonIPFind.Size = new System.Drawing.Size(112, 20);
            this.buttonIPFind.TabIndex = 2;
            this.buttonIPFind.Text = "Find automatically";
            this.buttonIPFind.UseVisualStyleBackColor = true;
            this.buttonIPFind.Click += new System.EventHandler(this.buttonIPFind_Click);
            // 
            // labelGroupNames
            // 
            this.labelGroupNames.AutoSize = true;
            this.labelGroupNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupNames.Location = new System.Drawing.Point(12, 40);
            this.labelGroupNames.Name = "labelGroupNames";
            this.labelGroupNames.Size = new System.Drawing.Size(73, 13);
            this.labelGroupNames.TabIndex = 3;
            this.labelGroupNames.Text = "Group names:";
            // 
            // textGroup1
            // 
            this.textGroup1.Location = new System.Drawing.Point(15, 65);
            this.textGroup1.Name = "textGroup1";
            this.textGroup1.Size = new System.Drawing.Size(168, 20);
            this.textGroup1.TabIndex = 4;
            this.textGroup1.Text = "Group 1";
            // 
            // textGroup2
            // 
            this.textGroup2.Location = new System.Drawing.Point(15, 91);
            this.textGroup2.Name = "textGroup2";
            this.textGroup2.Size = new System.Drawing.Size(168, 20);
            this.textGroup2.TabIndex = 5;
            this.textGroup2.Text = "Group 2";
            // 
            // textGroup3
            // 
            this.textGroup3.Location = new System.Drawing.Point(15, 117);
            this.textGroup3.Name = "textGroup3";
            this.textGroup3.Size = new System.Drawing.Size(168, 20);
            this.textGroup3.TabIndex = 6;
            this.textGroup3.Text = "Group 3";
            // 
            // textGroup4
            // 
            this.textGroup4.Location = new System.Drawing.Point(15, 143);
            this.textGroup4.Name = "textGroup4";
            this.textGroup4.Size = new System.Drawing.Size(168, 20);
            this.textGroup4.TabIndex = 7;
            this.textGroup4.Text = "Group 4";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 192);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(373, 33);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 237);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textGroup4);
            this.Controls.Add(this.textGroup3);
            this.Controls.Add(this.textGroup2);
            this.Controls.Add(this.textGroup1);
            this.Controls.Add(this.labelGroupNames);
            this.Controls.Add(this.buttonIPFind);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.labelIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Milight Control Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Button buttonIPFind;
        private System.Windows.Forms.Label labelGroupNames;
        private System.Windows.Forms.TextBox textGroup1;
        private System.Windows.Forms.TextBox textGroup2;
        private System.Windows.Forms.TextBox textGroup3;
        private System.Windows.Forms.TextBox textGroup4;
        private System.Windows.Forms.Button buttonSave;
    }
}