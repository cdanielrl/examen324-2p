using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClasificarColor
{
    public partial class ColorDetectForm : Form
    {
        Color actualColor;
        public ColorDetectForm()
        {
            InitializeComponent();
            actualColor = panelSelectedColor.BackColor;
        }

        private void ChooseImageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ImagePathLbl.Text = "";
                pictureBox1.Image = null;

                DialogResult IsFileChosen = openFileDialog1.ShowDialog();

                if (IsFileChosen == System.Windows.Forms.DialogResult.OK)
                {
                    ImagePathLbl.Text = openFileDialog1.FileName;

                    if (openFileDialog1.ValidateNames == true)
                    {
                        pictureBox1.Image = Image.FromFile(ImagePathLbl.Text);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void PickColorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedColorNameLbl.Text = "";
                panelSelectedColor.BackColor = actualColor;

                DialogResult IsColorChosen = colorDialog1.ShowDialog();

                if (IsColorChosen == System.Windows.Forms.DialogResult.OK)
                {
                    panelSelectedColor.BackColor = colorDialog1.Color;

                    if (colorDialog1.Color.IsKnownColor == true)
                    {
                        SelectedColorNameLbl.Text = colorDialog1.Color.ToKnownColor().ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void DetectColorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean IsColorFound = false;

                if (pictureBox1.Image != null)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Image);

                    for (int i = 0; i < pictureBox1.Image.Height; i++)
                    {
                        for (int j = 0; j < pictureBox1.Image.Width; j++)
                        {
                            Color now_color = bmp.GetPixel(j, i);

                            if (now_color.ToArgb() == colorDialog1.Color.ToArgb())
                            {
                                IsColorFound = true;
                                //MessageBox.Show("Color detectado");
                                bmp.SetPixel(j, i. Color.Pink);
                            }
                        }
                        if (IsColorFound == true)
                        {
                            break;
                        }
                    }

                    if (IsColorFound == false)
                    {
                        MessageBox.Show("Color no encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Imagen no cargada");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
