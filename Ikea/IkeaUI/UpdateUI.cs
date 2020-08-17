using Ikea_Library.Helpers;
using IkeaUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkeaProject
{
    public class UpdateUI
    {
        private delegate void UpdateLabelTextDelegate(Label label, string text);
        private delegate void UpdatePictureBoxDelegate(PictureBox pictureBox, bool status);
        private delegate void UpdateTextBoxTextDelegate(TextBox textBox,string text);

        private delegate void UpdateProgressiveBarDelegate(ProgressBar bar,string action);
        public static void UpdateProgressiveBar(ProgressBar bar,string action)
        {
            if (bar.InvokeRequired == true)
            {
                bar.Invoke(new UpdateProgressiveBarDelegate(UpdateProgressiveBar), new object[] { bar,action });
            }
            else
            {
                switch (action)
                {
                    case "step":
                        bar.Step = 1;
                        bar.PerformStep();
                        bar.ForeColor = Colors.Red;
                        break;

                    case "reset":
                        bar.Value = 0;
                        break;
                }
            }
        }


        public static void UpdateTextBoxText(TextBox textBox,string text)
        {
            if (textBox.InvokeRequired == true)
            {
                textBox.Invoke(new UpdateTextBoxTextDelegate(UpdateTextBoxText), new object[] { textBox, text });
            }
            else
            {
                textBox.Text = text;
            }
        }

        public static void UpdateLabelText(Label label, string text)
        {
            if (label.InvokeRequired == true)
            {
                label.Invoke(new UpdateLabelTextDelegate(UpdateLabelText), new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        public static void UpdatePictureBox(PictureBox pictureBox, bool status)
        {
            if (pictureBox.InvokeRequired == true)
            {
                pictureBox.Invoke(new UpdatePictureBoxDelegate(UpdatePictureBox), new object[] { pictureBox, status });
            }
            else
            {
                switch (status)
                {
                    case true:
                        pictureBox.Image = Resources.green;
                        break;

                    case false:
                        pictureBox.Image = Resources.red;
                        break;
                    default:
                        pictureBox.Image = Resources.gray;
                        break;
                }
            }
        }
    }
}
