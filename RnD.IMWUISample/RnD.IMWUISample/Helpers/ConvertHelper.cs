using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using RnD.IMWUISample.ViewModels;
using System.Globalization;

namespace RnD.IMWUISample.Helpers
{
    public static class ConvertHelper
    {
        //using System.ComponentModel;
        public static DataTable ConvertObjectToDataTable<T>(T data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(data) ?? DBNull.Value;
            table.Rows.Add(row);

            return table;

        }

        public static List<ObjectRowViewModel> ConvertObjectColumnToRow<T>(T data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));

            List<ObjectRowViewModel> objectRowViewModelList = new List<ObjectRowViewModel>();

            foreach (PropertyDescriptor prop in properties)
            {
                string columnName = string.Empty;
                decimal columnValue = 0;
                DateTime columnDate = new DateTime();

                var propNameLower = prop.Name.ToLower();

                var propNameIndexOfValue = propNameLower.IndexOf("day");

                var isColumnNameDay = propNameIndexOfValue == 0 ? true : false;

                if (isColumnNameDay)
                {
                    var columnDayAsStr = propNameLower.Substring(3);

                    var columnDayAsInt = Convert.ToInt16(columnDayAsStr);

                    var asd = prop.GetValue(data);

                    //var propValueAsStr = Convert.ToString(prop.GetValue(data)) ?? Convert.ToString(DBNull.Value);

                    var propValueAsStr = prop.GetValue(data) == null ? "0" : Convert.ToString(prop.GetValue(data));

                    var propValueAsDecimal = Convert.ToDecimal(propValueAsStr);

                    if (propValueAsDecimal > 0)
                    {
                        columnName = prop.Name.ToString();
                        columnValue = propValueAsDecimal;
                    }
                }

                if (columnName != null && columnValue > 0)
                {
                    ObjectRowViewModel objectRowViewModel = new ObjectRowViewModel();
                    objectRowViewModel.ColumnName = columnName;
                    objectRowViewModel.ColumnValue = columnValue;

                    objectRowViewModelList.Add(objectRowViewModel);
                }

            }

            return objectRowViewModelList;

        }

        public static List<PIMTimeSheetDayViewModel> ConvertObjectColumnToRow(ProjectTimeSheetDetailsViewModel data, IList<ProjectTimeSheetDetailsViewModel> dataList, string tsYear, string tsMonth, int timeSheetId)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(ProjectTimeSheetDetailsViewModel));

            List<PIMTimeSheetDayViewModel> objectRowViewModelList = new List<PIMTimeSheetDayViewModel>();

            foreach (PropertyDescriptor prop in properties)
            {
                string columnName = string.Empty;
                decimal columnValue = 0;
                DateTime tsDate = new DateTime();

                double officeHour = 0;
                double totalWorkedHour = 0;
                float totalFlexiHour = 0;

                var propNameLower = prop.Name.ToLower();

                var propNameIndexOfValue = propNameLower.IndexOf("day");

                var isColumnNameDay = propNameIndexOfValue == 0 ? true : false;

                if (isColumnNameDay)
                {
                    var columnDayAsStr = propNameLower.Substring(3);

                    var columnDayAsInt = Convert.ToInt16(columnDayAsStr);

                    var propValueAsStr = Convert.ToString(prop.GetValue(data)) ?? Convert.ToString(DBNull.Value);

                    var propValueAsDecimal = Convert.ToDecimal(propValueAsStr);

                    if (propValueAsDecimal > 0 && columnDayAsInt > 0)
                    {
                        columnName = prop.Name.ToString();
                        columnValue = propValueAsDecimal;
                        int month = DateTime.ParseExact(tsMonth, "MMMM", CultureInfo.InvariantCulture).Month;
                        tsDate = new DateTime(Convert.ToInt16(tsYear), month, columnDayAsInt);
                        totalWorkedHour = GetTotalWorkedHourOfDay(columnDayAsInt, dataList);
                        //totalFlexiHour = Convert.ToDecimal(totalWorkedHour - officeHour);
                    }
                }

                if (columnName != null && columnValue > 0)
                {
                    PIMTimeSheetDayViewModel objectRowViewModel = new PIMTimeSheetDayViewModel();
                    objectRowViewModel.TimeSheetId = timeSheetId;
                    objectRowViewModel.TSDay = tsDate;
                    objectRowViewModel.OfficeHour = officeHour;
                    objectRowViewModel.WorkedHour = totalWorkedHour; //total of this day
                    objectRowViewModel.FlexiHour = totalFlexiHour; //flexi of this day

                    objectRowViewModelList.Add(objectRowViewModel);
                }

            }

            return objectRowViewModelList;

        }

        public static double GetTotalWorkedHourOfDay(int day, IList<ProjectTimeSheetDetailsViewModel> dataList)
        {
            double totalWorkedHour = 0;

            if (day == 1)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day1 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 2)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day2 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 3)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day3 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 4)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day4 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 5)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day5 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 6)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day6 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 7)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day7 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 8)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day8 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 9)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day9 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 10)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day10 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 11)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day11 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 12)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day12 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 13)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day13 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 14)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day14 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 15)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day15 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 16)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day16 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 17)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day17 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 18)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day18 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 19)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day19 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 20)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day20 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 21)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day21 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 22)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day22 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 23)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day23 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 24)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day24 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 25)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day25 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 26)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day26 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 27)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day27 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 28)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day28 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 29)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day29 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 30)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day30 != null ? Convert.ToDouble(x.Day31) : 0);
            }
            else if (day == 31)
            {
                return totalWorkedHour = dataList.Sum(x => x.Day31 != null ? Convert.ToDouble(x.Day31) : 0);
            }

            return totalWorkedHour;
        }

        public static DataTable ConvertListObjectToDataTable<T>(IList<T> dataList)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in dataList)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static DataSet ConvertObjectToDataSet<T>(T data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(data) ?? DBNull.Value;
            table.Rows.Add(row);

            //return table;
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            return dataSet;

        }
    }
}