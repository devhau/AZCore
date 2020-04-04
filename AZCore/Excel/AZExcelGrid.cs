﻿using Aspose.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;

namespace AZCore.Excel
{
    public class AZExcelGrid
    {
        protected int StartRow = 1;
        protected Workbook azWorkbook { get; private set; }
        protected Worksheet azWorksheet { get; private set; }
        public int WidthDefault = 150;
        public AZExcelGrid() {
            azWorkbook = new Workbook();
            azWorkbook.Worksheets.Clear();
        }
        public void SetSheet(string name) {
            azWorksheet = azWorkbook.Worksheets[name];
            if (azWorksheet == null)
            {
                azWorksheet= azWorkbook.Worksheets.Add(name);
            }
            azWorksheet.IsSelected = true;

        }
        public void SetDataForGrid(object Data, List<IExcelColumn> columns, int startRow = 1) {
            StartRow = startRow;
            AddHeader(columns);
            AddGrid(Data, columns);
        }
        protected virtual void SetHeader(Cell cell,bool isDateTime=false)
        {
            var style=cell.GetStyle();

            if(isDateTime)
                style.Custom = "dd/mm/yyyy"; 
            style.Pattern = BackgroundType.Solid;
            style.BackgroundColor = Color.Blue;
            style.ForegroundColor = Color.White;
            style.SetBorder(BorderType.BottomBorder,CellBorderType.Thick, Color.Black);
            style.SetBorder(BorderType.TopBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.RightBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.LeftBorder, CellBorderType.Thin, Color.Black);
            style.VerticalAlignment = TextAlignmentType.Center;
            style.HorizontalAlignment = TextAlignmentType.Center;
            style.Font.IsBold = true;
            cell.SetStyle(style);
        }

        protected virtual void SetCell(Cell cell,bool isDateTime=false)
        {
            var style = cell.GetStyle();

            if (isDateTime)
                style.Custom = "dd/mm/yyyy";
            style.Pattern = BackgroundType.Solid;
            //style.BackgroundColor = Color.Azure;
            //style.ForegroundColor = Color.White;
            style.SetBorder(BorderType.BottomBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.TopBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.RightBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.LeftBorder, CellBorderType.Thin, Color.Black);
            cell.SetStyle(style);
        }
        protected virtual void AddHeader(List<IExcelColumn> columns) {
            var colIndex = 0;
            foreach (var item in columns)
            {
                azWorksheet.Cells[StartRow, colIndex].Value = item.Title;
                if (item.Width > 0)
                    azWorksheet.Cells.SetColumnWidthPixel(colIndex, item.Width);
                else
                    azWorksheet.Cells.SetColumnWidthPixel(colIndex, WidthDefault);
                SetHeader(azWorksheet.Cells[StartRow, colIndex]);
                colIndex++;
            }
        }

        protected virtual void AddGrid(object Data, List<IExcelColumn> columns) {
           
            if (Data is DataTable)
            {
                var _dataTable = (DataTable)Data;
                foreach (DataRow item in _dataTable.Rows)
                {
                    StartRow++;
                    AddRow(item, columns);
                }
            }
            else
            {
                IList _dataList = (IList)Data;
                foreach (var item in _dataList)
                {
                    StartRow++;
                    AddRow(item, columns);
                }
            }
        }
        protected virtual void AddRow(object Data, List<IExcelColumn> columns)
        {
            var colIndex = 0;
            var typeData = Data.GetType();
            foreach (var item in columns) {
                var proItem = typeData.GetProperty(item.FieldName);
                bool IsDate = false;
                if (proItem != null) {
                    object objValue = proItem.GetValue(Data);
                    if (item.DataType != null)
                    {
                        objValue = GetValueByType(item.DataType, objValue);
                    }
                    azWorksheet.Cells[StartRow, colIndex].Value = objValue;
                    IsDate = (objValue != null && objValue.GetType() == typeof(DateTime));
                }              
                SetCell(azWorksheet.Cells[StartRow, colIndex], IsDate);
                colIndex++;
            }
        }
        protected virtual void AddRow(DataRow Data, List<IExcelColumn> columns)
        {
            var colIndex = 0;
            foreach (var item in columns)
            {
                object objValue = Data[item.FieldName];
                bool IsDate = false;
                if (item.DataType != null)
                {
                    objValue = GetValueByType(item.DataType, objValue);
                }                
                azWorksheet.Cells[StartRow, colIndex].Value = objValue;
                IsDate = (objValue != null && objValue.GetType() == typeof(DateTime));
                SetCell(azWorksheet.Cells[StartRow, colIndex], IsDate);
                colIndex++;
            }
        }
        protected virtual object GetValueByType(Type type,object value) {
            return value;
        }
        public Stream Download(FileFormatType fileFormatType=FileFormatType.Xlsx)
        {
            var file = new MemoryStream();
            azWorkbook.Save(file, fileFormatType);
            return file;
        }
    }
}