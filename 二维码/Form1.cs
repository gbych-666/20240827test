using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace 二维码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qrData = "";
            qrData = "" + textBox1.Text;
            pictureBox1.Image = ZXingLibs.GetQRCode(qrData, pictureBox1.Width, pictureBox1.Height);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1.设置QR二维码的规格
            ZXing.QrCode.QrCodeEncodingOptions qrEncodeOption = new ZXing.QrCode.QrCodeEncodingOptions();
            qrEncodeOption.CharacterSet = "UTF-8"; // 设置编码格式，否则读取'中文'乱码
            qrEncodeOption.Height = pictureBox1.Height;//设置高度
            qrEncodeOption.Width = pictureBox1.Width; //设置宽度
            qrEncodeOption.Margin = 1;  // 设置周围空白边距

            // 2.生成条形码图片并保存
            ZXing.BarcodeWriter Qr = new BarcodeWriter();
            Qr.Format = BarcodeFormat.QR_CODE; // 二维码
            Qr.Options = qrEncodeOption;
            Bitmap img = Qr.Write(textBox1.Text);//"textBox1"就是用来输入数据内容的控件
            pictureBox1.Image = img;

        }
    }
}
