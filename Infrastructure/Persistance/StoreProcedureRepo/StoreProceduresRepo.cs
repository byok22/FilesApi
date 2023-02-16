using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesApi.Infrastructure.Persistansce;
using System.Data;
using System.Data.SqlClient;
using FilesApi.Domain.Entities;

namespace FilesApi.Infrastructure.Persistansce.StoreProcedureRepo
{
    public class StoreProceduresRepo
    { 
        private DbConnectA dba = new DbConnectA();       

        /// <summary>
        /// InsertAndGetUserActivity
        /// </summary>
        /// <param name="userActivity"></param>  
        public UserActivity InsertAndGetUserActivity(UserActivity userActivity)
        {
            SqlParameter parameter1 = new SqlParameter("@UserNT", userActivity.UserNT);
            SqlParameter parameter2 = new SqlParameter("@FkProcess", userActivity.FkProcess);
            SqlParameter parameter3 = new SqlParameter("@Activity", userActivity.Activity);
            SqlParameter parameter4 = new SqlParameter("@Terminal", userActivity.Terminal);
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            parameters[3] = parameter4;
            DataTable dt = dba.GetDataSP("up_InsertAR_UserActivity", parameters);
            UserActivity userActivityObj = new UserActivity();
            foreach (DataRow row in dt.Rows)
            {
                userActivityObj.UserNT = Convert.ToString(row["UserNT"]);
                userActivityObj.FkProcess = Convert.ToInt32(row["FkProcess"]);
                userActivityObj.Activity = Convert.ToString(row["Activity"]);
                userActivityObj.Terminal = Convert.ToString(row["Terminal"]);
                userActivityObj.UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]);     
                break;           
            }          
            return userActivityObj;
        }

        /// <summary>
        /// GetFileRepositoryBySerialNumer
        /// </summary>        
        public FileRepositoryModel GetFileRepositoryBySerialNumer(string serialNumber)
        {
            SqlParameter parameter1 = new SqlParameter("@SerialNumber", serialNumber);
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = parameter1;
            DataTable dt = dba.GetDataSP("up_GetFileRepositoryBySerial", parameters);
            FileRepositoryModel FileRepositoryModel = new FileRepositoryModel();
            foreach (DataRow row in dt.Rows)
            {
                FileRepositoryModel.PKFile = row["PKFile"]!=null? Convert.ToInt32(row["PKFile"]): 0;
                FileRepositoryModel.FileName = Convert.ToString(row["FileName"]);
                FileRepositoryModel.SerialNumber = Convert.ToString(row["SerialNumber"]);
                FileRepositoryModel.FKProcess = Convert.ToInt32(row["FKProcess"]);
                FileRepositoryModel.Source = Convert.ToString(row["Source"]);
                FileRepositoryModel.FileData = row["FileData"] != null ? (byte[])row["FileData"] : null;
                FileRepositoryModel.UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]);                              
                break;
            }         
           
            return FileRepositoryModel!=null? FileRepositoryModel: new FileRepositoryModel();
        }

        public List<FileRepositoryModel> GetFilesFromList(string listSerials)
        {
           
            SqlParameter parameter1 = new SqlParameter("@SerialNumbers", listSerials);
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = parameter1;
            DataTable dt = dba.GetDataSP("up_GetFilesFromList", parameters);
            List<FileRepositoryModel> FileRepositoryModelList = new List<FileRepositoryModel>();
            foreach (DataRow row in dt.Rows)
            {
                FileRepositoryModel FileRepositoryModel = new FileRepositoryModel();
                FileRepositoryModel.PKFile = row["PKFile"] != null ? Convert.ToInt32(row["PKFile"]) : 0;
                FileRepositoryModel.FileName = Convert.ToString(row["FileName"]);
                FileRepositoryModel.SerialNumber = Convert.ToString(row["SerialNumber"]);
                FileRepositoryModel.FKProcess = Convert.ToInt32(row["FKProcess"]);
                FileRepositoryModel.Source = Convert.ToString(row["Source"]);
                FileRepositoryModel.FileData = row["FileData"] != null ? (byte[])row["FileData"] : null;
                FileRepositoryModel.UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]);
                FileRepositoryModelList.Add(FileRepositoryModel);
            }
                return FileRepositoryModelList;          
        }

        /// <summary>
        /// InsertAndGetImageRepositoryModel
        /// </summary>
        /// <param name="imageObj"></param>
        /// <returns></returns>
        public FileRepositoryModel InsertAndGetFileRepositoryModel(FileRepositoryModel imageObj)
        {
             SqlParameter parameter1 = new SqlParameter("@FKProcess", imageObj.FKProcess);
            SqlParameter parameter2 = new SqlParameter("@FileName", imageObj.FileName);
            SqlParameter parameter3 = new SqlParameter("@SerialNumber", imageObj.SerialNumber);           
            SqlParameter parameter4 = new SqlParameter("@Source", imageObj.Source);
            SqlParameter parameter5 = new SqlParameter("@FileData", imageObj.FileData);            

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            parameters[3] = parameter4;
            parameters[4] = parameter5;
            DataTable dt = dba.GetDataSP("up_InsertAR_FileRepository", parameters);
            FileRepositoryModel FileRepositoryModel = new FileRepositoryModel();
            foreach (DataRow row in dt.Rows)
            {
                FileRepositoryModel.PKFile = row["PKFile"] != null ? Convert.ToInt32(row["PKFile"]) : 0;
                FileRepositoryModel.FileName = Convert.ToString(row["FileName"]);
                FileRepositoryModel.SerialNumber = Convert.ToString(row["SerialNumber"]);
                FileRepositoryModel.FKProcess = Convert.ToInt32(row["FKProcess"]);
                FileRepositoryModel.Source = Convert.ToString(row["Source"]);
                FileRepositoryModel.FileData = row["FileData"] != null ? (byte[])row["FileData"] : null;
                FileRepositoryModel.UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]);
                break;
            }          
            return FileRepositoryModel;
        }

    }
}
