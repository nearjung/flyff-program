namespace Flyff_Program
{
    partial class EditCharacter
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
            this.NULL_01 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Search_Box = new System.Windows.Forms.GroupBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.searchbox_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Search_Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // NULL_01
            // 
            this.NULL_01.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.NULL_01.Dock = System.Windows.Forms.DockStyle.Top;
            this.NULL_01.Font = new System.Drawing.Font("Kristen ITC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NULL_01.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NULL_01.Location = new System.Drawing.Point(0, 0);
            this.NULL_01.Name = "NULL_01";
            this.NULL_01.Size = new System.Drawing.Size(924, 68);
            this.NULL_01.TabIndex = 0;
            this.NULL_01.Text = "EDIT CHARACTER";
            this.NULL_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(921, 345);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Search_Box
            // 
            this.Search_Box.Controls.Add(this.search_btn);
            this.Search_Box.Controls.Add(this.searchbox_txt);
            this.Search_Box.Location = new System.Drawing.Point(13, 420);
            this.Search_Box.Name = "Search_Box";
            this.Search_Box.Size = new System.Drawing.Size(321, 61);
            this.Search_Box.TabIndex = 2;
            this.Search_Box.TabStop = false;
            this.Search_Box.Text = "Search Character";
            // 
            // search_btn
            // 
            this.search_btn.Location = new System.Drawing.Point(192, 21);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(109, 23);
            this.search_btn.TabIndex = 2;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // searchbox_txt
            // 
            this.searchbox_txt.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchbox_txt.Location = new System.Drawing.Point(19, 23);
            this.searchbox_txt.Name = "searchbox_txt";
            this.searchbox_txt.Size = new System.Drawing.Size(167, 20);
            this.searchbox_txt.TabIndex = 1;
            this.searchbox_txt.Text = "Character Name / Account name";
            this.searchbox_txt.Enter += new System.EventHandler(this.searchbox_txt_Enter);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Ravie", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(446, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Ravie", 14.25F);
            this.button2.Location = new System.Drawing.Point(591, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "DELETE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Ravie", 14.25F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(729, 425);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 51);
            this.button3.TabIndex = 5;
            this.button3.Text = "EXIST";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // EditCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 493);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Search_Box);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.NULL_01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditCharacter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditCharacter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditCharacter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Search_Box.ResumeLayout(false);
            this.Search_Box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NULL_01;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox Search_Box;
        private System.Windows.Forms.TextBox searchbox_txt;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}