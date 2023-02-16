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
        //Get List of up_GetProcessModel from up_GetProcess stored procedure     


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
            UserActivity userActivityModel = 
            dt.AsEnumerable().Select(m => new UserActivity()
            {
                UserNT = m.Field<string>("UserNT"),
                FkProcess = m.Field<int>("FkProcess"),
                Activity = m.Field<string>("Activity"),
                Terminal = m.Field<string>("Terminal"),
                UpdatedAt = m.Field<DateTime>("UpdatedAt"),
            }).FirstOrDefault();
            return userActivityModel;
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
            FileRepositoryModel = dt.AsEnumerable().Select(m => new FileRepositoryModel()
            {
                FileName = m.Field<string>("FileName"),
                SerialNumber = m.Field<string>("SerialNumber"),
                FKProcess = m.Field<int>("FKProcess"),
                Source = m.Field<string>("Source"),
                FileData = m.Field<byte[]>("FileData"),              
                UpdatedAt = m.Field<DateTime>("UpdatedAt"),
            }).FirstOrDefault();
            return FileRepositoryModel!=null? FileRepositoryModel: new FileRepositoryModel();
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
            FileRepositoryModel FileRepositoryModel = dt.AsEnumerable().Select(m => new FileRepositoryModel()
            {
                PKFile = m.Field<int>("PKFile"), 
                FileName = m.Field<string>("FileName"),
                SerialNumber = m.Field<string>("SerialNumber"),
                FKProcess = m.Field<int>("FKProcess"),
                Source = m.Field<string>("Source"),
                FileData = m.Field<byte[]>("FileData"),             
                UpdatedAt = m.Field<DateTime>("UpdatedAt"),
            }).FirstOrDefault();
            return FileRepositoryModel;
        }

    }
}
