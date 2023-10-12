using Dapper;
using MISA.Web06.RESTful.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Infrastructure
{
    public class QueryHelper
    {
        /// <summary>
        /// Định nghĩa câu lệnh insert và param 
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>Query</returns>
        /// Created by: Nguyễn Văn Thịnh (19/08/2023)
        public static Query InsertQueryString(Object entity, string tableName)
        {
            // Khởi tạo các biến lưu trữ
            var properties = entity.GetType().GetProperties();

            // Lưu trữ tên cột
            var columnNames = new List<String>();
            // Lưu trữ tên định danh cột
            var valueParameters = new List<String>();

            // Lặp qua các property và tạo ra chuỗi
            var param = new DynamicParameters();
            foreach (var paramProperties in properties)
            {
                bool isCreatedProperty = false;
                object[] attrs = paramProperties.GetCustomAttributes(true);
                foreach(object attr in attrs)
                {
                    ModifiedPropertyAttribute updatedPropertyAttribute = attr as ModifiedPropertyAttribute;

                    if(updatedPropertyAttribute != null)
                    {
                        isCreatedProperty = true;
                        break;
                    }
                }
                if(isCreatedProperty)
                {
                    continue;
                }

                // Thêm các giá trị cho chuỗi
                var columnName = paramProperties.Name;
                var valueParameter = "@" + paramProperties.Name;
                columnNames.Add(columnName);
                valueParameters.Add(valueParameter);

                // Thêm đối số cho chuỗi
                var nameParam = paramProperties.Name;
                var valueParam = paramProperties.GetValue(entity);
                param.Add(nameParam, valueParam);
            }

            // Tạo chuỗi truy vấn
            var columnNamesString = string.Join(", ", columnNames);
            var valueParametersString = string.Join(", ", valueParameters);

            var sql = $"INSERT INTO {tableName} ({columnNamesString}) VALUES ({valueParametersString});";

            var query = new Query()
            {
                Sql = sql,
                Param = param
            };

            return query;
        }

        /// <summary>
        /// Định nghĩa câu lệnh update và param
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tableName"></param>
        /// <returns>Query</returns>
        /// Created by: Nguyễn Văn Thịnh (19/08/2023)
        public static Query UpdateQueryString(Object entity, string tableName)
        {
            // Khởi tạo các biến lưu trữ
            var properties = entity.GetType().GetProperties();

            // Mảng gồm các chuỗi update cột
            var columnNames = new List<String>();

            // Lặp qua các property và tạo ra chuỗi
            var param = new DynamicParameters();
            foreach (var paramProperties in properties)
            {
                bool isUpdateProperty = false;
                object[] attrs = paramProperties.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    CreatedPropertyAttribute createdPropertyAttribute = attr as CreatedPropertyAttribute;
                    if (createdPropertyAttribute != null)
                    {
                        isUpdateProperty = true;
                        break;
                    }
                }
                if (isUpdateProperty)
                {
                    continue;
                }

                // Thêm các chuỗi update
                var columnName = paramProperties.Name + " = " + "@" + paramProperties.Name;
                columnNames.Add(columnName);

                // truyền tham số
                var nameParam = paramProperties.Name;
                var valueParam = paramProperties.GetValue(entity);
                param.Add(nameParam, valueParam);
            }

            var columnUpdate = string.Join(", ", columnNames);

            var sql = $"UPDATE {tableName} SET {columnUpdate} WHERE {tableName}Id=@{tableName}Id";

            var query = new Query()
            {
                Sql = sql,
                Param = param
            };

            return query;
        }
    }
}
