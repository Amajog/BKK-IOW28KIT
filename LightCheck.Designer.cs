
namespace IOW28KIT
{
    partial class LightCheck
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightCheck));
            this.cb_LED_P04 = new System.Windows.Forms.CheckBox();
            this.pnl_LED_P04 = new System.Windows.Forms.Panel();
            this.pnl_LED_P05 = new System.Windows.Forms.Panel();
            this.cb_LED_P05 = new System.Windows.Forms.CheckBox();
            this.pnl_LED_P06 = new System.Windows.Forms.Panel();
            this.cb_LED_P06 = new System.Windows.Forms.CheckBox();
            this.pnl_LED_P07 = new System.Windows.Forms.Panel();
            this.cb_LED_P07 = new System.Windows.Forms.CheckBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.lbl_Data1 = new System.Windows.Forms.Label();
            this.tmr_LightShow = new System.Windows.Forms.Timer(this.components);
            this.tt_explains = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cb_LED_P04
            // 
            this.cb_LED_P04.AutoSize = true;
            this.cb_LED_P04.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cb_LED_P04.Location = new System.Drawing.Point(18, 17);
            this.cb_LED_P04.Margin = new System.Windows.Forms.Padding(4);
            this.cb_LED_P04.Name = "cb_LED_P04";
            this.cb_LED_P04.Size = new System.Drawing.Size(153, 22);
            this.cb_LED_P04.TabIndex = 0;
            this.cb_LED_P04.Text = "LED top-left  (P0.4)";
            this.cb_LED_P04.UseVisualStyleBackColor = true;
            this.cb_LED_P04.CheckedChanged += new System.EventHandler(this.cb_LED_P04_CheckedChanged);
            // 
            // pnl_LED_P04
            // 
            this.pnl_LED_P04.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnl_LED_P04.Location = new System.Drawing.Point(18, 55);
            this.pnl_LED_P04.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_LED_P04.Name = "pnl_LED_P04";
            this.pnl_LED_P04.Size = new System.Drawing.Size(262, 138);
            this.pnl_LED_P04.TabIndex = 1;
            // 
            // pnl_LED_P05
            // 
            this.pnl_LED_P05.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnl_LED_P05.Location = new System.Drawing.Point(374, 55);
            this.pnl_LED_P05.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_LED_P05.Name = "pnl_LED_P05";
            this.pnl_LED_P05.Size = new System.Drawing.Size(262, 138);
            this.pnl_LED_P05.TabIndex = 3;
            // 
            // cb_LED_P05
            // 
            this.cb_LED_P05.AutoSize = true;
            this.cb_LED_P05.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cb_LED_P05.Location = new System.Drawing.Point(374, 17);
            this.cb_LED_P05.Margin = new System.Windows.Forms.Padding(4);
            this.cb_LED_P05.Name = "cb_LED_P05";
            this.cb_LED_P05.Size = new System.Drawing.Size(162, 22);
            this.cb_LED_P05.TabIndex = 2;
            this.cb_LED_P05.Text = "LED top-right  (P0.5)";
            this.cb_LED_P05.UseVisualStyleBackColor = true;
            this.cb_LED_P05.CheckedChanged += new System.EventHandler(this.cb_LED_P05_CheckedChanged);
            // 
            // pnl_LED_P06
            // 
            this.pnl_LED_P06.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnl_LED_P06.Location = new System.Drawing.Point(18, 280);
            this.pnl_LED_P06.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_LED_P06.Name = "pnl_LED_P06";
            this.pnl_LED_P06.Size = new System.Drawing.Size(262, 138);
            this.pnl_LED_P06.TabIndex = 6;
            // 
            // cb_LED_P06
            // 
            this.cb_LED_P06.AutoSize = true;
            this.cb_LED_P06.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cb_LED_P06.Location = new System.Drawing.Point(18, 241);
            this.cb_LED_P06.Margin = new System.Windows.Forms.Padding(4);
            this.cb_LED_P06.Name = "cb_LED_P06";
            this.cb_LED_P06.Size = new System.Drawing.Size(179, 22);
            this.cb_LED_P06.TabIndex = 5;
            this.cb_LED_P06.Text = "LED bottom-left  (P0.6)";
            this.cb_LED_P06.UseVisualStyleBackColor = true;
            this.cb_LED_P06.CheckedChanged += new System.EventHandler(this.cb_LED_P06_CheckedChanged);
            // 
            // pnl_LED_P07
            // 
            this.pnl_LED_P07.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnl_LED_P07.Location = new System.Drawing.Point(374, 280);
            this.pnl_LED_P07.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_LED_P07.Name = "pnl_LED_P07";
            this.pnl_LED_P07.Size = new System.Drawing.Size(262, 138);
            this.pnl_LED_P07.TabIndex = 8;
            // 
            // cb_LED_P07
            // 
            this.cb_LED_P07.AutoSize = true;
            this.cb_LED_P07.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cb_LED_P07.Location = new System.Drawing.Point(374, 241);
            this.cb_LED_P07.Margin = new System.Windows.Forms.Padding(4);
            this.cb_LED_P07.Name = "cb_LED_P07";
            this.cb_LED_P07.Size = new System.Drawing.Size(188, 22);
            this.cb_LED_P07.TabIndex = 7;
            this.cb_LED_P07.Text = "LED bottom-right  (P0.7)";
            this.cb_LED_P07.UseVisualStyleBackColor = true;
            this.cb_LED_P07.CheckedChanged += new System.EventHandler(this.cb_LED_P07_CheckedChanged);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Stop.Location = new System.Drawing.Point(374, 471);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(262, 87);
            this.btn_Stop.TabIndex = 9;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_click);
            // 
            // btn_Run
            // 
            this.btn_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Run.Location = new System.Drawing.Point(18, 471);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(262, 87);
            this.btn_Run.TabIndex = 11;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            this.btn_Run.MouseHover += new System.EventHandler(this.btn_Run_MouseHover);
            // 
            // lbl_Data1
            // 
            this.lbl_Data1.AutoSize = true;
            this.lbl_Data1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbl_Data1.Location = new System.Drawing.Point(14, 422);
            this.lbl_Data1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Data1.Name = "lbl_Data1";
            this.lbl_Data1.Size = new System.Drawing.Size(59, 18);
            this.lbl_Data1.TabIndex = 12;
            this.lbl_Data1.Text = "Data[1]:";
            // 
            // tmr_LightShow
            // 
            this.tmr_LightShow.Interval = 1000;
            this.tmr_LightShow.Tick += new System.EventHandler(this.tmr_LightShow_Tick);
            // 
            // LightCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 575);
            this.Controls.Add(this.lbl_Data1);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.pnl_LED_P07);
            this.Controls.Add(this.cb_LED_P07);
            this.Controls.Add(this.pnl_LED_P06);
            this.Controls.Add(this.cb_LED_P06);
            this.Controls.Add(this.pnl_LED_P05);
            this.Controls.Add(this.cb_LED_P05);
            this.Controls.Add(this.pnl_LED_P04);
            this.Controls.Add(this.cb_LED_P04);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LightCheck";
            this.Text = "LightCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_LED_P04;
        private System.Windows.Forms.Panel pnl_LED_P04;
        private System.Windows.Forms.Panel pnl_LED_P05;
        private System.Windows.Forms.CheckBox cb_LED_P05;
        private System.Windows.Forms.Panel pnl_LED_P06;
        private System.Windows.Forms.CheckBox cb_LED_P06;
        private System.Windows.Forms.Panel pnl_LED_P07;
        private System.Windows.Forms.CheckBox cb_LED_P07;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Label lbl_Data1;
        private System.Windows.Forms.Timer tmr_LightShow;
        private System.Windows.Forms.ToolTip tt_explains;
    }
}