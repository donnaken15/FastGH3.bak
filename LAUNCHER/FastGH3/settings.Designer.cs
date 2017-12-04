namespace FastGH3
{
    partial class settings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            this.ok = new System.Windows.Forms.Button();
            this.reslabel = new System.Windows.Forms.Label();
            this.res = new System.Windows.Forms.ComboBox();
            this.hypers = new System.Windows.Forms.NumericUpDown();
            this.hyperlabel = new System.Windows.Forms.Label();
            this.diff = new System.Windows.Forms.ComboBox();
            this.difflabel = new System.Windows.Forms.Label();
            this.importonly = new System.Windows.Forms.CheckBox();
            this.creditlink = new System.Windows.Forms.LinkLabel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.scrshmode = new System.Windows.Forms.CheckBox();
            this.nostatsonend = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hypers)).BeginInit();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(202, 183);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(29, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "Ok";
            this.tooltip.SetToolTip(this.ok, "Exit dialog.");
            this.ok.UseVisualStyleBackColor = true;
            // 
            // reslabel
            // 
            this.reslabel.AutoSize = true;
            this.reslabel.Location = new System.Drawing.Point(1, 6);
            this.reslabel.Name = "reslabel";
            this.reslabel.Size = new System.Drawing.Size(57, 13);
            this.reslabel.TabIndex = 1;
            this.reslabel.Text = "Resolution";
            // 
            // res
            // 
            this.res.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.res.FormattingEnabled = true;
            this.res.Items.AddRange(new object[] {
            "800x600",
            "1024x768",
            "1152x864",
            "1280x720",
            "1280x768",
            "1280x800",
            "1280x960",
            "1280x1024",
            "1360x768",
            "1366x768",
            "1440x900",
            "1600x900",
            "1600x1024",
            "1680x1050",
            "1768x992",
            "1920x1080"});
            this.res.Location = new System.Drawing.Point(59, 3);
            this.res.Name = "res";
            this.res.Size = new System.Drawing.Size(84, 21);
            this.res.TabIndex = 2;
            this.tooltip.SetToolTip(this.res, resources.GetString("res.ToolTip"));
            this.res.SelectedIndexChanged += new System.EventHandler(this.res_SelectedIndexChanged);
            // 
            // hypers
            // 
            this.hypers.Location = new System.Drawing.Point(111, 28);
            this.hypers.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.hypers.Name = "hypers";
            this.hypers.Size = new System.Drawing.Size(32, 20);
            this.hypers.TabIndex = 3;
            this.tooltip.SetToolTip(this.hypers, "Useful if you don\'t want to goto cheats\r\neverytime to change the hyperspeed.");
            // 
            // hyperlabel
            // 
            this.hyperlabel.AutoSize = true;
            this.hyperlabel.Location = new System.Drawing.Point(1, 30);
            this.hyperlabel.Name = "hyperlabel";
            this.hyperlabel.Size = new System.Drawing.Size(104, 13);
            this.hyperlabel.TabIndex = 4;
            this.hyperlabel.Text = "Default Hyperspeed:";
            // 
            // diff
            // 
            this.diff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diff.FormattingEnabled = true;
            this.diff.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard",
            "Expert"});
            this.diff.Location = new System.Drawing.Point(84, 53);
            this.diff.Name = "diff";
            this.diff.Size = new System.Drawing.Size(59, 21);
            this.diff.TabIndex = 5;
            this.tooltip.SetToolTip(this.diff, "Useful if you don\'t want to goto options\r\nand select a different difficulty every" +
        "time.");
            this.diff.SelectedIndexChanged += new System.EventHandler(this.diff_SelectedIndexChanged);
            // 
            // difflabel
            // 
            this.difflabel.AutoSize = true;
            this.difflabel.Location = new System.Drawing.Point(1, 56);
            this.difflabel.Name = "difflabel";
            this.difflabel.Size = new System.Drawing.Size(84, 13);
            this.difflabel.TabIndex = 6;
            this.difflabel.Text = "Default Difficulty";
            // 
            // importonly
            // 
            this.importonly.AutoSize = true;
            this.importonly.Location = new System.Drawing.Point(4, 78);
            this.importonly.Name = "importonly";
            this.importonly.Size = new System.Drawing.Size(103, 17);
            this.importonly.TabIndex = 7;
            this.importonly.Text = "Import song only";
            this.tooltip.SetToolTip(this.importonly, "This will make it so that the launcher only\r\nimports the song rather than startin" +
        "g up the\r\ngame after import is successful.");
            this.importonly.UseVisualStyleBackColor = true;
            // 
            // creditlink
            // 
            this.creditlink.ActiveLinkColor = System.Drawing.Color.Black;
            this.creditlink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.creditlink.AutoSize = true;
            this.creditlink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.creditlink.LinkColor = System.Drawing.Color.Black;
            this.creditlink.Location = new System.Drawing.Point(12, 188);
            this.creditlink.Name = "creditlink";
            this.creditlink.Size = new System.Drawing.Size(39, 13);
            this.creditlink.TabIndex = 8;
            this.creditlink.TabStop = true;
            this.creditlink.Text = "Credits";
            this.tooltip.SetToolTip(this.creditlink, "Credits will be displayed in console.");
            this.creditlink.VisitedLinkColor = System.Drawing.Color.White;
            this.creditlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.creditlink_LinkClicked);
            // 
            // tooltip
            // 
            this.tooltip.AutomaticDelay = 0;
            this.tooltip.AutoPopDelay = 0;
            this.tooltip.InitialDelay = 10;
            this.tooltip.IsBalloon = true;
            this.tooltip.ReshowDelay = 0;
            this.tooltip.ShowAlways = true;
            this.tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tooltip.ToolTipTitle = "About this setting";
            this.tooltip.UseAnimation = false;
            this.tooltip.UseFading = false;
            // 
            // scrshmode
            // 
            this.scrshmode.AutoSize = true;
            this.scrshmode.Location = new System.Drawing.Point(4, 102);
            this.scrshmode.Name = "scrshmode";
            this.scrshmode.Size = new System.Drawing.Size(109, 17);
            this.scrshmode.TabIndex = 9;
            this.scrshmode.Text = "Screenshot mode";
            this.tooltip.SetToolTip(this.scrshmode, "Enables screenshot mode. This feature was put into the original \r\nGH3 by default." +
        " When you pause it, it will not show the pause\r\nmenu. Instead, it will completel" +
        "y pause the game.");
            this.scrshmode.UseVisualStyleBackColor = true;
            // 
            // nostatsonend
            // 
            this.nostatsonend.AutoSize = true;
            this.nostatsonend.Location = new System.Drawing.Point(4, 126);
            this.nostatsonend.Name = "nostatsonend";
            this.nostatsonend.Size = new System.Drawing.Size(101, 17);
            this.nostatsonend.TabIndex = 10;
            this.nostatsonend.Text = "No stats on end";
            this.tooltip.SetToolTip(this.nostatsonend, "Won\'t display score after song is over.\r\nIt will instead close out the game.");
            this.nostatsonend.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 218);
            this.Controls.Add(this.nostatsonend);
            this.Controls.Add(this.scrshmode);
            this.Controls.Add(this.creditlink);
            this.Controls.Add(this.importonly);
            this.Controls.Add(this.diff);
            this.Controls.Add(this.difflabel);
            this.Controls.Add(this.hyperlabel);
            this.Controls.Add(this.hypers);
            this.Controls.Add(this.res);
            this.Controls.Add(this.reslabel);
            this.Controls.Add(this.ok);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " FastGH3 settings";
            ((System.ComponentModel.ISupportInitialize)(this.hypers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label reslabel;
        private System.Windows.Forms.ComboBox res;
        private System.Windows.Forms.NumericUpDown hypers;
        private System.Windows.Forms.Label hyperlabel;
        private System.Windows.Forms.ComboBox diff;
        private System.Windows.Forms.Label difflabel;
        private System.Windows.Forms.CheckBox importonly;
        private System.Windows.Forms.LinkLabel creditlink;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.CheckBox scrshmode;
        private System.Windows.Forms.CheckBox nostatsonend;
    }
}