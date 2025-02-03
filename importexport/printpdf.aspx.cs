using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class importexport_printpdf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // SPREADの設定
        InitSpread(FpSpread1);

        // シートの設定
        InitSpreadStyles(FpSpread1.Sheets[0]);

        // 選択リストの設定
        InitList();
    }

    private void InitSpread(FarPoint.Web.Spread.FpSpread spread)
    {
        spread.CssClass = "spreadStyle";
        spread.UseClipboard = false;

        // データ連結
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(MapPath("../App_Data/data50.xml"));
        spread.DataSource = ds;
    }

    private void InitSpreadStyles(FarPoint.Web.Spread.SheetView sheet)
    {
        // フォントサイズの設定
        sheet.DefaultStyle.Font.Size = FontUnit.Point(10);
        sheet.ColumnHeader.DefaultStyle.Font.Size = FontUnit.Point(10);
        sheet.RowHeader.DefaultStyle.Font.Size = FontUnit.Point(10);
        sheet.SheetCorner.DefaultStyle.Font.Size = FontUnit.Point(10);

        // 列幅の設定
        sheet.Columns[0].Width = 45;
        sheet.Columns[1].Width = 110;
        sheet.Columns[2].Width = 110;
        sheet.Columns[3].Width = 100;
        sheet.Columns[4].Width = 50;
        sheet.Columns[5].Width = 50;
        sheet.Columns[6].Width = 50;
        sheet.Columns[7].Width = 100;
        sheet.Columns[8].Width = 240;

        // 縦方向の揃え位置を中央に設定
        sheet.DefaultStyle.VerticalAlign = VerticalAlign.Middle;
        
        FarPoint.Web.Spread.PrintInfo pi = new FarPoint.Web.Spread.PrintInfo();
        
        //ヘッダに「カラー」「イメージ」を設定します
        pi.Colors = new System.Drawing.Color[] { System.Drawing.Color.Purple, System.Drawing.Color.Green, System.Drawing.Color.Indigo };
        pi.Images = new System.Drawing.Image[] { System.Drawing.Image.FromFile(MapPath("~/images/MESCIUS_Logo.png")) };
        pi.Header = "/c/fz\"20\"/cl\"0\"/fb1/fu0/fi1 SPREAD for ASP.NET";
        pi.Footer = "/fn\"Arial\"/fz\"10\"/cl\"1\"/fb0/fu0/fi0/dl /ds /tl "
                     + "/c/fn\"Arial\"/fz\"10\"/cl\"2\"/p///pc Page /r/fn\"Times New Roman\"/fz\"14\"/cl\"1\"/fb1/fu0/fi1/g\"0\"";
        
        pi.ShowColor = true;
        pi.Centering = FarPoint.Web.Spread.Centering.Horizontal;

        // マージンの設定
        pi.Margin.Top = 20;
        pi.Margin.Left = 30;
        pi.Margin.Right = 30;
        pi.Margin.Bottom = 20;
        pi.Margin.Footer = 20;
        pi.Margin.Header = 20;

        //定義したPrintInfoオブジェクトを設定します
        sheet.PrintInfo = pi;
    }

    private void InitList()
    {
        for (int i = 0; i < FpSpread1.ActiveSheetView.RowCount; i++)
        {
            DDLstartrowidx.Items.Add(Convert.ToString(i));
        }

        for (int i = 1; i < FpSpread1.ActiveSheetView.RowCount + 1; i++)
        {
            DDLrowcnt.Items.Add(Convert.ToString(i));
        }

        for (int i = 0; i < FpSpread1.ActiveSheetView.ColumnCount; i++)
        {
            DDLstartcolidx.Items.Add(Convert.ToString(i));
        }
        for (int i = 1; i < FpSpread1.ActiveSheetView.ColumnCount + 1; i++)
        {
            DDLcolcnt.Items.Add(Convert.ToString(i));
        }

        DDLrowcnt.SelectedValue = FpSpread1.ActiveSheetView.RowCount.ToString();
        DDLcolcnt.SelectedValue = FpSpread1.ActiveSheetView.ColumnCount.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();

        int rowidx = Convert.ToInt16(DDLstartrowidx.SelectedValue);
        int colidx = Convert.ToInt16(DDLstartcolidx.SelectedValue);
        int rowcnt = Convert.ToInt16(DDLrowcnt.SelectedValue);
        int colcnt = Convert.ToInt16(DDLcolcnt.SelectedValue);

        FpSpread1.ActiveSheetView.PrintInfo.PrintType = FarPoint.Web.Spread.PrintType.CellRange;

        FpSpread1.ActiveSheetView.PrintInfo.RowStart = rowidx;
        FpSpread1.ActiveSheetView.PrintInfo.RowEnd = rowidx + rowcnt - 1;
        FpSpread1.ActiveSheetView.PrintInfo.ColStart = colidx;
        FpSpread1.ActiveSheetView.PrintInfo.ColEnd = colidx + colcnt - 1;

        FpSpread1.SavePdfToResponse("spread.pdf");
    }
}