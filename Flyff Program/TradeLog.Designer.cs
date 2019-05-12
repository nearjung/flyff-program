namespace Flyff_Program
{
    partial class TradeLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TradeIDView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TradeDetailView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeIDView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeDetailView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(-4, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(934, 65);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Label 2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TradeIDView);
            this.groupBox1.Location = new System.Drawing.Point(13, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 368);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trade ID";
            // 
            // TradeIDView
            // 
            this.TradeIDView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TradeIDView.Location = new System.Drawing.Point(6, 19);
            this.TradeIDView.Name = "TradeIDView";
            this.TradeIDView.Size = new System.Drawing.Size(257, 343);
            this.TradeIDView.TabIndex = 0;
            this.TradeIDView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TradeIDView_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TradeDetailView);
            this.groupBox3.Location = new System.Drawing.Point(288, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 323);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trade Detail";
            // 
            // TradeDetailView
            // 
            this.TradeDetailView.AllowUserToAddRows = false;
            this.TradeDetailView.AllowUserToDeleteRows = false;
            this.TradeDetailView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TradeDetailView.Location = new System.Drawing.Point(6, 19);
            this.TradeDetailView.Name = "TradeDetailView";
            this.TradeDetailView.Size = new System.Drawing.Size(597, 298);
            this.TradeDetailView.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Maroon;
            this.label3.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(262, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(609, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TradeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TradeLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TradeLog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TradeLog_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TradeIDView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TradeDetailView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView TradeIDView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView TradeDetailView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}