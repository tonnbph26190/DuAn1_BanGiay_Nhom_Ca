namespace _3.PL
{
    partial class Frm_ChiTietSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ChiTietSanPham));
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgrid_sanpham = new System.Windows.Forms.DataGridView();
            this.Fl_SanPham = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Ma = new System.Windows.Forms.TextBox();
            this.cmb_SanPham = new System.Windows.Forms.ComboBox();
            this.richtxt_mota = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_giaban = new System.Windows.Forms.TextBox();
            this.txt_gianhap = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_ThemSanPham = new System.Windows.Forms.Button();
            this.btn_ThenNsx = new System.Windows.Forms.Button();
            this.btn_ThemChatLieu = new System.Windows.Forms.Button();
            this.btn_ThemSize = new System.Windows.Forms.Button();
            this.btn_ThemMauSac = new System.Windows.Forms.Button();
            this.btn_ThemDSP = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.pic_QR = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pic_SanPham = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtn_KhongHoatDong = new System.Windows.Forms.RadioButton();
            this.rbtn_HoatDong = new System.Windows.Forms.RadioButton();
            this.cmb_NSX = new System.Windows.Forms.ComboBox();
            this.cmb_ChatLieu = new System.Windows.Forms.ComboBox();
            this.Cmb_MauSac = new System.Windows.Forms.ComboBox();
            this.cmb_Size = new System.Windows.Forms.ComboBox();
            this.cmb_DongSp = new System.Windows.Forms.ComboBox();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bnt_Them = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_CLear = new System.Windows.Forms.Button();
            this.bnt_Sua = new System.Windows.Forms.Button();
            this.btn_ThemList = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_sanpham)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_QR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_SanPham)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(679, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 15);
            this.label12.TabIndex = 159;
            this.label12.Text = "Tìm kiếm:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(744, 9);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(319, 23);
            this.textBox1.TabIndex = 160;
            // 
            // dgrid_sanpham
            // 
            this.dgrid_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_sanpham.Location = new System.Drawing.Point(678, 38);
            this.dgrid_sanpham.Name = "dgrid_sanpham";
            this.dgrid_sanpham.RowTemplate.Height = 25;
            this.dgrid_sanpham.Size = new System.Drawing.Size(578, 560);
            this.dgrid_sanpham.TabIndex = 158;
            this.dgrid_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_sanpham_CellClick);
            // 
            // Fl_SanPham
            // 
            this.Fl_SanPham.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Fl_SanPham.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Fl_SanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fl_SanPham.Location = new System.Drawing.Point(3, 19);
            this.Fl_SanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fl_SanPham.Name = "Fl_SanPham";
            this.Fl_SanPham.Size = new System.Drawing.Size(93, 567);
            this.Fl_SanPham.TabIndex = 151;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Ma);
            this.groupBox1.Controls.Add(this.cmb_SanPham);
            this.groupBox1.Controls.Add(this.richtxt_mota);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txt_giaban);
            this.groupBox1.Controls.Add(this.txt_gianhap);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btn_ThemSanPham);
            this.groupBox1.Controls.Add(this.btn_ThenNsx);
            this.groupBox1.Controls.Add(this.btn_ThemChatLieu);
            this.groupBox1.Controls.Add(this.btn_ThemSize);
            this.groupBox1.Controls.Add(this.btn_ThemMauSac);
            this.groupBox1.Controls.Add(this.btn_ThemDSP);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.pic_QR);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pic_SanPham);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.rbtn_KhongHoatDong);
            this.groupBox1.Controls.Add(this.rbtn_HoatDong);
            this.groupBox1.Controls.Add(this.cmb_NSX);
            this.groupBox1.Controls.Add(this.cmb_ChatLieu);
            this.groupBox1.Controls.Add(this.Cmb_MauSac);
            this.groupBox1.Controls.Add(this.cmb_Size);
            this.groupBox1.Controls.Add(this.cmb_DongSp);
            this.groupBox1.Controls.Add(this.txt_SoLuong);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(556, 546);
            this.groupBox1.TabIndex = 150;
            this.groupBox1.TabStop = false;
            // 
            // txt_Ma
            // 
            this.txt_Ma.Location = new System.Drawing.Point(158, 54);
            this.txt_Ma.Name = "txt_Ma";
            this.txt_Ma.Size = new System.Drawing.Size(157, 23);
            this.txt_Ma.TabIndex = 150;
            this.txt_Ma.TextChanged += new System.EventHandler(this.txt_Ma_TextChanged);
            // 
            // cmb_SanPham
            // 
            this.cmb_SanPham.FormattingEnabled = true;
            this.cmb_SanPham.Location = new System.Drawing.Point(158, 20);
            this.cmb_SanPham.Name = "cmb_SanPham";
            this.cmb_SanPham.Size = new System.Drawing.Size(121, 23);
            this.cmb_SanPham.TabIndex = 149;
            this.cmb_SanPham.SelectedIndexChanged += new System.EventHandler(this.cmb_SanPham_SelectedIndexChanged);
            // 
            // richtxt_mota
            // 
            this.richtxt_mota.Location = new System.Drawing.Point(160, 439);
            this.richtxt_mota.Name = "richtxt_mota";
            this.richtxt_mota.Size = new System.Drawing.Size(325, 96);
            this.richtxt_mota.TabIndex = 148;
            this.richtxt_mota.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 441);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 15);
            this.label16.TabIndex = 147;
            this.label16.Text = "Mô Tả";
            // 
            // txt_giaban
            // 
            this.txt_giaban.Location = new System.Drawing.Point(162, 343);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(155, 23);
            this.txt_giaban.TabIndex = 146;
            // 
            // txt_gianhap
            // 
            this.txt_gianhap.Location = new System.Drawing.Point(162, 298);
            this.txt_gianhap.Name = "txt_gianhap";
            this.txt_gianhap.Size = new System.Drawing.Size(156, 23);
            this.txt_gianhap.TabIndex = 145;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 350);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 144;
            this.label14.Text = "Giá Bán";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 305);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 15);
            this.label15.TabIndex = 143;
            this.label15.Text = "Giá Nhập";
            // 
            // btn_ThemSanPham
            // 
            this.btn_ThemSanPham.BackColor = System.Drawing.Color.Lime;
            this.btn_ThemSanPham.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemSanPham.Image")));
            this.btn_ThemSanPham.Location = new System.Drawing.Point(286, 21);
            this.btn_ThemSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ThemSanPham.Name = "btn_ThemSanPham";
            this.btn_ThemSanPham.Size = new System.Drawing.Size(32, 22);
            this.btn_ThemSanPham.TabIndex = 90;
            this.btn_ThemSanPham.UseVisualStyleBackColor = false;
            this.btn_ThemSanPham.Click += new System.EventHandler(this.btn_ThemSanPham_Click);
            // 
            // btn_ThenNsx
            // 
            this.btn_ThenNsx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ThenNsx.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThenNsx.Image")));
            this.btn_ThenNsx.Location = new System.Drawing.Point(285, 127);
            this.btn_ThenNsx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ThenNsx.Name = "btn_ThenNsx";
            this.btn_ThenNsx.Size = new System.Drawing.Size(32, 22);
            this.btn_ThenNsx.TabIndex = 88;
            this.btn_ThenNsx.UseVisualStyleBackColor = false;
            this.btn_ThenNsx.Click += new System.EventHandler(this.btn_ThenNsx_Click);
            // 
            // btn_ThemChatLieu
            // 
            this.btn_ThemChatLieu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ThemChatLieu.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemChatLieu.Image")));
            this.btn_ThemChatLieu.Location = new System.Drawing.Point(285, 159);
            this.btn_ThemChatLieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ThemChatLieu.Name = "btn_ThemChatLieu";
            this.btn_ThemChatLieu.Size = new System.Drawing.Size(32, 22);
            this.btn_ThemChatLieu.TabIndex = 87;
            this.btn_ThemChatLieu.UseVisualStyleBackColor = false;
            this.btn_ThemChatLieu.Click += new System.EventHandler(this.btn_ThemChatLieu_Click);
            // 
            // btn_ThemSize
            // 
            this.btn_ThemSize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ThemSize.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemSize.Image")));
            this.btn_ThemSize.Location = new System.Drawing.Point(285, 228);
            this.btn_ThemSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ThemSize.Name = "btn_ThemSize";
            this.btn_ThemSize.Size = new System.Drawing.Size(32, 22);
            this.btn_ThemSize.TabIndex = 86;
            this.btn_ThemSize.UseVisualStyleBackColor = false;
            this.btn_ThemSize.Click += new System.EventHandler(this.btn_ThemSize_Click);
            // 
            // btn_ThemMauSac
            // 
            this.btn_ThemMauSac.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ThemMauSac.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemMauSac.Image")));
            this.btn_ThemMauSac.Location = new System.Drawing.Point(285, 196);
            this.btn_ThemMauSac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ThemMauSac.Name = "btn_ThemMauSac";
            this.btn_ThemMauSac.Size = new System.Drawing.Size(32, 22);
            this.btn_ThemMauSac.TabIndex = 85;
            this.btn_ThemMauSac.UseVisualStyleBackColor = false;
            this.btn_ThemMauSac.Click += new System.EventHandler(this.btn_ThemMauSac_Click);
            // 
            // btn_ThemDSP
            // 
            this.btn_ThemDSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ThemDSP.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemDSP.Image")));
            this.btn_ThemDSP.Location = new System.Drawing.Point(285, 94);
            this.btn_ThemDSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ThemDSP.Name = "btn_ThemDSP";
            this.btn_ThemDSP.Size = new System.Drawing.Size(32, 22);
            this.btn_ThemDSP.TabIndex = 84;
            this.btn_ThemDSP.UseVisualStyleBackColor = false;
            this.btn_ThemDSP.Click += new System.EventHandler(this.btn_ThemDSP_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(270, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 15);
            this.label13.TabIndex = 75;
            // 
            // pic_QR
            // 
            this.pic_QR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_QR.Location = new System.Drawing.Point(335, 262);
            this.pic_QR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_QR.Name = "pic_QR";
            this.pic_QR.Size = new System.Drawing.Size(214, 114);
            this.pic_QR.TabIndex = 34;
            this.pic_QR.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(335, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Mã QR code";
            // 
            // pic_SanPham
            // 
            this.pic_SanPham.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_SanPham.Location = new System.Drawing.Point(335, 105);
            this.pic_SanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_SanPham.Name = "pic_SanPham";
            this.pic_SanPham.Size = new System.Drawing.Size(214, 114);
            this.pic_SanPham.TabIndex = 26;
            this.pic_SanPham.TabStop = false;
            this.pic_SanPham.Click += new System.EventHandler(this.pic_SanPham_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(556, 20);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(80, 395);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ảnh minh họa";
            // 
            // rbtn_KhongHoatDong
            // 
            this.rbtn_KhongHoatDong.AutoSize = true;
            this.rbtn_KhongHoatDong.Location = new System.Drawing.Point(163, 408);
            this.rbtn_KhongHoatDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtn_KhongHoatDong.Name = "rbtn_KhongHoatDong";
            this.rbtn_KhongHoatDong.Size = new System.Drawing.Size(118, 19);
            this.rbtn_KhongHoatDong.TabIndex = 22;
            this.rbtn_KhongHoatDong.TabStop = true;
            this.rbtn_KhongHoatDong.Text = "Không hoạt dộng";
            this.rbtn_KhongHoatDong.UseVisualStyleBackColor = true;
            // 
            // rbtn_HoatDong
            // 
            this.rbtn_HoatDong.AutoSize = true;
            this.rbtn_HoatDong.Location = new System.Drawing.Point(162, 385);
            this.rbtn_HoatDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtn_HoatDong.Name = "rbtn_HoatDong";
            this.rbtn_HoatDong.Size = new System.Drawing.Size(83, 19);
            this.rbtn_HoatDong.TabIndex = 21;
            this.rbtn_HoatDong.TabStop = true;
            this.rbtn_HoatDong.Text = "Hoạt Động";
            this.rbtn_HoatDong.UseVisualStyleBackColor = true;
            // 
            // cmb_NSX
            // 
            this.cmb_NSX.FormattingEnabled = true;
            this.cmb_NSX.Location = new System.Drawing.Point(163, 127);
            this.cmb_NSX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_NSX.Name = "cmb_NSX";
            this.cmb_NSX.Size = new System.Drawing.Size(116, 23);
            this.cmb_NSX.TabIndex = 20;
            // 
            // cmb_ChatLieu
            // 
            this.cmb_ChatLieu.FormattingEnabled = true;
            this.cmb_ChatLieu.Location = new System.Drawing.Point(163, 161);
            this.cmb_ChatLieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_ChatLieu.Name = "cmb_ChatLieu";
            this.cmb_ChatLieu.Size = new System.Drawing.Size(116, 23);
            this.cmb_ChatLieu.TabIndex = 19;
            // 
            // Cmb_MauSac
            // 
            this.Cmb_MauSac.FormattingEnabled = true;
            this.Cmb_MauSac.Location = new System.Drawing.Point(163, 196);
            this.Cmb_MauSac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cmb_MauSac.Name = "Cmb_MauSac";
            this.Cmb_MauSac.Size = new System.Drawing.Size(116, 23);
            this.Cmb_MauSac.TabIndex = 18;
            // 
            // cmb_Size
            // 
            this.cmb_Size.FormattingEnabled = true;
            this.cmb_Size.Location = new System.Drawing.Point(163, 229);
            this.cmb_Size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Size.Name = "cmb_Size";
            this.cmb_Size.Size = new System.Drawing.Size(116, 23);
            this.cmb_Size.TabIndex = 17;
            // 
            // cmb_DongSp
            // 
            this.cmb_DongSp.FormattingEnabled = true;
            this.cmb_DongSp.Location = new System.Drawing.Point(163, 94);
            this.cmb_DongSp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_DongSp.Name = "cmb_DongSp";
            this.cmb_DongSp.Size = new System.Drawing.Size(116, 23);
            this.cmb_DongSp.TabIndex = 16;
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Location = new System.Drawing.Point(163, 262);
            this.txt_SoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(155, 23);
            this.txt_SoLuong.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tên Giày";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Dòng Sản Phẩm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tên Nhà Sản Xuất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chất Liệu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Màu Sắc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trạng Thái";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(476, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 38);
            this.button1.TabIndex = 157;
            this.button1.Text = "Confirm";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bnt_Them
            // 
            this.bnt_Them.BackColor = System.Drawing.SystemColors.Highlight;
            this.bnt_Them.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bnt_Them.Image = ((System.Drawing.Image)(resources.GetObject("bnt_Them.Image")));
            this.bnt_Them.Location = new System.Drawing.Point(23, 560);
            this.bnt_Them.Name = "bnt_Them";
            this.bnt_Them.Size = new System.Drawing.Size(83, 38);
            this.bnt_Them.TabIndex = 152;
            this.bnt_Them.Text = "Add";
            this.bnt_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bnt_Them.UseVisualStyleBackColor = false;
            this.bnt_Them.Click += new System.EventHandler(this.bnt_Them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.Location = new System.Drawing.Point(198, 560);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(85, 38);
            this.btn_Xoa.TabIndex = 154;
            this.btn_Xoa.Text = "Remove";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_CLear
            // 
            this.btn_CLear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_CLear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_CLear.Image = ((System.Drawing.Image)(resources.GetObject("btn_CLear.Image")));
            this.btn_CLear.Location = new System.Drawing.Point(288, 560);
            this.btn_CLear.Name = "btn_CLear";
            this.btn_CLear.Size = new System.Drawing.Size(88, 38);
            this.btn_CLear.TabIndex = 153;
            this.btn_CLear.Text = "Reset";
            this.btn_CLear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CLear.UseVisualStyleBackColor = false;
            // 
            // bnt_Sua
            // 
            this.bnt_Sua.BackColor = System.Drawing.SystemColors.Highlight;
            this.bnt_Sua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bnt_Sua.Image = ((System.Drawing.Image)(resources.GetObject("bnt_Sua.Image")));
            this.bnt_Sua.Location = new System.Drawing.Point(111, 560);
            this.bnt_Sua.Name = "bnt_Sua";
            this.bnt_Sua.Size = new System.Drawing.Size(81, 38);
            this.bnt_Sua.TabIndex = 155;
            this.bnt_Sua.Text = "Edit";
            this.bnt_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bnt_Sua.UseVisualStyleBackColor = false;
            this.bnt_Sua.Click += new System.EventHandler(this.bnt_Sua_Click);
            // 
            // btn_ThemList
            // 
            this.btn_ThemList.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_ThemList.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ThemList.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemList.Image")));
            this.btn_ThemList.Location = new System.Drawing.Point(381, 560);
            this.btn_ThemList.Name = "btn_ThemList";
            this.btn_ThemList.Size = new System.Drawing.Size(90, 38);
            this.btn_ThemList.TabIndex = 156;
            this.btn_ThemList.Text = "Add vers";
            this.btn_ThemList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ThemList.UseVisualStyleBackColor = false;
            this.btn_ThemList.Click += new System.EventHandler(this.btn_ThemList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Fl_SanPham);
            this.groupBox2.Location = new System.Drawing.Point(573, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(99, 589);
            this.groupBox2.TabIndex = 161;
            this.groupBox2.TabStop = false;
            // 
            // Frm_ChiTietSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1268, 606);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgrid_sanpham);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bnt_Them);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_CLear);
            this.Controls.Add(this.bnt_Sua);
            this.Controls.Add(this.btn_ThemList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_ChiTietSanPham";
            this.Text = "Sản Phẩm";
            this.Load += new System.EventHandler(this.Frm_ChiTietSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_sanpham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_QR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_SanPham)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgrid_sanpham;
        private System.Windows.Forms.FlowLayoutPanel Fl_SanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Ma;
        private System.Windows.Forms.ComboBox cmb_SanPham;
        private System.Windows.Forms.RichTextBox richtxt_mota;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_giaban;
        private System.Windows.Forms.TextBox txt_gianhap;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_ThemSanPham;
        private System.Windows.Forms.Button btn_ThenNsx;
        private System.Windows.Forms.Button btn_ThemChatLieu;
        private System.Windows.Forms.Button btn_ThemSize;
        private System.Windows.Forms.Button btn_ThemMauSac;
        private System.Windows.Forms.Button btn_ThemDSP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pic_QR;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pic_SanPham;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbtn_KhongHoatDong;
        private System.Windows.Forms.RadioButton rbtn_HoatDong;
        private System.Windows.Forms.ComboBox cmb_NSX;
        private System.Windows.Forms.ComboBox cmb_ChatLieu;
        private System.Windows.Forms.ComboBox Cmb_MauSac;
        private System.Windows.Forms.ComboBox cmb_Size;
        private System.Windows.Forms.ComboBox cmb_DongSp;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bnt_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_CLear;
        private System.Windows.Forms.Button bnt_Sua;
        private System.Windows.Forms.Button btn_ThemList;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}