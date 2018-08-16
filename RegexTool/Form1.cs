using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string str =txtContent.Text;
            string msg, rex;
            Match m;
            msg = txtContent.Text.Trim();
            rex = @txtRegex.Text.Trim();
            m = Regex.Match(msg, rex);

            WriteGroupInfo(m);
        }
        private  void WriteGroupInfo(Match m)
        {
            lstResult.Items.Clear();
            if (m.Success)
            {
                var g = m.Groups;
                if (g.Count > 0)
                {
                    lstResult.Items.Add("序号     匹配值");
                    for (var i = 0; i < g.Count; i++)
                    {
                        lstResult.Items.Add(i + ":     " + g[i].Value);// Environment.NewLine;
                    }
                }
            }
            else
            {
                lstResult.Items.Add("匹配失败");
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtContent.Text = "建筑：长沙市口腔医院，在15日产生以下报警：2#空调主机未关，请及时处理。";
            txtRegex.Text = "(.*建筑：)(.*)，在([0-9]{1,})日产生以下报警：(.*)，请及时处理。";
        }
    }
}
