using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeAspx
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dir = label2.Text;
            IEnumerable<string> files = Directory.GetFiles(dir, "*.aspx", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                //FileInfo fi = new FileInfo(file);
                File.Move(file, file.Substring(0, file.LastIndexOf(".")) + ".jsp");
            }
            MessageBox.Show("修改成功：" + files.Count().ToString() + "个文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //for (int i = 0; i < files.Count; i++)
            //{
            //     FileInfo fi = new FileInfo(file);
            //}
            //GetFiles(foldPath);
        }

        private void GetFiles(string dir)
        {
            IEnumerable<string> files = Directory.GetFiles(dir, "*.aspx", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string exname = file.Substring(file.LastIndexOf(".") + 1);
                if (".aspx".IndexOf(file.Substring(file.LastIndexOf(".") + 1)) > -1)
                {
                    FileInfo fi = new FileInfo(file);
                    list.Add(fi.FullName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                label2.Text = foldPath;
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Multiselect = true;
            ////fileDialog.FileName = "D:软件";
            //fileDialog.Title = "请选择文件";
            ////fileDialog.Filter = "所有文件(*.*)|*.*";
            //fileDialog.InitialDirectory = "c:\\";//获取打开选择框的初始目录;
            //fileDialog.ShowDialog();
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string file = fileDialog.FileName;
            //    MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
    }
}
