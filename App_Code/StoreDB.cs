using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Common;
using System.Collections.Generic;

/// <summary>
/// Summary description for StoreDB
/// </summary>
public struct sProduction
{
    public int ID;
    public string Name;
    public string Price;
    public string ProductionCategory;
    public string ProductionLevel;
    public string Hand;
    public string Angle;
    public string GolfClub;
    public string GolfHard;
    public string Introduction;
    public string FullIntro;
    public string ProductionPhoto;
}
public struct sProductionCategory
{
    public int ID;
    public string CategoryName;
    public string isPause;
}
public class StoreDB
{
    public const string MessageSuccess = "success";
	public StoreDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string CreateProduction(sProduction obj)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "insert into store_Production (Name,Price,Category,ProductLevel,Introduction,HTML,Hand,Angle,GolfClub,HardLevel)" +
" values " +
"(@Name,@Price,@Category,@ProductLevel,@Introduction,@HTML,@Hand,@Angle,@GolfClub,@HardLevel)" +
" SELECT @@identity ";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@Name", DbType.String, obj.Name);
        db.AddInParameter(command, "@Price", DbType.Int32, obj.Price);
        db.AddInParameter(command, "@Category", DbType.Int16, obj.ProductionCategory);
        db.AddInParameter(command, "@ProductLevel", DbType.Int16, obj.ProductionLevel);
        db.AddInParameter(command, "@Introduction", DbType.String, obj.Introduction);
        db.AddInParameter(command, "@HTML", DbType.String, obj.FullIntro);
        db.AddInParameter(command, "@Hand", DbType.Int16, obj.Hand);

        db.AddInParameter(command, "@Angle", DbType.Int32, obj.Angle);
        db.AddInParameter(command, "@GolfClub", DbType.Int16, obj.GolfClub);
        db.AddInParameter(command, "@HardLevel", DbType.Int16, obj.GolfHard);
       
