namespace IOW28KIT
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_requestIowStatus = new System.Windows.Forms.Button();
            this.lbl_DeviceId = new System.Windows.Forms.Label();
            this.lbl_HandleOfIow = new System.Windows.Forms.Label();
            this.cb_IowSelector = new System.Windows.Forms.ComboBox();
            this.btn_switchToVisualizer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_requestIowStatus
            // 
            this.btn_requestIowStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_requestIowStatus.Location = new System.Drawing.Point(272, 29);
            this.btn_requestIowStatus.Name = "btn_requestIowStatus";
            this.btn_requestIowStatus.Size = new System.Drawing.Size(75, 23);
            this.btn_requestIowStatus.TabIndex = 0;
            this.btn_requestIowStatus.Text = "Request";
            this.btn_requestIowStatus.UseVisualStyleBackColor = true;
            this.btn_requestIowStatus.Click += new System.EventHandler(this.btn_requestIowStatus_Click);
            // 
            // lbl_DeviceId
            // 
            this.lbl_DeviceId.AutoSize = true;
            this.lbl_DeviceId.Location = new System.Drawing.Point(9, 63);
            this.lbl_DeviceId.Name = "lbl_DeviceId";
            this.lbl_DeviceId.Size = new System.Drawing.Size(44, 13);
            this.lbl_DeviceId.TabIndex = 1;
            this.lbl_DeviceId.Text = "IOW-Id:";
            // 
            // lbl_HandleOfIow
            // 
            this.lbl_HandleOfIow.AutoSize = true;
            this.lbl_HandleOfIow.Location = new System.Drawing.Point(9, 39);
            this.lbl_HandleOfIow.Name = "lbl_HandleOfIow";
            this.lbl_HandleOfIow.Size = new System.Drawing.Size(102, 13);
            this.lbl_HandleOfIow.TabIndex = 2;
            this.lbl_HandleOfIow.Text = "Seriennummer IOW:";
            // 
            // cb_IowSelector
            // 
            this.cb_IowSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_IowSelector.FormattingEnabled = true;
            this.cb_IowSelector.Location = new System.Drawing.Point(0, 0);
            this.cb_IowSelector.Name = "cb_IowSelector";
            this.cb_IowSelector.Size = new System.Drawing.Size(359, 21);
            this.cb_IowSelector.Sorted = true;
            this.cb_IowSelector.TabIndex = 3;
            this.cb_IowSelector.SelectedIndexChanged += new System.EventHandler(this.cb_IowSelector_SelectedIndexChanged);
            // 
            // btn_switchToVisualizer
            // 
            this.btn_switchToVisualizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_switchToVisualizer.Location = new System.Drawing.Point(272, 58);
            this.btn_switchToVisualizer.Name = "btn_switchToVisualizer";
            this.btn_switchToVisualizer.Size = new System.Drawing.Size(75, 23);
            this.btn_switchToVisualizer.TabIndex = 4;
            this.btn_switchToVisualizer.Text = "Visualizer";
            this.btn_switchToVisualizer.UseVisualStyleBackColor = true;
            this.btn_switchToVisualizer.Click += new System.EventHandler(this.btn_switchToVisualizer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 88);
            this.Controls.Add(this.btn_switchToVisualizer);
            this.Controls.Add(this.cb_IowSelector);
            this.Controls.Add(this.lbl_HandleOfIow);
            this.Controls.Add(this.lbl_DeviceId);
            this.Controls.Add(this.btn_requestIowStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "IOW Detektive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_requestIowStatus;
        private System.Windows.Forms.Label lbl_DeviceId;
        private System.Windows.Forms.Label lbl_HandleOfIow;
        private System.Windows.Forms.ComboBox cb_IowSelector;
        private System.Windows.Forms.Button btn_switchToVisualizer;
    }
}

