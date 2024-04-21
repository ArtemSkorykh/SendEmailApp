using System.Net.Mail;

namespace SendEmailApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient mailServer = new SmtpClient(textBox3.Text, Convert.ToInt32(textBox4.Text));
                mailServer.EnableSsl = true;

                mailServer.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text);

                string from = textBox1.Text;
                string to = textBox5.Text;
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = textBox6.Text;
                msg.Body = textBox7.Text;
                foreach (var item in listBox1.Items)
                {
                    msg.Attachments.Add(new Attachment(item.ToString()));
                }

                mailServer.Send(msg);

                MessageBox.Show("Message was delivered successfully!");
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                listBox1.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send email. Error : " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                listBox1.Items.Add(sFileName);
            }
        }
    }
}
