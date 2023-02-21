using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces
{
    public partial class closeForm : Form
    {
        public static int sendData;
       
        
        public closeForm()
        {
            InitializeComponent();
        }

        private void closeForm_Load(object sender, EventArgs e)
        {
            sendData = 0;
        }
        
        private void btnYes_Click(object sender, EventArgs e)
        {
            
            sendData = 1;
            this.Close();

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            
            sendData = 2;
            this.Close();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sendData = 2;
            this.Close();
        }

        //Draggable Form
        private Point _mouseLoc;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void closeForm_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }

        private void closeForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        //////////////
    }
}
