
namespace BossKey
{
    partial class PasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(116, 40);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 0;
            this.btn_submit.Text = "提交";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入密码：";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(102, 12);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '#';
            this.txt_password.Size = new System.Drawing.Size(180, 21);
            this.txt_password.TabIndex = 2;
            // 
            // PasswordForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 73);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入密码";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.Shown += new System.EventHandler(this.PasswordForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_password;
    }
}