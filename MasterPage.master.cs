using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Xml;


public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink1.NavigateUrl = "Default.aspx";
        HyperLink2.NavigateUrl = "Default.aspx";

        //ContentPlaceHolderのIDをページに書き込みます。
        ClientScriptManager cr = Page.ClientScript;
        if (!cr.IsStartupScriptRegistered(this.GetType(), "onLoadScript"))
        {
            string jscript = "<script language='javascript'>";
            jscript += "var cid='" + ContentPlaceHolder1.ClientID + "'; ";
            jscript += "var descid='" + description.ClientID + "'; ";
            jscript += "</script>";
            cr.RegisterStartupScript(this.GetType(), "onLoadScript", jscript);
        }

        if (IsPostBack)
        {
            return;
        }

        this.CreateNode("-", TreeView1.Nodes);

        if (Request.QueryString.GetValues("menuidx") == null)
        {
            demotitlePanel.Visible = false;
        }
        else
        {
            string pagePath = Page.MapPath(Request.Url.AbsolutePath);

            string menuidx = Request.QueryString.GetValues("menuidx")[0];
            TreeView1.FindNode(menuidx).Expand();

            //メニュータイトルを取得
            XmlDocument xmladm = new XmlDocument();
            xmladm.Load(Server.MapPath("~/App_Data/accordion.xml"));
            XmlElement admele;
            admele = xmladm.DocumentElement;
            XmlNodeList admnode;
            admnode = admele.GetElementsByTagName("AccordionMember");

            for (int n = 0; 0 < admnode.Count; n++)
            {
                if (admnode.Item(n).SelectNodes("id").Item(0).InnerText.Equals(menuidx))
                {
                    navLabel1.Text = " > " + Server.HtmlDecode(admnode.Item(n).SelectNodes("menunm").Item(0).InnerText);

                    break;
                }
            }

            //デモタイトルと解説を取得
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/App_Data/demomenu.xml"));
            XmlElement ele;
            ele = xmldoc.DocumentElement;
            XmlNodeList node;
            node = ele.GetElementsByTagName("member");

            string[] abpa = Request.Url.AbsolutePath.Split('/');
            string aspxnm = abpa[abpa.Length - 1];

            for (int n = 0; 0 < node.Count; n++)
            {
                if (node.Item(n).SelectNodes("filenm").Item(0).InnerText.Equals(aspxnm))
                {
                    demotitle.Text = Server.HtmlDecode(node.Item(n).SelectNodes("demotitle").Item(0).InnerText);
                    description.Text = Server.HtmlDecode(node.Item(n).SelectNodes("description").Item(0).InnerText);
                    navLabel2.Text = " > " + Server.HtmlDecode(node.Item(n).SelectNodes("demotitle").Item(0).InnerText);

                    break;
                }
            }
        }

    }

    // 指定されたURL（parent）を親ノードとするノード群をツリーに追加
    private void CreateNode(String parent, TreeNodeCollection nodes)
    {
        XmlDocument xmladm = new XmlDocument();
        xmladm.Load(Server.MapPath("~/App_Data/accordion.xml"));
        XmlElement admele;
        admele = xmladm.DocumentElement;
        XmlNodeList admnode;
        admnode = admele.GetElementsByTagName("AccordionMember");

        //ルートパス取得
        string root = VirtualPathUtility.AppendTrailingSlash(HttpRuntime.AppDomainAppVirtualPath);

        if (parent == "-")
        {
            for (int i = 0; i < (admnode.Count); i++)
            {
                TreeNode tnode = new TreeNode();
                tnode.Text = "&nbsp;" + admnode.Item(i).SelectNodes("menunm").Item(0).InnerText;
                tnode.Value = admnode.Item(i).SelectNodes("id").Item(0).InnerText;
                tnode.SelectAction = TreeNodeSelectAction.Expand;
                this.CreateNode(tnode.Value, tnode.ChildNodes);
                nodes.Add(tnode);
            }
        }
        else
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/App_Data/demomenu.xml"));
            XmlElement ele;
            ele = xmldoc.DocumentElement;
            XmlNodeList node;
            node = ele.GetElementsByTagName("member");

            //member分ループ
            for (int n = 0; n < (node.Count); n++)
            {
                //出力場所分ループ
                for (int idcnt = 0; idcnt < (node.Item(n).SelectNodes("dirid").Count); idcnt++)
                {
                    TreeNode tnode = new TreeNode();

                    if (node.Item(n).SelectNodes("dirid").Item(idcnt).InnerText.Equals(parent))
                    {
                        string dirnm = node.Item(n).SelectNodes("dirnm").Item(0).InnerText;
                        string dirsla;
                        if (!dirnm.Equals(""))
                        {
                            dirsla = "/";
                        }
                        else
                        {
                            dirsla = "";
                        }
                        string filenm = node.Item(n).SelectNodes("filenm").Item(0).InnerText;
                        string menunm = node.Item(n).SelectNodes("menunm").Item(0).InnerText;

                        tnode.Text = menunm;
                        tnode.NavigateUrl = root + dirnm + dirsla + filenm + "?menuidx=" + parent;
                        tnode.Value = menunm;
                        nodes.Add(tnode);

                        break;
                    }
                }
            }
        }
    }
}
