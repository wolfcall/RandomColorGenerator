using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace RandomColorGenerator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e) {
            if(colorDialog1.ShowDialog() == DialogResult.OK) {
                string rgb = "";
                rgb += convertToHex(colorDialog1.Color.R,2);
                rgb += convertToHex(colorDialog1.Color.G,2);
                rgb += convertToHex(colorDialog1.Color.B,2);
                lstColors.Items.Add(rgb);
            }
        }

        private string convertToHex(int value, int length) {
            ArrayList number = new ArrayList();
            while(value > 0) {
                number.Add(value % 16);
                value = value / 16;
            }
            string result = "";
            while(number.Count < length) {
                number.Add(0);
            }
            while(number.Count > 0) {
                int tmp = (int)number[number.Count - 1];
                switch (tmp) {
                    case 0:
                        result += "0";
                        break;
                    case 1:
                        result += "1";
                        break;
                    case 2:
                        result += "2";
                        break;
                    case 3:
                        result += "3";
                        break;
                    case 4:
                        result += "4";
                        break;
                    case 5:
                        result += "5";
                        break;
                    case 6:
                        result += "6";
                        break;
                    case 7:
                        result += "7";
                        break;
                    case 8:
                        result += "8";
                        break;
                    case 9:
                        result += "9";
                        break;
                    case 10:
                        result += "A";
                        break;
                    case 11:
                        result += "B";
                        break;
                    case 12:
                        result += "C";
                        break;
                    case 13:
                        result += "D";
                        break;
                    case 14:
                        result += "E";
                        break;
                    case 15:
                        result += "F";
                        break;
                }
                number.RemoveAt(number.Count - 1);
            }

            return result;
        }

        private void btnRandom_Click(object sender, EventArgs e) {
            Random ran = new Random();
            string rgb = "";
            rgb += convertToHex(ran.Next(16777216),6);
            lstColors.Items.Add(rgb);
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            Random ran = new Random();
            Bitmap randomImg = new Bitmap(200, 200);

            for (int x = 0; x < randomImg.Width; x++) {
                for(int y = 0; y < randomImg.Height; y++) {
                    int rint = ran.Next(lstColors.Items.Count);
                    Color pix = convertToColor(lstColors.Items[rint].ToString());
                    randomImg.SetPixel(x, y, pix);
                }
            }

            randomImg.Save("GeneratedImage.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private Color convertToColor(string hex) {
            int[] rgb = new int[3];
            for(int x = hex.Length - 1; x >= 0; x = x - 2) {
                rgb[x / 2] = (hexToDec(hex[x - 1]) * 16) + hexToDec(hex[x]);
            }

            return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

        private int hexToDec(char digit) {
            int dec = 0;
            switch (digit) {
                case '0':
                    dec = 0;
                    break;
                case '1':
                    dec = 1;
                    break;
                case '2':
                    dec = 2;
                    break;
                case '3':
                    dec = 3;
                    break;
                case '4':
                    dec = 4;
                    break;
                case '5':
                    dec = 5;
                    break;
                case '6':
                    dec = 6;
                    break;
                case '7':
                    dec = 7;
                    break;
                case '8':
                    dec = 8;
                    break;
                case '9':
                    dec = 9;
                    break;
                case 'A':
                    dec = 10;
                    break;
                case 'B':
                    dec = 11;
                    break;
                case 'C':
                    dec = 12;
                    break;
                case 'D':
                    dec = 13;
                    break;
                case 'E':
                    dec = 14;
                    break;
                case 'F':
                    dec = 15;
                    break;
            }
            return dec;
        }
    }
}
