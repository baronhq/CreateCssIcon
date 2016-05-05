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

namespace CreateCssIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dir = label2.Text;
            IEnumerable<string> files = Directory.GetFiles(dir, "*.png", SearchOption.AllDirectories);
            List<string> fileCss = new List<string>();
            foreach (var file in files)
            {
                string[] paths = file.Substring(file.IndexOf("icon"), file.Length - file.IndexOf("icon")).Split('\\');
                string css1 = ".";
                for (int i = 0; i < paths.Length; i++)
                {
                    if (i == 0)
                    {
                        css1 += paths[i];
                    }
                    else if (i == paths.Length - 1)
                    {
                        css1 += "-" + paths[i].Substring(0, paths[i].IndexOf("."));
                    }
                    else
                    {
                        css1 += "-" + paths[i];
                    }
                }
                css1 += "{ background-image: url(../image/";
                for (int i = 0; i < paths.Length; i++)
                {
                    if (i == 0)
                    {
                        css1 += paths[i];
                    }
                    else
                    {
                        css1 += "/" + paths[i];
                    }
                }
                css1 += ") !important;}";
                fileCss.Add(css1);
                //fileCss.Add();
                //FileInfo fi = new FileInfo(file);
                //File.Move(file, file.Substring(0, file.LastIndexOf(".")) + ".jsp");
            }
            string cssFileName = dir + ".css";
            if (File.Exists(cssFileName))
            {
                MessageBox.Show("存在此文件!");
            }
            else
            {
                FileStream myFs = new FileStream(cssFileName, FileMode.Create);
                StreamWriter mySw = new StreamWriter(myFs);
                mySw.Write(".icon{    width: 16px;    height: 16px;    background-repeat: no-repeat;    background-position: center 50%;    vertical-align: middle !important;}");
                foreach (string item in fileCss)
                {
                    mySw.Write(item);
                }
                mySw.Close();
                myFs.Close();
                MessageBox.Show("写入成功：" + files.Count().ToString() + "个文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }
}
