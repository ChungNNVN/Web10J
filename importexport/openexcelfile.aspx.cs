using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class importexport_openexcelfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // 初期化
        InitSpread(FpSpread1.Sheets[0]);
    }

    private void InitSpread(FarPoint.Web.Spread.SheetView sheet)
    {
        // SPREAD設定
        FpSpread1.CommandBar.Visible = false;
        FpSpread1.CssClass = "spreadStyle";
        FpSpread1.UseClipboard = false;

        // シート設定
        sheet.PageSize = sheet.RowCount;

        // 縦方向の揃え位置を中央に設定
        sheet.DefaultStyle.VerticalAlign = VerticalAlign.Middle;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();

        bool ret;
        string filepath = Server.MapPath("~/App_Data/");
        string filename;

        if (DropDownList1.SelectedValue == "xls")
        {
            filename = filepath + "spread.xls";
        }
        else
        {
            filename = filepath + "spread.xlsx";
        }

        // Execlファイルよりデータを読み込み
        try
        {
            // Excelファイルからインポート
            ret = FpSpread1.OpenExcel(filename, FarPoint.Excel.ExcelOpenFlags.RowAndColumnHeaders);

            if (ret == false)
            {
                Response.Write("エラー：ファイルを開けません。ファイルパス：" + filepath);
            }
            else
            {
                InitSpread(FpSpread1.Sheets[0]);
            }
        }
        catch (System.Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();

        // Spreadコントロールをクリア
        FpSpread1.Reset();

        // 初期化
        FpSpread1.CommandBar.Visible = false;
        FpSpread1.CssClass = "spreadStyle";
        FpSpread1.UseClipboard = false;
        FarPoint.Web.Spread.SheetView wkSheet = new FarPoint.Web.Spread.SheetView();
        FpSpread1.Sheets.Add(wkSheet);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();

        string filepath = Server.MapPath("~/App_Data/");
        string filename;

        Response.ContentType = "application/VND.ms-excel";

        if (DropDownList1.SelectedValue == "xls")
        {
            Response.AddHeader("Content-Disposition", "attachment;filename=spread.xls");
            filename = filepath + "spread.xls";
        }
        else
        {
            Response.AddHeader("Content-Disposition", "attachment;filename=spread.xlsx");
            filename = filepath + "spread.xlsx";
        }
        
        Response.Flush();
        Response.WriteFile(filename);
        Response.End();
    }
}