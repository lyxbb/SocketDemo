namespace SocketDemo
{
    partial class SocketForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_connnect = new System.Windows.Forms.Button();
            this.lb_port = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.lb_Ip = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_connnect);
            this.panel1.Controls.Add(this.lb_port);
            this.panel1.Controls.Add(this.tb_port);
            this.panel1.Controls.Add(this.lb_Ip);
            this.panel1.Controls.Add(this.tb_ip);
            this.panel1.Location = new System.Drawing.Point(21, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 70);
            this.panel1.TabIndex = 0;
            // 
            // bt_connnect
            // 
            this.bt_connnect.Location = new System.Drawing.Point(316, 15);
            this.bt_connnect.Name = "bt_connnect";
            this.bt_connnect.Size = new System.Drawing.Size(132, 42);
            this.bt_connnect.TabIndex = 4;
            this.bt_connnect.Text = "开始监听";
            this.bt_connnect.UseVisualStyleBackColor = true;
            this.bt_connnect.Click += new System.EventHandler(this.bt_connnect_Click);
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(158, 24);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(35, 12);
            this.lb_port.TabIndex = 3;
            this.lb_port.Text = "Port:";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(199, 21);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 2;
            this.tb_port.Text = "80";
            // 
            // lb_Ip
            // 
            this.lb_Ip.AutoSize = true;
            this.lb_Ip.Location = new System.Drawing.Point(15, 21);
            this.lb_Ip.Name = "lb_Ip";
            this.lb_Ip.Size = new System.Drawing.Size(23, 12);
            this.lb_Ip.TabIndex = 1;
            this.lb_Ip.Text = "IP:";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(44, 18);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_ip.TabIndex = 0;
            this.tb_ip.Text = "127.0.0.1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(21, 112);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(580, 124);
            this.listBox1.TabIndex = 1;
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(21, 255);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(424, 73);
            this.txt_msg.TabIndex = 2;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(471, 266);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(119, 52);
            this.bt_send.TabIndex = 3;
            this.bt_send.Text = "发送";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // SocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 340);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Name = "SocketForm";
            this.Text = "SocketForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_connnect;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label lb_Ip;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Button bt_send;
    }
}