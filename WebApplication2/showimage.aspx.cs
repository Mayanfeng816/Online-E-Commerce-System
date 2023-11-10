using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using WebApplication2.EleServiceReference;

namespace WebApplication2
{
    public partial class showimage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["goodId"] == null) return;
            string goodId = Request["goodId"].ToString();
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            string[] photolist = ws1.GetGoodPhotoInfo(goodId).ToArray();
            if (photolist == null) return;
            string photostring = photolist[0];
            try
            {//将图片字符串转成Byte
                byte[] photobyte = Convert.FromBase64String(photostring);
                if (photobyte != null && photobyte.Length > 100)
                    Response.BinaryWrite(photobyte);//输出buffer中的二进制图像流。
                else
                    Draw();
            }
            catch (Exception err)
            {
                Draw();
            }
        }

        void Draw()
        {
            int width = 200;
            int height = 200;
            Bitmap image = new Bitmap(width, height);
            //创建Graphics类对象
            Graphics g = Graphics.FromImage(image);
            //清空图片背景色
            g.Clear(Color.White);
            Color penColor = Color.Blue;
            Font font = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
            Brush brush1 = new SolidBrush(Color.Red);
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);
            g.FillRectangle(brush1, 15, 15, width - 15, height - 15);
            //画图片的边框线
            g.DrawRectangle(new Pen(penColor), 10, 10, image.Width - 10, image.Height - 10);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image thumbImage;
            thumbImage = image.GetThumbnailImage(100, 100, null, System.IntPtr.Zero);
            thumbImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.ClearContent();
            Response.ContentType = "images";
            Response.BinaryWrite(ms.ToArray());
        }
    }
}