        success = db.ExecuteScalar(command).ToString();
        return success;
    }
    public List<object> searchProduct(DTParameterModel ParameterModel)
    {
        List<object> returnvalue = new List<object>();
        string wheresql = " where 1=1";
        foreach(DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and A.ID = @" + myCondition.Name + " ";
                    }
                    break;
                case "search_name":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and Name like @" + myCondition.Name + " ";
                    }
                    break;
                case "search_category":
                    if (myCondition.Value.Length > 0)
                    {
                        wheresql += " and Category = @" + myCondition.Name + " ";
                    }
                    break;
            }
        }
        DataBase db = new DataBase();
        string sqlString = "SELECT A.ID,A.Name,B.CategoryName FROM store_Production A left join store_ProductCategory B on A.Category=B.ID " 
            + wheresql;
        DbCommand command = db.GetSqlStringCommond(sqlString);
        foreach (DTCondition myCondition in ParameterModel.Condition)
        {
            switch (myCondition.Name)
            {
                case "search_account":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.Int64,  myCondition.Value );
                    }
                    break;
                case "search_name":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.String, "%" + myCondition.Value + "%");
                    }
                    break;
                case "search_category":
                    if (myCondition.Value.Length > 0)
                    {
                        db.AddInParameter(command, "@" + myCondition.Name, DbType.Int16,  myCondition.Value);
                    }
                    break;
            }
        }
        
        DbDataReader dr= db.ExecuteReader(command);
        while (dr.Read())
        {
            string[] atom = { dr["ID"].ToString(), dr["Name"].ToString(), dr["CategoryName"].ToString(), 
                                "<a href='../manage/product.aspx?id=" + dr["ID"].ToString() + "'>檢視</a>" };
            returnvalue.Add(atom);
        }
        dr.Close();
        command.Connection.Close();
        
        return returnvalue;
    }
    public sProduction selectProduction(int pID)
    {
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select * from store_Production where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, pID);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            myProduction.Hand = dr["Hand"].ToString();
            myProduction.Angle = dr["Angle"].ToString();
            myProduction.GolfClub = dr["GolfClub"].ToString();
            myProduction.GolfHard = dr["HardLevel"].ToString();
            myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();

        }
        return myProduction;
    }
    public List<sProduction> searchProductionbyCateogry(string category)
    {
        List<sProduction> returnValue = new List<sProduction>();
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString;
        if(category.Length==0)
            sqlString = "select * from store_Production  order by ID desc";
        else
            sqlString = "select * from store_Production where Category=@Category order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        if (category.Length != 0)
            db.AddInParameter(command, "@Category", DbType.Int16, category);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            myProduction.Hand = dr["Hand"].ToString();
            myProduction.Angle = dr["Angle"].ToString();
            myProduction.GolfClub = dr["GolfClub"].ToString();
            myProduction.GolfHard = dr["HardLevel"].ToString();
            myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            returnValue.Add(myProduction);
        }
        return returnValue;
    }
    public sProduction searchProductionbyID(string id)
    {
        
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select * from store_Production where ID=@ID order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, id);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            myProduction.Hand = dr["Hand"].ToString();
            myProduction.Angle = dr["Angle"].ToString();
            myProduction.GolfClub = dr["GolfClub"].ToString();
            myProduction.GolfHard = dr["HardLevel"].ToString();
            myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
          
        }
        return myProduction;
    }
    public List<sProduction> searchProduction(int counter)
    {
        List<sProduction> returnValue = new List<sProduction>();
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select top " + counter.ToString() + " * from store_Production order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            myProduction.Hand = dr["Hand"].ToString();
            myProduction.Angle = dr["Angle"].ToString();
            myProduction.GolfClub = dr["GolfClub"].ToString();
            myProduction.GolfHard = dr["HardLevel"].ToString();
            myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            returnValue.Add(myProduction);
        }
        return returnValue;
    }
    public List<sProduction> searchProduction()
    {
        List<sProduction> returnValue = new List<sProduction>();
        sProduction myProduction = new sProduction();
        DataBase db = new DataBase();
        string sqlString = "select  * from store_Production order by ID desc";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myProduction.ID = int.Parse(dr["ID"].ToString());
            myProduction.Name = dr["Name"].ToString();
            myProduction.Price = dr["Price"].ToString();
            myProduction.ProductionCategory = dr["Category"].ToString();
            myProduction.ProductionLevel = dr["ProductLevel"].ToString();
            myProduction.Introduction = dr["Introduction"].ToString();
            myProduction.FullIntro = dr["HTML"].ToString();
            myProduction.Hand = dr["Hand"].ToString();
            myProduction.Angle = dr["Angle"].ToString();
            myProduction.GolfClub = dr["GolfClub"].ToString();
            myProduction.GolfHard = dr["HardLevel"].ToString();
            myProduction.ProductionPhoto = dr["ProductionPhoto"].ToString();
            returnValue.Add(myProduction);
        }
        return returnValue;
    }
    public string updateProductionPhoto(string PhotoName, string ID)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "update store_Production set ProductionPhoto=@ProductionPhoto where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ProductionPhoto", DbType.String, PhotoName);
        db.AddInParameter(command, "@ID", DbType.Int32, ID);
        success = db.ExecuteNonQuery(command).ToString();
        if (int.Parse(success) > 0)
            success = MessageSuccess;
        return success;
    }

    public string CreateProductionCategory(string category)
    {
        string returnValue = MessageSuccess;
        int totalCounter = getTotalCategoryCounter() + 1;
        DataBase db = new DataBase();
        string sqlString = "insert into store_ProductCategory (CategoryName,Sequence) values " +
        "(@CategoryName,@Sequence) SELECT @@identity ";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@CategoryName", DbType.String, category);
        db.AddInParameter(command, "@Sequence", DbType.Int16, totalCounter);
        returnValue = db.ExecuteScalar(command).ToString();
        
        return returnValue;
    }
    public string PauseCategory(string CategoryID,bool isPause)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "update store_ProductCategory set isPause=@isPause where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@isPause", DbType.Boolean, isPause);
        db.AddInParameter(command, "@ID", DbType.Int32, CategoryID);
        success = db.ExecuteNonQuery(command).ToString();
        if (int.Parse(success) > 0)
            success = MessageSuccess;
        return success;
    }
    public string DeleteCategory(string CategoryID)
    {
        string success = "";
        DataBase db = new DataBase();
        string sqlString = "update store_ProductCategory set isDelete=@isDelete where ID=@ID";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@isDelete", DbType.Boolean, 1);
        db.AddInParameter(command, "@ID", DbType.Int32, CategoryID);
        success = db.ExecuteNonQuery(command).ToString();
        if (int.Parse(success) > 0)
            success = MessageSuccess;
        return success;
    }
    
    private int getTotalCategoryCounter()
    {
        int returnvalue = 0;
        DataBase db = new DataBase();
        string sqlString = "select count(*) from store_ProductCategory";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        returnvalue = (int)db.ExecuteScalar(command);
        //returnvalue = command.ExecuteNonQuery();
        return returnvalue;

    }
    public string updateProductionCategory(string category, string ID)
    {
        string success = MessageSuccess;
        try
        {
            
            DataBase db = new DataBase();
            string sqlString = "update store_ProductCategory set CategoryName=@CategoryName where ID=@ID";
            DbCommand command = db.GetSqlStringCommond(sqlString);
            db.AddInParameter(command, "@CategoryName", DbType.String, category);
            db.AddInParameter(command, "@ID", DbType.Int32, ID);
            db.ExecuteNonQuery(command).ToString();
        }
        catch (Exception e)
        {
            success = e.Message;
        }
        return success;
    }
    public List<sProductionCategory> searchProductionCategory()
    {
        List<sProductionCategory> returnValue = new List<sProductionCategory>();
        sProductionCategory myCategory = new sProductionCategory();
        DataBase db = new DataBase();
        string sqlString = "select * from store_ProductCategory where isDelete=0 order by Sequence";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            myCategory.ID = int.Parse(dr["ID"].ToString());
            myCategory.CategoryName = dr["CategoryName"].ToString();
            myCategory.isPause = dr["isPause"].ToString();
            returnValue.Add(myCategory);
        }
        return returnValue;
    }
    public string searchProductionCategoryName(string id)
    {
        string returnValue = "";
       
        DataBase db = new DataBase();
        string sqlString = "select * from store_ProductCategory where ID=@ID order by Sequence";
        DbCommand command = db.GetSqlStringCommond(sqlString);
        db.AddInParameter(command, "@ID", DbType.Int32, id);
        DbDataReader dr = db.ExecuteReader(command);
        while (dr.Read())
        {
            returnValue = dr["CategoryName"].ToString();
        }
        return returnValue;
    }
}
