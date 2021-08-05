namespace ms2
{
    partial class MainForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bill1 = new ms2.bill();
            this.stock1 = new ms2.Stock();
            this.supplier1 = new ms2.Supplier();
            this.customer21 = new ms2.customer2();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 76);
            this.label1.TabIndex = 16;
            this.label1.Text = "WELCOME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(1198, 680);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "MEDICAL STORE";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Green;
            this.panel4.BackgroundImage = global::ms2.Properties.Resources.medical_icon1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(1212, 609);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(85, 68);
            this.panel4.TabIndex = 56;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ms2.Properties.Resources.images__12_1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1085, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 35);
            this.button1.TabIndex = 61;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 105);
            this.panel1.TabIndex = 62;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(544, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 29);
            this.button5.TabIndex = 66;
            this.button5.Text = "BILL";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(370, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 29);
            this.button4.TabIndex = 65;
            this.button4.Text = "STOCK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(197, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 29);
            this.button3.TabIndex = 64;
            this.button3.Text = "SUPPLIER";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(28, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 29);
            this.button2.TabIndex = 63;
            this.button2.Text = "CUSTOMER";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bill1
            // 
            this.bill1.BackColor = System.Drawing.Color.Honeydew;
            this.bill1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bill1.BackgroundImage")));
            this.bill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bill1.Location = new System.Drawing.Point(211, 111);
            this.bill1.Name = "bill1";
            this.bill1.Size = new System.Drawing.Size(924, 566);
            this.bill1.TabIndex = 66;
            this.bill1.Load += new System.EventHandler(this.bill1_Load);
            // 
            // stock1
            // 
            this.stock1.BackColor = System.Drawing.Color.White;
            this.stock1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stock1.BackgroundImage")));
            this.stock1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stock1.Location = new System.Drawing.Point(416, 111);
            this.stock1.Name = "stock1";
            this.stock1.Size = new System.Drawing.Size(483, 566);
            this.stock1.TabIndex = 65;
            // 
            // supplier1
            // 
            this.supplier1.BackColor = System.Drawing.Color.White;
            this.supplier1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("supplier1.BackgroundImage")));
            this.supplier1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.supplier1.Location = new System.Drawing.Point(416, 111);
            this.supplier1.Name = "supplier1";
            this.supplier1.Size = new System.Drawing.Size(483, 566);
            this.supplier1.TabIndex = 64;
            // 
            // customer21
            // 
            this.customer21.BackColor = System.Drawing.Color.White;
            this.customer21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customer21.BackgroundImage")));
            this.customer21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customer21.Location = new System.Drawing.Point(416, 111);
            this.customer21.Name = "customer21";
            this.customer21.Size = new System.Drawing.Size(483, 566);
            this.customer21.TabIndex = 63;
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImage = global::ms2.Properties.Resources.Free_HD_Light_Blue_Wallpaper_Images1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.bill1);
            this.Controls.Add(this.stock1);
            this.Controls.Add(this.supplier1);
            this.Controls.Add(this.customer21);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Name = "MainForm2";
            this.Text = "MainForm2";
            this.Load += new System.EventHandler(this.MainForm2_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private customer2 customer21;
        private Supplier supplier1;
        private Stock stock1;
        private bill bill1;
    }
}