using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecodation_Hafiza_Oyunu
{
    public partial class Form1 : Form
    {
        Image defult_foto = Properties.Resources.bomb;

        Image[] resimler = 
            {
                 Properties.Resources.number_one,
                 Properties.Resources.number_2,
                 Properties.Resources.number_3,
                 Properties.Resources.number_four,
                 Properties.Resources.number_5,
                 Properties.Resources.six,
                 Properties.Resources.seven,
            };
        int[] indeks = {0,0,1,1,2,2,3,3,4,4,5,5,6,6 };
        int sayac = 0;
        bool once_tiklanan_varmi=false;
        Button once_tiklanan_buton;
        int once_tiklanan_buton_id;

        public void resimleri_karistir()
        {
            Random r = new Random();
            for (int i = 0; i < indeks.Length; i++)
            {
                int j = r.Next(14);
                int tutucu = indeks[i];
                indeks[i] = indeks[j];
                indeks[j] = tutucu;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimleri_karistir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayac++;
            label1.Text = Convert.ToString(sayac);
            Button click_edilen_buton = (Button)sender;
            int button_id = Convert.ToInt32(click_edilen_buton.Name.Substring(6))-1;

            if (once_tiklanan_varmi==false)
            {
                click_edilen_buton.Image = resimler[indeks[button_id]];
                once_tiklanan_varmi = true;
                click_edilen_buton.Enabled = false;
                once_tiklanan_buton = click_edilen_buton;
                once_tiklanan_buton_id = button_id;
            }
            else
            {
                click_edilen_buton.Image = resimler[indeks[button_id]];
                once_tiklanan_varmi = false;
                click_edilen_buton.Enabled = false;
                if (click_edilen_buton.Image!=once_tiklanan_buton.Image)
                {
                    System.Threading.Thread.Sleep(1000); //Resim 1 Saniye Kalıyor Görmemiz İçin Sonra Aşağıya Geçiyoruz

                    click_edilen_buton.Image = defult_foto;
                    once_tiklanan_buton.Image = defult_foto;
                    once_tiklanan_buton.Enabled = true;
                    click_edilen_buton.Enabled = true;
                }
            }
        }
    }
}
