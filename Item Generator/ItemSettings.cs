using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Item_Generator
{
    public partial class ItemProperties : Form
    {
        public ItemProperties()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateItem.name = name.Text;
            CreateItem.id = Id.Text;
            CreateItem.file = textureFile.Text;
            CreateItem.index = index.Text;
            CreateItem.remotetexture = RemoteTexture.Text;
            CreateItem.tier = Tier.Text;
            CreateItem.itemtype = ItemType.Text;
            CreateItem.Execute();
        }

        private void TriggerTexture_Click(object sender, EventArgs e)
        {
            if (TriggerTexture.Text == "Client")
            {
                TriggerTexture.Text = "Remote";
                index.Visible = true;
                textureFile.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                RemoteTexture.Visible = false;
                CreateItem.remote = false;
            }
            else
            {
                TriggerTexture.Text = "Client";
                index.Visible = false;
                textureFile.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = true;
                RemoteTexture.Visible = true;
                CreateItem.remote = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RemoteTexture_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
