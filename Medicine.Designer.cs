namespace Pharmacy2
{
    partial class Medicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Medicine));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel3 = new Panel();
            MedNameCb = new ComboBox();
            EditBtn = new Button();
            SaveBtn = new Button();
            DelBtn = new Button();
            ManuCb = new ComboBox();
            ManNameTb = new TextBox();
            MedPriceTb = new TextBox();
            MedQtyTb = new TextBox();
            label15 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            MedTypeCb = new ComboBox();
            label14 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            label9 = new Label();
            pictureBox7 = new PictureBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label16 = new Label();
            MedStockDGV = new DataGridView();
            button1 = new Button();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MedStockDGV).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(MedNameCb);
            panel3.Controls.Add(EditBtn);
            panel3.Controls.Add(SaveBtn);
            panel3.Controls.Add(DelBtn);
            panel3.Controls.Add(ManuCb);
            panel3.Controls.Add(ManNameTb);
            panel3.Controls.Add(MedPriceTb);
            panel3.Controls.Add(MedQtyTb);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(MedTypeCb);
            panel3.Controls.Add(label14);
            panel3.Location = new Point(171, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1171, 154);
            panel3.TabIndex = 26;
            panel3.Paint += panel3_Paint;
            // 
            // MedNameCb
            // 
            MedNameCb.AllowDrop = true;
            MedNameCb.AutoCompleteMode = AutoCompleteMode.Suggest;
            MedNameCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            MedNameCb.Font = new Font("Constantia", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            MedNameCb.FormattingEnabled = true;
            MedNameCb.Items.AddRange(new object[] { "Anti Malaria", "Antibiotics", "Condoms", "Others", "Pain Killers" });
            MedNameCb.Location = new Point(13, 51);
            MedNameCb.MaxLength = 30;
            MedNameCb.Name = "MedNameCb";
            MedNameCb.Size = new Size(327, 31);
            MedNameCb.Sorted = true;
            MedNameCb.TabIndex = 59;
            MedNameCb.SelectedValueChanged += MedNameCb_SelectedValueChanged;
            MedNameCb.TextChanged += MedNameCb_TextChanged;
            // 
            // EditBtn
            // 
            EditBtn.BackColor = Color.MediumTurquoise;
            EditBtn.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point);
            EditBtn.ForeColor = Color.White;
            EditBtn.Location = new Point(507, 102);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(155, 33);
            EditBtn.TabIndex = 47;
            EditBtn.Text = "Edit";
            EditBtn.UseVisualStyleBackColor = false;
            EditBtn.Click += EditBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.MediumTurquoise;
            SaveBtn.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(322, 102);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(155, 33);
            SaveBtn.TabIndex = 46;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // DelBtn
            // 
            DelBtn.BackColor = Color.MediumTurquoise;
            DelBtn.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DelBtn.ForeColor = Color.White;
            DelBtn.Location = new Point(689, 102);
            DelBtn.Name = "DelBtn";
            DelBtn.Size = new Size(155, 33);
            DelBtn.TabIndex = 45;
            DelBtn.Text = "Delete";
            DelBtn.UseVisualStyleBackColor = false;
            DelBtn.Click += DelBtn_Click;
            // 
            // ManuCb
            // 
            ManuCb.AutoCompleteMode = AutoCompleteMode.Append;
            ManuCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            ManuCb.Font = new Font("Constantia", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ManuCb.FormattingEnabled = true;
            ManuCb.Location = new Point(734, 52);
            ManuCb.Name = "ManuCb";
            ManuCb.Size = new Size(306, 31);
            ManuCb.TabIndex = 40;
            ManuCb.SelectionChangeCommitted += ManuCb_SelectionChangeCommitted;
            ManuCb.SelectedValueChanged += ManuCb_SelectedValueChanged;
            // 
            // ManNameTb
            // 
            ManNameTb.Enabled = false;
            ManNameTb.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ManNameTb.Location = new Point(1046, 52);
            ManNameTb.Name = "ManNameTb";
            ManNameTb.Size = new Size(118, 30);
            ManNameTb.TabIndex = 39;
            // 
            // MedPriceTb
            // 
            MedPriceTb.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point);
            MedPriceTb.Location = new Point(627, 51);
            MedPriceTb.Name = "MedPriceTb";
            MedPriceTb.Size = new Size(102, 30);
            MedPriceTb.TabIndex = 38;
            MedPriceTb.KeyPress += MedPriceTb_KeyPress;
            // 
            // MedQtyTb
            // 
            MedQtyTb.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point);
            MedQtyTb.Location = new Point(519, 52);
            MedQtyTb.Name = "MedQtyTb";
            MedQtyTb.Size = new Size(102, 30);
            MedQtyTb.TabIndex = 37;
            MedQtyTb.TextChanged += MedQtyTb_TextChanged;
            MedQtyTb.KeyPress += MedQtyTb_KeyPress;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label15.ForeColor = Color.Teal;
            label15.Location = new Point(1046, 15);
            label15.Name = "label15";
            label15.Size = new Size(107, 28);
            label15.TabIndex = 36;
            label15.Text = "Manu. ID";
            label15.Click += label15_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.Teal;
            label13.Location = new Point(734, 15);
            label13.Name = "label13";
            label13.Size = new Size(242, 28);
            label13.TabIndex = 35;
            label13.Text = "Manufacturer/Supplier";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.Teal;
            label12.Location = new Point(644, 15);
            label12.Name = "label12";
            label12.Size = new Size(63, 28);
            label12.TabIndex = 34;
            label12.Text = "Price";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.Teal;
            label11.Location = new Point(525, 15);
            label11.Name = "label11";
            label11.Size = new Size(102, 28);
            label11.TabIndex = 33;
            label11.Text = "Quantity";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Teal;
            label10.Location = new Point(346, 15);
            label10.Name = "label10";
            label10.Size = new Size(158, 28);
            label10.TabIndex = 32;
            label10.Text = "Medicine Type";
            // 
            // MedTypeCb
            // 
            MedTypeCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MedTypeCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            MedTypeCb.Font = new Font("Constantia", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            MedTypeCb.FormattingEnabled = true;
            MedTypeCb.Items.AddRange(new object[] { "Buccal Tablet/Liquid", "Capsules", "Condoms", "Drops", "Implants/Patches", "Inhaler", "Injection", "Liquid", "Others", "Suppository", "Tablet", "Topical" });
            MedTypeCb.Location = new Point(346, 51);
            MedTypeCb.Name = "MedTypeCb";
            MedTypeCb.Size = new Size(167, 31);
            MedTypeCb.Sorted = true;
            MedTypeCb.TabIndex = 30;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Constantia", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.Teal;
            label14.Location = new Point(13, 15);
            label14.Name = "label14";
            label14.Size = new Size(170, 28);
            label14.TabIndex = 25;
            label14.Text = "Medicine Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Constantia", 27F, FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(647, 54);
            label2.Name = "label2";
            label2.Size = new Size(213, 44);
            label2.TabIndex = 24;
            label2.Text = "MEDICINES";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Constantia", 27F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(494, 0);
            label1.Name = "label1";
            label1.Size = new Size(503, 44);
            label1.TabIndex = 23;
            label1.Text = "Pharmacy Management System";
            // 
            // label3
            // 
            label3.BackColor = Color.PaleTurquoise;
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(165, 680);
            label3.Name = "label3";
            label3.Size = new Size(1189, 30);
            label3.TabIndex = 22;
            label3.Text = "Copyright @ 2023 Black Matata Studio";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(165, 710);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.BackColor = Color.PaleTurquoise;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox3);
            panel2.Location = new Point(3, 166);
            panel2.Name = "panel2";
            panel2.Size = new Size(173, 55);
            panel2.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PaleTurquoise;
            label4.Font = new Font("Constantia", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(48, 17);
            label4.Name = "label4";
            label4.Size = new Size(100, 24);
            label4.TabIndex = 10;
            label4.Text = "Medicines";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 39);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Cursor = Cursors.Hand;
            label9.Font = new Font("Constantia", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(59, 665);
            label9.Name = "label9";
            label9.Size = new Size(71, 24);
            label9.TabIndex = 14;
            label9.Text = "Logout";
            label9.Click += label9_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(3, 399);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(42, 39);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 13;
            pictureBox7.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Cursor = Cursors.Hand;
            label8.Font = new Font("Constantia", 15F, FontStyle.Underline, GraphicsUnit.Point);
            label8.Location = new Point(51, 406);
            label8.Name = "label8";
            label8.Size = new Size(70, 24);
            label8.TabIndex = 12;
            label8.Text = "Selling";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Cursor = Cursors.Hand;
            label7.Font = new Font("Constantia", 15F, FontStyle.Underline, GraphicsUnit.Point);
            label7.Location = new Point(51, 349);
            label7.Name = "label7";
            label7.Size = new Size(68, 24);
            label7.TabIndex = 11;
            label7.Text = "Sellers";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("Constantia", 15F, FontStyle.Underline, GraphicsUnit.Point);
            label6.Location = new Point(51, 293);
            label6.Name = "label6";
            label6.Size = new Size(103, 24);
            label6.TabIndex = 10;
            label6.Text = "Customers";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Cursor = Cursors.Hand;
            label5.Font = new Font("Constantia", 12F, FontStyle.Underline, GraphicsUnit.Point);
            label5.Location = new Point(51, 238);
            label5.Name = "label5";
            label5.Size = new Size(110, 19);
            label5.TabIndex = 9;
            label5.Text = "Manufacturers";
            label5.Click += label5_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(3, 343);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(42, 39);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 5;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(3, 286);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(42, 39);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(3, 228);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 39);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(11, 658);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-36, -31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(239, 220);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Constantia", 23F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(639, 271);
            label16.Name = "label16";
            label16.Size = new Size(224, 38);
            label16.TabIndex = 28;
            label16.Text = "Medicine Stock";
            // 
            // MedStockDGV
            // 
            MedStockDGV.AllowUserToAddRows = false;
            MedStockDGV.AllowUserToResizeColumns = false;
            MedStockDGV.AllowUserToResizeRows = false;
            MedStockDGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MedStockDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MedStockDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MedStockDGV.BackgroundColor = Color.White;
            MedStockDGV.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Teal;
            dataGridViewCellStyle1.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.PaleTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = Color.Teal;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            MedStockDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            MedStockDGV.ColumnHeadersHeight = 30;
            MedStockDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            MedStockDGV.EnableHeadersVisualStyles = false;
            MedStockDGV.GridColor = Color.Teal;
            MedStockDGV.Location = new Point(171, 312);
            MedStockDGV.Name = "MedStockDGV";
            MedStockDGV.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Teal;
            dataGridViewCellStyle2.SelectionBackColor = Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = Color.Teal;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            MedStockDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            MedStockDGV.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Teal;
            dataGridViewCellStyle3.SelectionBackColor = Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = Color.Teal;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            MedStockDGV.RowsDefaultCellStyle = dataGridViewCellStyle3;
            MedStockDGV.RowTemplate.Height = 25;
            MedStockDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MedStockDGV.Size = new Size(1171, 379);
            MedStockDGV.TabIndex = 36;
            MedStockDGV.CellFormatting += MedStockDGV_CellFormatting;
            MedStockDGV.CellMouseClick += MedStockDGV_CellMouseClick;
            // 
            // button1
            // 
            button1.BackColor = Color.Gainsboro;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.ForeColor = Color.Teal;
            button1.Location = new Point(1313, 0);
            button1.Name = "button1";
            button1.Size = new Size(41, 33);
            button1.TabIndex = 58;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Medicine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1354, 710);
            Controls.Add(button1);
            Controls.Add(MedStockDGV);
            Controls.Add(label16);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Medicine";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Medicine";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)MedStockDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private ComboBox MedTypeCb;
        private Label label14;
        private Label label2;
        private Label label1;
        private Label label3;
        private Panel panel1;
        private Label label9;
        private PictureBox pictureBox7;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label10;
        private Label label15;
        private Label label13;
        private Label label12;
        private Label label11;
        private ComboBox ManuCb;
        private TextBox ManNameTb;
        private TextBox MedPriceTb;
        private TextBox MedQtyTb;
        private Label label16;
        private Panel panel2;
        private Label label4;
        private PictureBox pictureBox3;
        private Button EditBtn;
        private Button SaveBtn;
        private Button DelBtn;
        private DataGridView MedStockDGV;
        private ComboBox MedNameCb;
        private Button button1;
    }
}