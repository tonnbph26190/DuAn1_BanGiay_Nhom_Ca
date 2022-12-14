using _2.BUS.IServices;
using _2.BUS.Services;
using _3.PL.Properties;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static QRCoder.PayloadGenerator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace _3.PL.View
{
    public partial class Frm_ThongKeHD : Form
    {
        private IHoaDonService _HdService;
        private INhanVienService _NvService;
        private IHdTest _hdTest;
        private IHoaDonChiTietServices _cthdService;

        public Frm_ThongKeHD()
        {
            InitializeComponent();
            _HdService = new HoaDonServices();
            _NvService = new NhanVienService();
            _hdTest = new HDTest();
            _cthdService = new HoaDonChiTietServices();
            // LoadDgridHD();
            lbl_start.Visible = false;
            lbl_end.Visible = false;
            dtp_start.Visible = false;
            dtp_end.Visible = false;
            // btn_lockhoangtg.Enabled = false;
            // lab_closedetail.Visible = true;
            // btn_reload.Visible = false;
            //btn_ss.Visible = false;
            grb_ss.Visible = false;
            //rightpanel.Visible = false;
            //lab_closedetail.Visible = false;
            // lbl_ss.Visible = false;
            LoadLoc();
            dgrid_t1.Visible = false;
            dgrid_t2.Visible = false;
            txt_dataemail.Visible = false;
            //pb_email.Image = Resources.txt;
            //pb_ex.Image = Resources.sheet;
            reload();
            pb_email.Image = Resources.txt;
            pb_ex.Image = Resources.sheet;
        }

        public void LoadLoc()
        {
            List<string> lst = new List<string>()
            {
                "0.Chưa thanh toán","1.Đã thanh toán","2.Đang giao hàng"

            };
            foreach (var x in lst)
            {
                cmb_LocTT.Items.Add(x);

            }

            List<string> lst1 = new List<string>();
            foreach (var x in _NvService.GetAllQuanLi())
            {
                lst1.Add(x.Email);
            }
            foreach (var x in lst1)
            {
                cmb_mailBC.Items.Add(x);
            }
        }
        public void LoadDgridHD()
        {
            int stt = 1;
            dgrid_Hd.ColumnCount = 15;
            dgrid_Hd.Columns[0].Name = "STT";
            dgrid_Hd.Columns[1].Name = "Mã hóa đơn";
            dgrid_Hd.Columns[2].Name = "Thông tin khách hàng";
            dgrid_Hd.Columns[3].Name = "Email";
            dgrid_Hd.Columns[4].Name = "Thông tin nhân viên";
            dgrid_Hd.Columns[5].Name = "Ngày lập";
            dgrid_Hd.Columns[6].Name = "Ngày thanh toán";
            dgrid_Hd.Columns[7].Name = "Ngày nhận hàng";
            dgrid_Hd.Columns[8].Name = "Tổng tiền";
            dgrid_Hd.Columns[9].Name = "Trạng thái";
            dgrid_Hd.Columns[10].Name = "Đơn thành công";
            dgrid_Hd.Columns[10].Visible = false;
            dgrid_Hd.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_Hd.Columns[11].Visible = false;
            dgrid_Hd.Columns[12].Name = "Đơn đã hủy";
            dgrid_Hd.Columns[12].Visible = false;
            dgrid_Hd.Columns[13].Name = "Đơn đang giao";
            dgrid_Hd.Columns[13].Visible = false;
            dgrid_Hd.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;


            dgrid_Hd.Rows.Clear();
            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c => c.NgayLap == DateTime.Now.ToString()))
            {

                // MessageBox.Show(x.NgayLap + "..." + dtp_loc.Value);
                dgrid_Hd.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" :(x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy") ), x.DonThanhCong,x.DonChuaTT,x.DonHuy,x.DangGiao,x.DonThanhCong+x.DonChuaTT+x.DangGiao+x.DonHuy);
            }
            //Tổng tiền
            int sum = 0, sumdanggiao = 0, sumdonhuy = 0, sumchuathanhtoan = 0, sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_Hd.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[8].Value);
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã thanh toán")
                {
                    sumdonthanhcong += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Chưa thanh toán")
                {
                    sumchuathanhtoan += 1;
                }

                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đang giao hàng")
                {
                    sumdanggiao += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã hủy")
                {
                    sumdonhuy += 1;
                }


            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            lbl_DangGiao.Text = Convert.ToString(sumdanggiao);
            labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            lbl_chuathanhtoan.Text = Convert.ToString(sumchuathanhtoan);
            lbl_huydon.Text = Convert.ToString(sumdonhuy);
            lbl_counthd.Text = Convert.ToString(sumdanggiao + sumdonthanhcong + sumchuathanhtoan - sumdonhuy);

        }

        //private void dgrid_Hd_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốnxem chi tiết hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo);
        //    if (dialogResult == DialogResult.Yes)
        //    {
        //        int rowIndex = e.RowIndex;
        //        if (rowIndex == _HdService.GetAll().Count) return;

        //        Frm_CtietHD formCt = new Frm_CtietHD();
        //        string ma = dgrid_Hd.Rows[rowIndex].Cells[1].Value.ToString();
        //        formCt.maHD = ma;
        //        MessageBox.Show("Mã hóa đơn" + ma);
        //        formCt.ShowDialog();
        //    }
        //    if (dialogResult == DialogResult.No) return;
        //}


        void byDay(DateTime? dt)
        {
            dgrid_Hd.Rows.Clear();
            dgrid_Hd.Columns.Clear();
            int stt = 1;
            dgrid_Hd.ColumnCount = 15;
            dgrid_Hd.Columns[0].Name = "STT";
            dgrid_Hd.Columns[1].Name = "Mã hóa đơn";
            dgrid_Hd.Columns[2].Name = "Thông tin khách hàng";
            dgrid_Hd.Columns[3].Name = "Email";
            dgrid_Hd.Columns[4].Name = "Thông tin nhân viên";
            dgrid_Hd.Columns[5].Name = "Ngày lập";
            dgrid_Hd.Columns[6].Name = "Ngày thanh toán";
            dgrid_Hd.Columns[7].Name = "Ngày nhận hàng";
            dgrid_Hd.Columns[8].Name = "Tổng tiền";
            dgrid_Hd.Columns[9].Name = "Trạng thái";
            dgrid_Hd.Columns[10].Name = "Đơn thành công";
            dgrid_Hd.Columns[10].Visible = false;
            dgrid_Hd.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_Hd.Columns[11].Visible = false;
            dgrid_Hd.Columns[12].Name = "Đơn đã hủy";
            dgrid_Hd.Columns[12].Visible = false;
            dgrid_Hd.Columns[13].Name = "Đơn đang giao";
            dgrid_Hd.Columns[13].Visible = false;
            dgrid_Hd.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;

            dgrid_Hd.Rows.Clear();
            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c => Convert.ToDateTime(c.NgayLap) == dt))
            {
                dgrid_Hd.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);

            }
            //Tổng tiền
            int sum = 0, sumdanggiao = 0, sumdonhuy = 0, sumchuathanhtoan = 0, sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_Hd.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[8].Value);
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã thanh toán")
                {
                    sumdonthanhcong += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Chưa thanh toán")
                {
                    sumchuathanhtoan += 1;
                }

                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đang giao hàng")
                {
                    sumdanggiao += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã hủy")
                {
                    sumdonhuy += 1;
                }


            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            lbl_DangGiao.Text = Convert.ToString(sumdanggiao);
            labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            lbl_chuathanhtoan.Text = Convert.ToString(sumchuathanhtoan);
            lbl_huydon.Text = Convert.ToString(sumdonhuy);
            lbl_counthd.Text = Convert.ToString(sumdanggiao + sumdonthanhcong + sumchuathanhtoan - sumdonhuy);
        }

        private void dtp_loc_ValueChanged(object sender, EventArgs e)
        {
            btn_lockhoangtg.Enabled = false;
            byDay(Convert.ToDateTime(dtp_loc.Value.ToString("MM-dd-yyyy")));
            btn_lockhoangtg.Enabled = true;
            txt_dataemail.Visible = true;
        }

        void byForDay(DateTime dtst, DateTime dte)
        {
            int stt = 1;
            dgrid_Hd.ColumnCount = 15;
            dgrid_Hd.Columns[0].Name = "STT";
            dgrid_Hd.Columns[1].Name = "Mã hóa đơn";
            dgrid_Hd.Columns[2].Name = "Thông tin khách hàng";
            dgrid_Hd.Columns[3].Name = "Email";
            dgrid_Hd.Columns[4].Name = "Thông tin nhân viên";
            dgrid_Hd.Columns[5].Name = "Ngày lập";
            dgrid_Hd.Columns[6].Name = "Ngày thanh toán";
            dgrid_Hd.Columns[7].Name = "Ngày nhận hàng";
            dgrid_Hd.Columns[8].Name = "Tổng tiền";
            dgrid_Hd.Columns[9].Name = "Trạng thái";
            dgrid_Hd.Columns[10].Name = "Đơn thành công";
            dgrid_Hd.Columns[10].Visible = false;
            dgrid_Hd.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_Hd.Columns[11].Visible = false;
            dgrid_Hd.Columns[12].Name = "Đơn đã hủy";
            dgrid_Hd.Columns[12].Visible = false;
            dgrid_Hd.Columns[13].Name = "Đơn đang giao";
            dgrid_Hd.Columns[13].Visible = false;
            dgrid_Hd.Columns[14].Name = "Đơn đã lập";
                 dgrid_Hd.Columns[14].Visible = false;
            dgrid_Hd.Rows.Clear();
            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c => Convert.ToDateTime(c.NgayLap) >= dtst && Convert.ToDateTime(c.NgayLap) <= dte))
            {
                dgrid_Hd.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);

            }
            //Tổng tiền
            int sum = 0, sumdanggiao = 0, sumdonhuy = 0, sumchuathanhtoan = 0, sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_Hd.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[8].Value);
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã thanh toán")
                {
                    sumdonthanhcong += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Chưa thanh toán")
                {
                    sumchuathanhtoan += 1;
                }

                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đang giao hàng")
                {
                    sumdanggiao += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã hủy")
                {
                    sumdonhuy += 1;
                }


            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            lbl_DangGiao.Text = Convert.ToString(sumdanggiao);
            labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            lbl_chuathanhtoan.Text = Convert.ToString(sumchuathanhtoan);
            lbl_huydon.Text = Convert.ToString(sumdonhuy);
            lbl_counthd.Text = Convert.ToString(sumdanggiao + sumdonthanhcong + sumchuathanhtoan - sumdonhuy);
        }
        private void btn_lockhoangtg_Click(object sender, EventArgs e)
        {
            //dtp_loc.Enabled = false;
            lbl_start.Visible = true;
            lbl_end.Visible = true;
            dtp_start.Visible = true;
            dtp_end.Visible = true;
            //mở reload nèo
            lab_closedetail.Visible = true;
            btn_reload.Visible = true;
            lbl_counthd.Text = "0";
            lbl_tongtien.Text = "0";
            lbl_chuathanhtoan.Text = "0";
            labl_sodonthanhcong.Text = "0";
            lbl_huydon.Text = "0";
            lbl_tongtien.Text = "0";
            lbl_DangGiao.Text = "0";
            btn_ss.Visible = true;
            lbl_ss.Visible = true;
            rightpanel.Visible = true;

        }

        private void dtp_start_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_start.Value > dtp_end.Value)
            {
                MessageBox.Show("Mốc Bắt Đầu Không Thể Lớn Hơn Mốc Kết Thúc");

                return;
            }
            // dtp_start.Value = Convert.ToDateTime("MM-dd-yyyy");
            byForDay(Convert.ToDateTime(dtp_start.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_end.Value.ToString("MM-dd-yyyy")));
            dtp_loc.Enabled = true;
        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_start.Value > dtp_end.Value)
            {
                MessageBox.Show("Mốc Bắt Đầu Không Thể Lớn Hơn Mốc Kết Thúc");
                return;
            }
            // dtp_start.Value = Convert.ToDateTime("MM-dd-yyyy");

            byForDay(Convert.ToDateTime(dtp_start.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_end.Value.ToString("MM-dd-yyyy")));
            dtp_loc.Enabled = true;
        }

        private void pb_email_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lấy ra thông tin khách hàng hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txt_dataemail.Text = saveFileDialog.FileName;
                        //
                        TextWriter textWriter = new StreamWriter(txt_dataemail.Text);
                        for (int i = 0; i < dgrid_Hd.RowCount - 1; i++)//row
                        {

                            textWriter.Write(Convert.ToString(dgrid_Hd.Rows[i].Cells["Thông tin khách hàng"].Value+","+ dgrid_Hd.Rows[i].Cells["Email"].Value + "\n"));
                            //"Thông tin khách hàng
                        }
                        textWriter.Close();

                    }
                }

            }
        }


        void reload()
        {
            dgrid_Hd.Rows.Clear();
            dgrid_Hd.Columns.Clear();
            int stt = 1;
            dgrid_Hd.ColumnCount = 15;
            dgrid_Hd.Columns[0].Name = "STT";
            //dgrid_Hd.Columns[0].Visible = false;
            dgrid_Hd.Columns[1].Name = "Mã hóa đơn";
            //dgrid_Hd.Columns[1].Visible = false;
            dgrid_Hd.Columns[2].Name = "Thông tin khách hàng";
            dgrid_Hd.Columns[2].Visible = false;
            dgrid_Hd.Columns[3].Name = "Email";
            dgrid_Hd.Columns[3].Visible = false;
            dgrid_Hd.Columns[4].Name = "Thông tin nhân viên";
            dgrid_Hd.Columns[4].Visible = false;
            dgrid_Hd.Columns[5].Name = "Ngày lập";
            // dgrid_Hd.Columns[5].Visible = false;
            dgrid_Hd.Columns[6].Name = "Ngày thanh toán";
            dgrid_Hd.Columns[6].Visible = false;
            dgrid_Hd.Columns[7].Name = "Ngày nhận hàng";
            dgrid_Hd.Columns[7].Visible = false;
            dgrid_Hd.Columns[8].Name = "Tổng tiền";
            // dgrid_Hd.Columns[8].Visible = false;
            dgrid_Hd.Columns[9].Name = "Trạng thái";
            //dgrid_Hd.Columns[9].Visible = false;
            dgrid_Hd.Columns[10].Name = "Đơn thành công";
            dgrid_Hd.Columns[10].Visible = false;
            dgrid_Hd.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_Hd.Columns[11].Visible = false;
            dgrid_Hd.Columns[12].Name = "Đơn đã hủy";
            dgrid_Hd.Columns[12].Visible = false;
            dgrid_Hd.Columns[13].Name = "Đơn đang giao";
            dgrid_Hd.Columns[13].Visible = false;
            dgrid_Hd.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;


            dgrid_Hd.Rows.Clear();
            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay())
            {
                dgrid_Hd.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);
            }
            //Tổng tiền
            int sum = 0, sumdanggiao = 0, sumdonhuy = 0, sumchuathanhtoan = 0, sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_Hd.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[8].Value);
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã thanh toán")
                {
                    sumdonthanhcong += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Chưa thanh toán")
                {
                    sumchuathanhtoan += 1;
                }

                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đang giao hàng")
                {
                    sumdanggiao += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã hủy")
                {
                    sumdonhuy += 1;
                }


            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            lbl_DangGiao.Text = Convert.ToString(sumdanggiao);
            labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            lbl_chuathanhtoan.Text = Convert.ToString(sumchuathanhtoan);
            lbl_huydon.Text = Convert.ToString(sumdonhuy);
            lbl_counthd.Text = Convert.ToString(sumdanggiao + sumdonthanhcong + sumchuathanhtoan - sumdonhuy);

        }
        private void btn_reload_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn ReLoad Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                lab_closedetail.Visible = false;
                lbl_start.Visible = false;
                lbl_end.Visible = false;
                dtp_end.Visible = false;
                dtp_start.Visible = false;
                btn_reload.Visible = false;

                //
                lbl_ss.Visible = false;
                btn_ss.Visible = false;
                grb_ss.Visible = false;
                dtp_loc.Enabled = true;
                rightpanel.Visible = false;

                reload();
            }
        }

        

        

        void loc(string mess)
        {
            dgrid_Hd.Rows.Clear();
            dgrid_Hd.Columns.Clear();
            int stt = 1;
            dgrid_Hd.ColumnCount = 15;
            dgrid_Hd.Columns[0].Name = "STT";
            dgrid_Hd.Columns[1].Name = "Mã hóa đơn";
            dgrid_Hd.Columns[2].Name = "Thông tin khách hàng";
            dgrid_Hd.Columns[3].Name = "Email";
            dgrid_Hd.Columns[4].Name = "Thông tin nhân viên";
            dgrid_Hd.Columns[5].Name = "Ngày lập";
            dgrid_Hd.Columns[6].Name = "Ngày thanh toán";
            dgrid_Hd.Columns[7].Name = "Ngày nhận hàng";
            dgrid_Hd.Columns[8].Name = "Tổng tiền";
            dgrid_Hd.Columns[9].Name = "Trạng thái";
            dgrid_Hd.Columns[10].Name = "Đơn thành công";
            dgrid_Hd.Columns[10].Visible = false;
            dgrid_Hd.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_Hd.Columns[11].Visible = false;
            dgrid_Hd.Columns[12].Name = "Đơn đã hủy";
            dgrid_Hd.Columns[12].Visible = false;
            dgrid_Hd.Columns[13].Name = "Đơn đang giao";
            dgrid_Hd.Columns[13].Visible = false;
            dgrid_Hd.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;


            dgrid_Hd.Rows.Clear();
            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c => c.TrangThai.ToString() == mess))
            {
                dgrid_Hd.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);
            }
            //Tổng tiền
            int sum = 0, sumdanggiao = 0, sumdonhuy = 0, sumchuathanhtoan = 0, sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_Hd.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[8].Value);
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã thanh toán")
                {
                    sumdonthanhcong += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Chưa thanh toán")
                {
                    sumchuathanhtoan += 1;
                }

                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đang giao hàng")
                {
                    sumdanggiao += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã hủy")
                {
                    sumdonhuy += 1;
                }


            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            lbl_DangGiao.Text = Convert.ToString(sumdanggiao);
            labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            lbl_chuathanhtoan.Text = Convert.ToString(sumchuathanhtoan);
            lbl_huydon.Text = Convert.ToString(sumdonhuy);
            lbl_counthd.Text = Convert.ToString(sumdanggiao + sumdonthanhcong + sumchuathanhtoan - sumdonhuy);
        }


        private void cmb_LocTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            loc(cmb_LocTT.Text == "0.Chưa thanh toán" ? "0" : (cmb_LocTT.Text == "1.Đã thanh toán" ? "1" : (cmb_LocTT.Text== "3.Đang giao hàng"?"10" :"2") ));
        }


        void timKiem(string mess)
        {
            dgrid_Hd.Rows.Clear();
            dgrid_Hd.Columns.Clear();
            int stt = 1;
            dgrid_Hd.ColumnCount = 15;
            dgrid_Hd.Columns[0].Name = "STT";
            dgrid_Hd.Columns[1].Name = "Mã hóa đơn";
            dgrid_Hd.Columns[2].Name = "Thông tin khách hàng";
            dgrid_Hd.Columns[3].Name = "Email";
            dgrid_Hd.Columns[4].Name = "Thông tin nhân viên";
            dgrid_Hd.Columns[5].Name = "Ngày lập";
            dgrid_Hd.Columns[6].Name = "Ngày thanh toán";
            dgrid_Hd.Columns[7].Name = "Ngày nhận hàng";
            dgrid_Hd.Columns[8].Name = "Tổng tiền";
            dgrid_Hd.Columns[9].Name = "Trạng thái";
            dgrid_Hd.Columns[10].Name = "Đơn thành công";
            dgrid_Hd.Columns[10].Visible = false;
            dgrid_Hd.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_Hd.Columns[11].Visible = false;
            dgrid_Hd.Columns[12].Name = "Đơn đã hủy";
            dgrid_Hd.Columns[12].Visible = false;
            dgrid_Hd.Columns[13].Name = "Đơn đang giao";
            dgrid_Hd.Columns[13].Visible = false;
            dgrid_Hd.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;


            dgrid_Hd.Rows.Clear();
            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c => c.MaNhanVien.ToLower().Contains(mess.ToLower()) || c.MaNhanVien.ToLower().Contains(mess.ToLower()) || c.SoDienThoai.Contains(mess.ToLower())))
            {
                dgrid_Hd.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);
            }
            //Tổng tiền
            int sum = 0, sumdanggiao = 0, sumdonhuy = 0, sumchuathanhtoan = 0, sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_Hd.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[8].Value);
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã thanh toán")
                {
                    sumdonthanhcong += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Chưa thanh toán")
                {
                    sumchuathanhtoan += 1;
                }

                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đang giao hàng")
                {
                    sumdanggiao += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã hủy")
                {
                    sumdonhuy += 1;
                }


            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            lbl_DangGiao.Text = Convert.ToString(sumdanggiao);
            labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            lbl_chuathanhtoan.Text = Convert.ToString(sumchuathanhtoan);
            lbl_huydon.Text = Convert.ToString(sumdonhuy);
            lbl_counthd.Text = Convert.ToString(sumdanggiao + sumdonthanhcong + sumchuathanhtoan - sumdonhuy);
        }
        private void txt_TimKiem_MouseLeave(object sender, EventArgs e)
        {
            txt_TimKiem.Text = " ";
        }

        private void txt_TimKiem_MouseHover(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "")
            {
                txt_TimKiem.Text = "Mã hóa đơn, mã nhân viên, sdt";
            }
        }

        private void txt_TimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            timKiem(txt_TimKiem.Text);
        }

        private void txt_TimKiem_MouseDown(object sender, MouseEventArgs e)
        {
            txt_TimKiem.Text = " ";
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            timKiem(txt_TimKiem.Text);
        }

        //public void toExcel(DataGridView dataGridView, string fileName)
        //{
        //    //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
        //    Microsoft.Office.Interop.Excel.Application excel;
        //    Microsoft.Office.Interop.Excel.Workbook workbook;
        //    Microsoft.Office.Interop.Excel.Worksheet worksheet;
        //    try
        //    {
        //        //Tạo đối tượng COM.
        //        excel = new Microsoft.Office.Interop.Excel.Application();
        //        excel.Visible = false;
        //        excel.DisplayAlerts = false;
        //        //tạo mới một Workbooks bằng phương thức add()
        //        workbook = excel.Workbooks.Add(Type.Missing);
        //        worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
        //        //đặt tên cho sheet
        //        worksheet.Name = "Thống kê doanh thu";

        //        // export header trong DataGridView
        //        for (int i = 0; i < dataGridView.ColumnCount; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
        //        }
        //        // export nội dung trong DataGridView
        //        for (int i = 0; i < dataGridView.RowCount; i++)
        //        {
        //            for (int j = 0; j < dataGridView.ColumnCount; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
        //            }
        //        }
        //        // sử dụng phương thức SaveAs() để lưu workbook với filename
        //        workbook.SaveAs(fileName);
        //        //đóng workbook
        //        workbook.Close();
        //        excel.Quit();
        //        MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        workbook = null;
        //        worksheet = null;
        //    }

        //}

        private void pb_ex_Click(object sender, EventArgs e)
        {
            try
            {


                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel | *.xlsx | Excel 2016 | *.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet worksheet = workbook.Worksheets[0];
                    //Adding text to a cell
                    for (int i = 1; i < dgrid_Hd.Columns.Count + 1; i++)
                    {
                        worksheet.Range[1, i].Text = dgrid_Hd.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgrid_Hd.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgrid_Hd.Columns.Count; j++)
                        {
                            worksheet.Range[i + 2, j + 1].Text = dgrid_Hd.Rows[i].Cells[j].Value.ToString();
                        }
                    }


                    //Saving the workbook to disk in XLSX format
                    Stream excelstream = File.Create(Path.GetFullPath(filePath));
                    //Byte[] bin = excelEngine.GetAsByteArray();
                    //Stream excelstream = File.WriteAllBytes(filePath);
                    workbook.SaveAs(excelstream);
                    excelstream.Dispose();

                }

                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                //      toExcel(dgrid_Hd, saveFileDialog1.FileName);
                //}

                MessageBox.Show("Xuất file data thành công","Thông báo",MessageBoxButtons.OK);
            }
            catch (Exception)
            {

                MessageBox.Show("ahihi");
            }
        }



        public void sendEmail()
        {
           
            if (cmb_mailBC.Text=="")
            {
                MessageBox.Show("Hãy chọn người gửi email báo cáo","Thông báo",MessageBoxButtons.OK);
                return;
            }
            byDay(Convert.ToDateTime(dtp_loc.Value.ToString("MM-dd-yyyy")));
            string maNV = _NvService.GetAll().FirstOrDefault(c => c.Email == Properties.Settings.Default.TKdaLogin).MaNhanVien;
            string from, to, pass, content;
            MailMessage mess = new MailMessage();
            from = "ckuotga1997@gmail.com";
            pass = "rblzrnngambpsdoe";
            to = cmb_mailBC.Text;
            mess.To.Add(to);
            mess.From = new MailAddress(from);
            mess.Subject = "Báo cáo doanh thu bán giày Sneaker";
            mess.Body = "Báo cáo doanh thu ngày:" + dtp_loc.Value + "\n " + "Tổng doanh thu: " + lbl_tongtien.Text + " VND \n" + "Tổng hóa đơn: " + lbl_counthd.Text + "\n"+ "Tổng hóa đơn đã thanh toán: " + labl_sodonthanhcong.Text + "\n" + "Tổng hóa đang giao: " + lbl_DangGiao.Text + "\n" + "Tổng hoá đơn đã hủy: " + lbl_huydon.Text + "\n\n" +"Nhân viên: "+maNV;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(from, pass);
            try
            {
                // DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn ReLoad Hay Không?", "Thông Báo", MessageBoxButtons.YesNo);
                client.Send(mess);
                MessageBox.Show("Gửi mail báo cáo thành công","Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            sendEmail();
        }


        void soSanh(DateTime d1, DateTime d2)
        {
            grb_ss.Visible = true;
            
            #region bỏ nhé
            //    int stt = 1;
            //    dgrid_ss.ColumnCount = 12;
            //    dgrid_ss.Columns[0].Name = "STT";
            //    dgrid_ss.Columns[1].Name = "Mã hóa đơn";
            //    dgrid_ss.Columns[2].Name = "Thông tin khách hàng";
            //    dgrid_ss.Columns[2].Visible = false;
            //    dgrid_ss.Columns[3].Name = "Email";
            //    dgrid_ss.Columns[4].Name = "Thông tin nhân viên";
            //    dgrid_ss.Columns[5].Name = "Ngày lập";
            //    dgrid_ss.Columns[6].Name = "Tổng tiền";
            //    dgrid_ss.Columns[7].Name = "Trạng thái";
            //    dgrid_ss.Columns[9].Name = "Đơn thành công";
            //    dgrid_ss.Columns[9].Visible = false;
            //    dgrid_ss.Columns[10].Name = "Đơn chưa thanh toán";
            //    dgrid_ss.Columns[10].Visible = false;
            //    dgrid_ss.Columns[11].Name = "Đơn đã hủy";
            //    dgrid_ss.Columns[11].Visible = false;



            //    dgrid_Hd.Rows.Clear();
            //    // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            //    foreach (var x in _hdTest.GetlstHDByDay())
            //    {

            //        // MessageBox.Show(x.NgayLap + "..." + dtp_loc.Value);
            //        dgrid_ss.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : "Đã hủy"));
            //        //Tổng tiền
            //        int sum = 0;
            //        for (int i = 0; i < dgrid_Hd.Rows.Count; ++i)
            //        {
            //            sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[6].Value);
            //        }
            //        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            //        double tt = Convert.ToDouble(sum);

            //        //
            //        DataGridViewTextBoxColumn tongtien = new DataGridViewTextBoxColumn();
            //        tongtien.HeaderText = "Tổng Doanh Thu";
            //        tongtien.Name = "txt_total";

            //    }
            #endregion

            dgrid_Hd.Rows.Clear();
            int stt = 1;
            dgrid_Hd.ColumnCount = 15;
            dgrid_Hd.Columns[0].Name = "STT";
            //dgrid_Hd.Columns[0].Visible = false;
            dgrid_Hd.Columns[1].Name = "Mã hóa đơn";
            //dgrid_Hd.Columns[1].Visible = false;
            dgrid_Hd.Columns[2].Name = "Thông tin khách hàng";
            // dgrid_Hd.Columns[2].Visible = false;
            dgrid_Hd.Columns[3].Name = "Email";
            dgrid_Hd.Columns[3].Visible = false;
            dgrid_Hd.Columns[4].Name = "Thông tin nhân viên";
            // dgrid_Hd.Columns[4].Visible = false;
            dgrid_Hd.Columns[5].Name = "Ngày lập";
            // dgrid_Hd.Columns[5].Visible = false;
            dgrid_Hd.Columns[6].Name = "Ngày thanh toán";
            //dgrid_Hd.Columns[6].Visible = false;
            dgrid_Hd.Columns[7].Name = "Ngày nhận hàng";
            //dgrid_Hd.Columns[7].Visible = false;
            dgrid_Hd.Columns[8].Name = "Tổng tiền";
            // dgrid_Hd.Columns[8].Visible = false;
            dgrid_Hd.Columns[9].Name = "Trạng thái";
            //dgrid_Hd.Columns[9].Visible = false;
            dgrid_Hd.Columns[10].Name = "Đơn thành công";
            dgrid_Hd.Columns[10].Visible = false;
            dgrid_Hd.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_Hd.Columns[11].Visible = false;
            dgrid_Hd.Columns[12].Name = "Đơn đã hủy";
            dgrid_Hd.Columns[12].Visible = false;
            dgrid_Hd.Columns[13].Name = "Đơn đang giao";
            dgrid_Hd.Columns[13].Visible = false;
            dgrid_Hd.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;
            dgrid_Hd.Rows.Clear();

            
            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c=>Convert.ToDateTime(c.NgayLap)==d1 || Convert.ToDateTime(c.NgayLap) == d2))
            {
                dgrid_Hd.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 10 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);
                // MessageBox.Show
            }

            dgrid_t1.ColumnCount = 15;
            dgrid_t1.Columns[0].Name = "STT";
            //dgrid_Hd.Columns[0].Visible = false;
            dgrid_t1.Columns[1].Name = "Mã hóa đơn";
            //dgrid_Hd.Columns[1].Visible = false;
            dgrid_t1.Columns[2].Name = "Thông tin khách hàng";
            // dgrid_Hd.Columns[2].Visible = false;
            dgrid_t1.Columns[3].Name = "Email";
            dgrid_t1.Columns[3].Visible = false;
            dgrid_t1.Columns[4].Name = "Thông tin nhân viên";
            // dgrid_Hd.Columns[4].Visible = false;
            dgrid_t1.Columns[5].Name = "Ngày lập";
            // dgrid_Hd.Columns[5].Visible = false;
            dgrid_t1.Columns[6].Name = "Ngày thanh toán";
            //dgrid_Hd.Columns[6].Visible = false;
            dgrid_t1.Columns[7].Name = "Ngày nhận hàng";
            //dgrid_Hd.Columns[7].Visible = false;
            dgrid_t1.Columns[8].Name = "Tổng tiền";
            // dgrid_Hd.Columns[8].Visible = false;
            dgrid_t1.Columns[9].Name = "Trạng thái";
            //dgrid_Hd.Columns[9].Visible = false;
            dgrid_t1.Columns[10].Name = "Đơn thành công";
            dgrid_t1.Columns[10].Visible = false;
            dgrid_t1.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_t1.Columns[11].Visible = false;
            dgrid_t1.Columns[12].Name = "Đơn đã hủy";
            dgrid_t1.Columns[12].Visible = false;
            dgrid_t1.Columns[13].Name = "Đơn đang giao";
            dgrid_t1.Columns[13].Visible = false;
            dgrid_t1.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;
            dgrid_t1.Rows.Clear();


            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c => Convert.ToDateTime(c.NgayLap) == d1))
            {
                dgrid_t1.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);
            }

            dgrid_t2.ColumnCount = 15;
            dgrid_t2.Columns[0].Name = "STT";
            //dgrid_Hd.Columns[0].Visible = false;
            dgrid_t2.Columns[1].Name = "Mã hóa đơn";
            //dgrid_Hd.Columns[1].Visible = false;
            dgrid_t2.Columns[2].Name = "Thông tin khách hàng";
            // dgrid_Hd.Columns[2].Visible = false;
            dgrid_t2.Columns[3].Name = "Email";
            dgrid_t2.Columns[3].Visible = false;
            dgrid_t2.Columns[4].Name = "Thông tin nhân viên";
            // dgrid_Hd.Columns[4].Visible = false;
            dgrid_t2.Columns[5].Name = "Ngày lập";
            // dgrid_Hd.Columns[5].Visible = false;
            dgrid_t2.Columns[6].Name = "Ngày thanh toán";
            //dgrid_Hd.Columns[6].Visible = false;
            dgrid_t2.Columns[7].Name = "Ngày nhận hàng";
            //dgrid_Hd.Columns[7].Visible = false;
            dgrid_t2.Columns[8].Name = "Tổng tiền";
            // dgrid_Hd.Columns[8].Visible = false;
            dgrid_t2.Columns[9].Name = "Trạng thái";
            //dgrid_Hd.Columns[9].Visible = false;
            dgrid_t2.Columns[10].Name = "Đơn thành công";
            dgrid_t2.Columns[10].Visible = false;
            dgrid_t2.Columns[11].Name = "Đơn chưa thanh toán";
            dgrid_t2.Columns[11].Visible = false;
            dgrid_t2.Columns[12].Name = "Đơn đã hủy";
            dgrid_t2.Columns[12].Visible = false;
            dgrid_t2.Columns[13].Name = "Đơn đang giao";
            dgrid_t2.Columns[13].Visible = false;
            dgrid_t2.Columns[14].Name = "Đơn đã lập";
            dgrid_Hd.Columns[14].Visible = false;
            dgrid_t2.Rows.Clear();


            // MessageBox.Show(_HdService.ShowHoadon().Count.ToString());
            foreach (var x in _hdTest.GetlstHDByDay().Where(c => Convert.ToDateTime(c.NgayLap) == d2))
            {
                dgrid_t2.Rows.Add(stt++, x.MaHoaDon, x.MaKhachHang + ", " + x.TenKhachHang + ", " + x.SoDienThoai + ", " + x.DiaChi, x.Email, x.MaNhanVien, x.NgayLap, x.NgayThanhToan, x.NgayNhan, x.TongTien, x.TrangThai == 0 ? "Chưa thanh toán" : (x.TrangThai == 1 ? "Đã thanh toán" : (x.TrangThai == 2 ? "Đang giao hàng" : "Đã hủy")), x.DonThanhCong, x.DonChuaTT, x.DonHuy, x.DangGiao, x.DonThanhCong + x.DonChuaTT + x.DangGiao + x.DonHuy);
            }

            //Tổng tiền
            int sum = 0, sumdanggiao = 0, sumdonhuy = 0, sumchuathanhtoan = 0, sumdonthanhcong = 0;
            for (int i = 0; i < dgrid_Hd.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dgrid_Hd.Rows[i].Cells[8].Value);
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã thanh toán")
                {
                    sumdonthanhcong += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Chưa thanh toán")
                {
                    sumchuathanhtoan += 1;
                }

                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đang giao hàng")
                {
                    sumdanggiao += 1;
                }
                if (dgrid_Hd.Rows[i].Cells[9].Value.ToString() == "Đã hủy")
                {
                    sumdonhuy += 1;
                }


            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            double tt = Convert.ToDouble(sum);
            lbl_tongtien.Text = Convert.ToInt32(tt).ToString("#,###", cul.NumberFormat);
            lbl_DangGiao.Text = Convert.ToString(sumdanggiao);
            labl_sodonthanhcong.Text = Convert.ToString(sumdonthanhcong);
            lbl_chuathanhtoan.Text = Convert.ToString(sumchuathanhtoan);
            lbl_huydon.Text = Convert.ToString(sumdonhuy);
            lbl_counthd.Text = Convert.ToString(sumdanggiao + sumdonthanhcong + sumchuathanhtoan - sumdonhuy);




            // lấy doanh thu và tháng
            double dt1 = 0;
            for (int i = 0; i < dgrid_t1.RowCount; i++)
            {
                dt1 += Convert.ToDouble(dgrid_t1.Rows[i].Cells[8].Value);
                

            }
            lbl_dt1.Text = dt1.ToString();
            //MessageBox.Show(lbl_dt1.Text);
            double[] lstTT1 = new double[1] { Convert.ToDouble(lbl_dt1.Text) };
            CultureInfo cul2 = CultureInfo.GetCultureInfo("vi-VN");
            double tt2 = Convert.ToDouble(dt1.ToString());
            lbl_dt1.Text = Convert.ToInt32(tt2).ToString("#,###", cul2.NumberFormat);

            double dt2 = 0;
            for (int i = 0; i < dgrid_t2.RowCount; i++)
            {
                dt2 += Convert.ToDouble(dgrid_t2.Rows[i].Cells[8].Value);


            }
            lbl_dt2.Text = dt2.ToString();
            //MessageBox.Show(lbl_dt2.Text);
            double[] lstTT2 = new double[1] { Convert.ToDouble(lbl_dt2.Text) };

            CultureInfo cul1 = CultureInfo.GetCultureInfo("vi-VN");
            double tt1 = Convert.ToDouble(dt2.ToString());
            lbl_dt2.Text = Convert.ToInt32(tt1).ToString("#,###", cul1.NumberFormat);

            //// MessageBox.Show("tong" +tongtien.ToString());
            double[] y1 = { 1 };
            double[] y2 = { 2 };
            //double[] x = { 24, 33 };


            //plot data
            zg_ss.GraphPane.AddBar(dtp_n1ss.Value.ToString("MM-dd-yyyy"), y1, lstTT1, Color.Blue);
            zg_ss.GraphPane.AddBar(dtp_n2ss.Value.ToString("MM-dd-yyyy"), y2, lstTT2, Color.OrangeRed);

            //maxmin
            zg_ss.GraphPane.XAxis.Scale.Min = 0;
            //zg_ss.GraphPane.XAxis.Scale.Max = Convert.ToDouble(lbl_dt2.Text);
            zg_ss.GraphPane.YAxis.Scale.Max = 3;
            zg_ss.GraphPane.YAxis.Scale.Min = 0;

            zg_ss.GraphPane.Title.Text = "Bảng so sánh doanh thu";
            zg_ss.GraphPane.XAxis.Title.Text = "Tháng";
            zg_ss.GraphPane.YAxis.Title.Text = "Doanh thu (VND)";

            //Updtae display
            zg_ss.GraphPane.XAxis.ResetAutoScale(zg_ss.GraphPane, CreateGraphics());
            zg_ss.GraphPane.YAxis.ResetAutoScale(zg_ss.GraphPane, CreateGraphics());
            
            zg_ss.Refresh();

        }
        private void btn_ss_Click(object sender, EventArgs e)
        {
            zg_ss.GraphPane.CurveList.Clear();
            lbl_t1.Text = dtp_n1ss.Value.ToString("MM-dd-yyyy");
            lbl_t2.Text = dtp_n2ss.Value.ToString("MM-dd-yyyy");
            soSanh(Convert.ToDateTime(dtp_n1ss.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_n2ss.Value.ToString("MM-dd-yyyy")));
            //zg_ss.Visible = false;
            
        }

        private void dtp_n1ss_ValueChanged(object sender, EventArgs e)
        {
            zg_ss.GraphPane.CurveList.Clear();
            //zg_ss.GraphPane.XAxis.Scale.Min = 0;
            //zg_ss.GraphPane.YAxis.Scale.Max = 10;
            ////zg_ss.GraphPane.GraphObjList.Clear();
            lbl_t1.Text = dtp_n1ss.Value.ToString("MM-dd-yyyy");
            lbl_t2.Text = dtp_n2ss.Value.ToString("MM-dd-yyyy");
            soSanh(Convert.ToDateTime(dtp_n1ss.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_n2ss.Value.ToString("MM-dd-yyyy")));
        }

        private void dtp_n2ss_ValueChanged(object sender, EventArgs e)
        {
            zg_ss.GraphPane.CurveList.Clear();
            //zg_ss.GraphPane.XAxis.Scale.Min = 0;
            //zg_ss.GraphPane.YAxis.Scale.Max = 10;
            //// zg_ss.GraphPane.GraphObjList.Clear();
            lbl_t1.Text = dtp_n1ss.Value.ToString("MM-dd-yyyy");
            lbl_t2.Text = dtp_n2ss.Value.ToString("MM-dd-yyyy");
            soSanh(Convert.ToDateTime(dtp_n1ss.Value.ToString("MM-dd-yyyy")), Convert.ToDateTime(dtp_n2ss.Value.ToString("MM-dd-yyyy")));
        }


    }
}
