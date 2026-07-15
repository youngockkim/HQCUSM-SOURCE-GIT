//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmConfirmTransactionAlarm.cs
//   Description :
//
//   MES Version : 4.2.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-01-14 : Created by Aiden
//
//
//   Copyright(C) 1998-2008 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public partial class frmConfirmTransactionAlarm : Miracom.MESCore.TranForm02
    {
        public frmConfirmTransactionAlarm()
        {
            InitializeComponent();
        }

        #region " Variable Definition "

        #endregion

        #region " Function Definition "

        public void SetCondition(string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_lot_id, string s_event_id, string s_res_id)
        {
            txtMatID.Text = s_mat_id;
            txtMatVer.Text = i_mat_ver.ToString();
            txtFlow.Text = s_flow;
            txtOper.Text = s_oper;
            txtLotID.Text = s_lot_id;
            txtResID.Text = s_res_id;
            txtEventID.Text = s_event_id;
        }

        public void SetMessage(TRSNode alarm_out)
        {
            int i;
            int ii;
            String s_tmp;
            FontFamily ff_msg_font_family;
            float f_font_size;

            byte[] bt_buffer;

            ff_msg_font_family = txtMessage.Font.FontFamily;
            f_font_size = txtMessage.Font.Size;

            txtHoldCode.Text = "";
            txtHoldStatus.Text = "";
            txtMessage.ReadOnly = false;

            for (i = 0; i < alarm_out.GetList(0).Count; i++)
            {
                if (alarm_out.GetList(0)[i].GetChar("NEED_CONFIRM_FLAG") != 'Y')
                {
                    continue;
                }

                txtMessage.SelectionFont = new Font(ff_msg_font_family, f_font_size + 3, FontStyle.Bold);
                txtMessage.SelectionStart = txtMessage.Text.Length;
                s_tmp = alarm_out.GetList(0)[i].GetString("ALARM_ID") + " (" + alarm_out.GetList(0)[i].GetString("ALARM_DESC") + ")\n";
                txtMessage.AppendText(s_tmp);
                txtMessage.SelectionLength = s_tmp.Length;

                txtMessage.SelectionIndent = 10;
                txtMessage.SelectionHangingIndent = 20;
                txtMessage.SelectionFont = new Font(ff_msg_font_family, f_font_size, FontStyle.Bold);
                txtMessage.SelectionStart = txtMessage.Text.Length;
                s_tmp = "Subject : " + alarm_out.GetList(0)[i].GetString("ALARM_SUBJECT") + "\n";
                txtMessage.AppendText(s_tmp);
                txtMessage.SelectionLength = s_tmp.Length;

                txtMessage.SelectionIndent = 20;
                txtMessage.SelectionHangingIndent = 20;
                txtMessage.SelectionFont = new Font(ff_msg_font_family, f_font_size, FontStyle.Regular);
                txtMessage.SelectionStart = txtMessage.Text.Length;
                s_tmp = alarm_out.GetList(0)[i].GetString("ALARM_MSG") + "\n";
                txtMessage.AppendText(s_tmp);
                txtMessage.SelectionLength = s_tmp.Length;

                s_tmp = "";
                if (alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_1") != "")
                {
                    s_tmp += alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_1");
                }
                if (alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_2") != "")
                {
                    if (s_tmp.Length > 0)
                    {
                        s_tmp += "\n";
                    }
                    s_tmp += alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_2");
                }
                if (alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_3") != "")
                {
                    if (s_tmp.Length > 0)
                    {
                        s_tmp += "\n";
                    }
                    s_tmp += alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_3");
                }
                if (alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_4") != "")
                {
                    if (s_tmp.Length > 0)
                    {
                        s_tmp += "\n";
                    }
                    s_tmp += alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_4");
                }
                if (alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_5") != "")
                {
                    if (s_tmp.Length > 0)
                    {
                        s_tmp += "\n";
                    }
                    s_tmp += alarm_out.GetList(0)[i].GetString("ALARM_COMMENT_5");
                }

                if (s_tmp.Length > 0)
                {
                    txtMessage.SelectionIndent = 20;
                    txtMessage.SelectionHangingIndent = 20;
                    txtMessage.SelectionFont = new Font(ff_msg_font_family, f_font_size, FontStyle.Regular);
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                    s_tmp = "\n" + s_tmp + "\n";
                    txtMessage.AppendText(s_tmp);
                    txtMessage.SelectionLength = s_tmp.Length;
                }

                if (alarm_out.GetList(0)[i].GetString("HOLD_CODE") != "")
                {
                    txtMessage.SelectionIndent = 10;
                    txtMessage.SelectionHangingIndent = 20;
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                    txtMessage.SelectionFont = new Font(ff_msg_font_family, f_font_size, FontStyle.Regular);

                    if (alarm_out.GetList(0)[i].GetChar("PROCESSED_HOLD_FLAG") == 'R')
                    {
                        s_tmp = "Release Code : " + alarm_out.GetList(0)[i].GetString("RELEASE_CODE") + "\n";

                        if (txtHoldCode.Text == "")
                        {
                            for (ii = i + 1; ii < alarm_out.GetList(0).Count; ii++)
                            {
                                if (alarm_out.GetList(0)[i].GetString("HOLD_CODE") != "" && alarm_out.GetList(0)[ii].GetChar("PROCESSED_HOLD_FLAG") != 'R')
                                {
                                    break;
                                }
                            }
                            if (ii == alarm_out.GetList(0).Count)
                            {
                                lblHoldStatus.Text = "Hold Status";
                                lblHoldCode.Text = "Hold Code";

                                txtHoldStatus.Text = "Done";
                                txtHoldCode.Text = alarm_out.GetList(0)[i].GetString("HOLD_CODE");
                            }
                        }
                    }
                    else
                    {
                        s_tmp = "Hold Code : " + alarm_out.GetList(0)[i].GetString("HOLD_CODE") + "\n";

                        if (txtHoldCode.Text == "")
                        {
                            lblHoldStatus.Text = "Hold Status";
                            lblHoldCode.Text = "Hold Code";

                            switch (alarm_out.GetList(0)[i].GetChar("PROCESSED_HOLD_FLAG"))
                            {
                                case 'C':
                                    txtHoldStatus.Text = "Will be Hold";
                                    break;
                                case 'Y':
                                    txtHoldStatus.Text = "Holding";
                                    break;
                            }
                            txtHoldCode.Text = alarm_out.GetList(0)[i].GetString("HOLD_CODE");
                        }
                    }
                    txtMessage.AppendText(s_tmp);
                    txtMessage.SelectionLength = s_tmp.Length;
                }

                if (alarm_out.GetList(0)[i].GetString("RWK_CODE") != "")
                {
                    txtMessage.SelectionIndent = 10;
                    txtMessage.SelectionHangingIndent = 20;
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                    txtMessage.SelectionFont = new Font(ff_msg_font_family, f_font_size, FontStyle.Regular);

                    s_tmp = "Rework Code : " + alarm_out.GetList(0)[i].GetString("RWK_CODE") + "\n";

                    if (alarm_out.GetList(0)[i].GetChar("PROCESSED_REWORK_FLAG") == 'Y')
                    {
                        if (txtHoldCode.Text == "")
                        {
                            lblHoldStatus.Text = "Rwk Status";
                            lblHoldCode.Text = "Rwk Code";

                            txtHoldStatus.Text = "Done";
                            txtHoldCode.Text = alarm_out.GetList(0)[i].GetString("RWK_CODE");
                        }
                    }
                    else
                    {
                        if (txtHoldCode.Text == "")
                        {
                            lblHoldStatus.Text = "Rwk Status";
                            lblHoldCode.Text = "Rwk Code";

                            switch (alarm_out.GetList(0)[i].GetChar("PROCESSED_REWORK_FLAG"))
                            {
                                case 'C':
                                    txtHoldStatus.Text = "Will be Rework";
                                    break;
                                case 'R':
                                    txtHoldStatus.Text = "Reworking";
                                    break;
                            }
                            txtHoldCode.Text = alarm_out.GetList(0)[i].GetString("RWK_CODE");
                        }
                    }
                    txtMessage.AppendText(s_tmp);
                    txtMessage.SelectionLength = s_tmp.Length;
                }

                if (alarm_out.GetList(0)[i].GetString("AFTER_EVENT_ID") != "")
                {
                    txtMessage.SelectionIndent = 10;
                    txtMessage.SelectionHangingIndent = 20;
                    txtMessage.SelectionFont = new Font(ff_msg_font_family, f_font_size, FontStyle.Regular);
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                    s_tmp = "Event ID : " + alarm_out.GetList(0)[i].GetString("AFTER_EVENT_ID");
                    if (alarm_out.GetList(0)[i].GetChar("PROCESSED_EVENT_FLAG") == 'C')
                    {
                        s_tmp += " (Will be Happen)\n";
                    }
                    else if (alarm_out.GetList(0)[i].GetChar("PROCESSED_EVENT_FLAG") == 'Y')
                    {
                        s_tmp += " (Done)\n";
                    }
                    else
                    {
                        s_tmp += "\n";
                    }
                    txtMessage.AppendText(s_tmp);
                    txtMessage.SelectionLength = s_tmp.Length;

                }

                txtMessage.AppendText("\n");

                if ((bt_buffer = alarm_out.GetList(0)[i].GetBlob("IMAGE_DATA")) != null)
                {
                    MemoryStream ms_buffer;
                    Image img;

                    try
                    {
                        bt_buffer = ResizeImageFile(bt_buffer, 500);

                        ms_buffer = new MemoryStream();
                        ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                        ms_buffer.Position = 0;

                        img = Image.FromStream(ms_buffer);

                        Clipboard.Clear();
                        Clipboard.SetImage(img);
                        txtMessage.Paste();

                        txtMessage.AppendText("\n");
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                }
            }

            txtMessage.ReadOnly = true;
        }

        private byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            Image original = Image.FromStream(new MemoryStream(imageFile));
            int targetH, targetW;
            if (original.Height > original.Width)
            {
                targetH = targetSize;
                targetW = (int)(original.Width * ((float)targetSize / (float)original.Height));
            }
            else
            {
                targetW = targetSize;
                targetH = (int)(original.Height * ((float)targetSize / (float)original.Width));
            }
            Image imgPhoto = Image.FromStream(new MemoryStream(imageFile));
            // Create a new blank canvas.  The resized image will be drawn on this canvas.
            Bitmap bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
            // Save out to memory and then to a file.  We dispose of all objects to make sure the files don't stay locked.
            MemoryStream mm = new MemoryStream();
            bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg);
            original.Dispose();
            imgPhoto.Dispose();
            bmPhoto.Dispose();
            grPhoto.Dispose();
            return mm.GetBuffer();
        }

        #endregion

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

}
