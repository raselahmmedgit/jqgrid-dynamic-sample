using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.IMWUISample.Models;
using RnD.IMWUISample.ViewModels;
using RnD.IMWUISample.Helpers;
using System.Collections;
using System.Globalization;

namespace RnD.IMWUISample.Controllers
{
    public class DemoController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /Demo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Basic()
        {
            return View();
        }

        //GetCategories
        // for display jqGrid
        public ActionResult GetCategories()
        {
            var categories = _db.Categories.ToList();

            var viewCategories = categories.Select(cat => new CategoryGridModels() { CategoryId = Convert.ToString(cat.CategoryId), Name = cat.Name });

            //No of total records
            int totalRecords = (int)categories.Count;
            //Calculate total no of page  
            int totalPages = 1;   // (int)Math.Ceiling((float)totalRecords / (float)Rows);
            var getdata = new
            {
                total = totalPages,
                page = 1,
                records = totalRecords,
                rows = (
                    from p in viewCategories
                    select new
                    {
                        cell = new string[] { 
                                                        p.CategoryId,
                            p.CategoryId,
                                                        p.Name,
                                                        "<a id='lnkDetailsCategory_" + p.CategoryId + "' class='lnkDetailsCategory button' href='/Category/Details/" + p.CategoryId + "'>Details</a>",
                            "<a id='lnkEditCategory_" + p.CategoryId + "' class='lnkEditCategory button' href='/Category/Edit/" + p.CategoryId + "'>Edit</a>",
                                                        "<a id='lnkDeleteCategory_" + p.CategoryId + "' class='lnkDeleteCategory button' href='/Category/Delete/" + p.CategoryId + "'>Delete</a>" }
                    }).ToArray()
            };
            return Json(getdata);
        }

        //TimeSheetUI
        public ActionResult TimeSheetUI()
        {
            return View();
        }

        //DynamicTimeSheetUI
        public ActionResult DynamicTimeSheetUI()
        {
            return View();
        }

        //Final
        public ActionResult Final()
        {
            //int month = DateTime.ParseExact("May", "MMMM", CultureInfo.InvariantCulture).Month;

            //DateTime aaa = new DateTime(2013, month, 1);

            //int daysInMonth = System.DateTime.DaysInMonth(2001, month);

            //int secondPartOfMonth = daysInMonth - 15;

            //int firstPartOfMonth = daysInMonth - secondPartOfMonth;

            return View();
        }

        //Hunk
        public ActionResult Hunk()
        {
            var timeSheetDetailsWithItemViewModels = new List<TimeSheetDetailsWithItemViewModelNew>
                            {
                                new TimeSheetDetailsWithItemViewModelNew { Id = 1, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, Day31 = 10, Day2 = 5, Day3 = 0, Day4 = 0, Day5 = null },
                                new TimeSheetDetailsWithItemViewModelNew { Id = 2, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, Day31 = 2, Day2 = 2, Day3 = 0, Day4 = 0, Day5 = null },
                                new TimeSheetDetailsWithItemViewModelNew { Id = 3, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "C", Completed = null, Day31 = 0, Day2 = 0, Day3 = 0, Day4 = 0, Day5 = null },

                                new TimeSheetDetailsWithItemViewModelNew { Id = 4, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, Day31 = 0, Day2 = 0, Day3 = 0, Day4 = 0, Day5 = null },
                                new TimeSheetDetailsWithItemViewModelNew { Id = 5, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, Day31 = 0, Day2 = 0, Day3 = 0, Day4 = 0, Day5 = null },
                                new TimeSheetDetailsWithItemViewModelNew { Id = 6, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, Day31 = 0, Day2 = 0, Day3 = 0, Day4 = 0, Day5 = null },
                                new TimeSheetDetailsWithItemViewModelNew { Id = 7, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "U", Completed = null, Day31 = 0, Day2 = 0, Day3 = 0, Day4 = 0, Day5 = null },

                                
                            };


            foreach (var item in timeSheetDetailsWithItemViewModels)
            {
                var dataList = ConvertHelper.ConvertObjectColumnToRow(item);


            }


            //if (fortnightType == 1 && fortnightDayNumber == 15)
            //{

            //}
            //else if (fortnightType == 2 && fortnightDayNumber == 16)
            //{

            //}
            //else if (fortnightType == 2 && fortnightDayNumber == 15)
            //{

            //}
            //else if (fortnightType == 2 && fortnightDayNumber == 14)
            //{

            //}
            //else if (fortnightType == 2 && fortnightDayNumber == 13)
            //{


            //}

            return View();
        }

        [HttpPost]
        public JsonResult LoadTimeSheet(TimeSheetDetailsFilterViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    #region GridColumnNameList Data

                    List<string> gridColumnNameArrayList = new List<string>();
                    gridColumnNameArrayList.Add("Id");
                    gridColumnNameArrayList.Add("ProjectNo");
                    gridColumnNameArrayList.Add("Project No");
                    gridColumnNameArrayList.Add("IsProject");
                    gridColumnNameArrayList.Add("IsApprovalStatus");
                    gridColumnNameArrayList.Add("Approval Status");
                    gridColumnNameArrayList.Add("IsSubmittedTo");
                    gridColumnNameArrayList.Add("SubmittedTo");
                    gridColumnNameArrayList.Add("Submitted To");
                    gridColumnNameArrayList.Add("IsActivity");
                    gridColumnNameArrayList.Add("Activity");
                    gridColumnNameArrayList.Add("IsCompleted");
                    gridColumnNameArrayList.Add("Completed");
                    gridColumnNameArrayList.Add("Is Complete");
                    gridColumnNameArrayList.Add("IsEdited"); //index 14 of ArrayList
                    gridColumnNameArrayList.Add("1");
                    gridColumnNameArrayList.Add("2");
                    gridColumnNameArrayList.Add("3");
                    gridColumnNameArrayList.Add("4");
                    gridColumnNameArrayList.Add("5");
                    var gridColumnNameList = gridColumnNameArrayList.ToArray();


                    #endregion

                    #region GridColumnModelList Data

                    List<string> gridColumnModelNameArrayList = new List<string>();
                    gridColumnModelNameArrayList.Add("Id");
                    gridColumnModelNameArrayList.Add("ProjectNo");
                    gridColumnModelNameArrayList.Add("ProjectText");
                    gridColumnModelNameArrayList.Add("IsProject");
                    gridColumnModelNameArrayList.Add("IsApprovalStatus");
                    gridColumnModelNameArrayList.Add("ApprovalStatus");
                    gridColumnModelNameArrayList.Add("IsSubmittedTo");
                    gridColumnModelNameArrayList.Add("SubmittedTo");
                    gridColumnModelNameArrayList.Add("SubmittedText");
                    gridColumnModelNameArrayList.Add("IsActivity");
                    gridColumnModelNameArrayList.Add("Activity");
                    gridColumnModelNameArrayList.Add("IsCompleted");
                    gridColumnModelNameArrayList.Add("Completed");
                    gridColumnModelNameArrayList.Add("CompletedText");
                    gridColumnModelNameArrayList.Add("IsEdited"); //index 14 of ArrayList
                    gridColumnModelNameArrayList.Add("1");
                    gridColumnModelNameArrayList.Add("2");
                    gridColumnModelNameArrayList.Add("3");
                    gridColumnModelNameArrayList.Add("4");
                    gridColumnModelNameArrayList.Add("5");
                    var gridColumnModelNameList = gridColumnModelNameArrayList.ToArray();

                    #endregion

                    #region Result ViewModel

                    var mergeCellGroupColumnNameList = new string[] { "ProjectText", "ApprovalStatus", "SubmittedText" };
                    var footerColumnNameList = new string[] { "DayOne", "DayTwo", "DayThree", "DayFour", "DayFive" };
                    var highLightColumnNameList = new string[] { "DayOne", "DayFive" };
                    var changeColumnNameList = new string[] { "DayOne", "DayFive" };
                    var offDayColumnNameList = new string[] { "DayOne", "DayFive" };

                    var footerTextColumnName = "CompletedText";
                    var mergeColumnHeaderStartColumnName = "DayOne";
                    var mergeColumnHeaderNumberOfColumns = "5";
                    var flexiValue = "8";

                    TimeSheetDetailsFilterResultViewModel timeSheetFilterResultViewModel = new TimeSheetDetailsFilterResultViewModel();
                    timeSheetFilterResultViewModel.FortnightType = 1;
                    timeSheetFilterResultViewModel.FortnightDayNumber = 15;
                    timeSheetFilterResultViewModel.MergeCellGroupColumnNameList = mergeCellGroupColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.FooterColumnNameList = footerColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.FooterTextColumnName = footerTextColumnName;
                    timeSheetFilterResultViewModel.MergeColumnHeaderStartColumnName = mergeColumnHeaderStartColumnName;
                    timeSheetFilterResultViewModel.MergeColumnHeaderNumberOfColumns = mergeColumnHeaderNumberOfColumns;
                    timeSheetFilterResultViewModel.HighLightColumnNameList = highLightColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.ChangeColumnNameList = changeColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.OffDayColumnNameList = offDayColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.FlexiValue = flexiValue;
                    //timeSheetFilterResultViewModel.GridColumnNameList = gridColumnNameList;
                    //timeSheetFilterResultViewModel.GridColumnModelNameList = gridColumnModelNameList;
                    //timeSheetFilterResultViewModel.JqGridUrl = "";

                    #endregion

                    return Json(new { data = timeSheetFilterResultViewModel, status = Boolean.TrueString }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { data = "Error!", status = Boolean.FalseString }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "Error!", status = Boolean.FalseString }, JsonRequestBehavior.AllowGet);
            }
        }

        //Ok
        [HttpPost]
        public JsonResult LoadTimeSheetDetails(TimeSheetDetailsFilterViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    #region Result ViewModel

                    //Get Data from Database
                    var mergeCellGroupColumnNameList = new string[] { "ProjectText", "ApprovalStatus", "SubmittedText" };
                    var footerColumnNameList = GetFooterColumnNameList();
                    var highLightColumnNameList = GetHighLightAndOffDayColumnNameList();

                    var changeColumnNameList = GetChangeColumnNameList();
                    var changeColumnHeaderList = GetChangeColumnHeaderList();

                    //var changeColumnNameList = new string[] { };
                    //var changeColumnHeaderList = new string[] { };

                    var offDayColumnNameList = GetHighLightAndOffDayColumnNameList();

                    var footerTextColumnName = "CompletedText";
                    var mergeColumnHeaderStartColumnName = GetMergeColumnHeaderStartColumnName();
                    var mergeColumnHeaderNumberOfColumns = GetMergeColumnHeaderNumberOfColumns();
                    var flexiValue = GetFlexiValue();
                    //Get Data from Database

                    TimeSheetDetailsFilterResultViewModel timeSheetFilterResultViewModel = new TimeSheetDetailsFilterResultViewModel();
                    timeSheetFilterResultViewModel.FortnightType = 1;
                    timeSheetFilterResultViewModel.FortnightDayNumber = 15;
                    timeSheetFilterResultViewModel.MergeCellGroupColumnNameList = mergeCellGroupColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.FooterColumnNameList = footerColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.FooterTextColumnName = footerTextColumnName;
                    timeSheetFilterResultViewModel.MergeColumnHeaderStartColumnName = mergeColumnHeaderStartColumnName;
                    timeSheetFilterResultViewModel.MergeColumnHeaderNumberOfColumns = mergeColumnHeaderNumberOfColumns;
                    timeSheetFilterResultViewModel.HighLightColumnNameList = highLightColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.ChangeColumnNameList = changeColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.ChangeColumnHeaderList = changeColumnHeaderList.ToArray();
                    timeSheetFilterResultViewModel.OffDayColumnNameList = offDayColumnNameList.ToArray();
                    timeSheetFilterResultViewModel.FlexiValue = flexiValue;
                    //timeSheetFilterResultViewModel.JqGridUrl = "";

                    #endregion

                    return Json(new { data = timeSheetFilterResultViewModel, status = Boolean.TrueString }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { data = "Error!", status = Boolean.FalseString }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "Error!", status = Boolean.FalseString }, JsonRequestBehavior.AllowGet);
            }
        }

        // for display jqGrid
        public ActionResult GetTimeSheetDetailsDataRead()
        {

            var timeSheetDetailsWithItemViewModels = new List<TimeSheetDetailsWithItemViewModel>
                            {
                                new TimeSheetDetailsWithItemViewModel { Id = 1, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "Abra ki jabra, Shomontor cho", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 2, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 3, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "C", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },

                                new TimeSheetDetailsWithItemViewModel { Id = 4, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 5, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 6, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 7, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "U", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },

                                new TimeSheetDetailsWithItemViewModel { Id = 8, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "S", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 9, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 10, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 11, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "U", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },

                                new TimeSheetDetailsWithItemViewModel { Id = 12, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "R", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 13, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 14, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "N", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 15, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0, DayTwo = 0, DayThree = 0, DayFour = 0, DayFive = 0 }
                            };

            //var viewModels = timeSheetDetailsWithItemViewModels.Select(x => new TimeSheetDemoViewModel { Id = x.Id.ToString(), ProjectText = JQGridHelper.GenerateCheckBox("ProjectNo", x.ProjectNo.ToString(), x.ProjectNo.ToString(), x.IsProject), ProjectNo = x.ProjectNo.ToString(), IsProject = x.IsProject.ToString(), IsApprovalStatus = x.IsApprovalStatus.ToString(), ApprovalStatus = x.ApprovalStatus, IsSubmittedTo = x.IsSubmittedTo.ToString(), SubmittedTo = x.SubmittedTo, SubmittedText = "", IsActivity = x.IsActivity.ToString(), Activity = x.Activity, IsCompleted = x.IsCompleted.ToString(), Completed = x.Completed, CompletedText = JQGridHelper.GenerateCheckBox("Completed", x.ProjectNo.ToString(), null, x.IsCompleted), DayOne = x.DayOne.ToString(), DayTwo = x.DayTwo.ToString(), DayThree = x.DayThree.ToString(), DayFour = x.DayFour.ToString(), DayFive = x.DayFive.ToString(), IsEdited = x.IsEdited.ToString() }).ToList();
            var viewModels = timeSheetDetailsWithItemViewModels.Select(x => new TimeSheetDetailsGridViewModel { Id = x.Id.ToString(), ProjectText = JQGridHelper.GenerateCheckBoxForProject("ProjectNo", x.ProjectNo.ToString(), x.ProjectNo.ToString(), x.IsProject), ProjectNo = x.ProjectNo.ToString(), IsProject = x.IsProject.ToString(), IsApprovalStatus = x.IsApprovalStatus.ToString(), ApprovalStatus = JQGridHelper.GenerateValueForApprovalStatus(x.ProjectNo.ToString(), x.ApprovalStatus), IsSubmittedTo = x.IsSubmittedTo.ToString(), SubmittedTo = x.SubmittedTo, SubmittedText = JQGridHelper.GenerateGroupRadioButtonForSubmitted("Submitted", x.ProjectNo.ToString(), "PL", "PS", "PL (MHB)", "PS (OHS)", true, false), IsActivity = x.IsActivity.ToString(), Activity = x.Activity, IsCompleted = x.IsCompleted.ToString(), Completed = x.Completed, CompletedText = JQGridHelper.GenerateCheckBoxForComplete("Completed", x.ProjectNo.ToString(), null, x.IsCompleted), DayOne = x.DayOne.ToString(), DayTwo = x.DayTwo.ToString(), DayThree = x.DayThree.ToString(), DayFour = x.DayFour.ToString(), DayFive = x.DayFive.ToString(), DaySix = x.DayOne.ToString(), DaySeven = x.DayTwo.ToString(), DayEight = x.DayThree.ToString(), DayNine = x.DayFour.ToString(), DayTen = x.DayFive.ToString(), IsEdited = x.IsEdited.ToString() }).ToList();

            //No of total records
            int totalRecords = (int)viewModels.Count;
            //Calculate total no of page  
            int totalPages = 1;   // (int)Math.Ceiling((float)totalRecords / (float)Rows);
            var rows = (from ts in viewModels
                        select new
                        {
                            cell = new string[] { 
                                            ts.Id,
                                            ts.ProjectNo,
                                            //"<input id='chkProjectNo_"+ ts.ProjectNo +"' name='chkProjectNo_"+ ts.ProjectNo +"' class='chkProjectNo' type='checkbox'  value='"+ ts.ProjectNo +"'"+ ts.IsProject == "True" ? "checked='checked'" : " " +"/>&nbsp;&nbsp;"+ ts.ProjectNo,
                                            ts.ProjectText,
                                            ts.IsProject,
                                            ts.IsApprovalStatus,
                                            ts.ApprovalStatus,
                                            //"<span id='approvalStatus_" + ts.ProjectNo + "'>"+ ts.ApprovalStatus +"</span>",
                                            ts.IsSubmittedTo,
                                            ts.SubmittedTo,
                                            ts.SubmittedText,
                                            //"<input id='rbSubmittedToPL_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPL' type='radio'  value='"+ ts.ProjectNo +"' />&nbsp;&nbsp;PL (MHB)&nbsp;&nbsp;<input id='rbSubmittedToPS_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPS' type='radio'  value='"+ ts.ProjectNo +"' /> PS (OHS)",
                                            //"<input id='rbSubmittedToPL_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPL' type='radio'  value='"+ ts.ProjectNo +"'"+ ts.IsSubmittedTo == "True" ? "checked='checked'" : " " +"/>&nbsp;&nbsp;<input id='rbSubmittedToPS_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPS' type='radio'  value='"+ ts.ProjectNo +"'"+ ts.IsSubmittedTo == "True" ? "checked='checked'" : " " +"/>",
                                            ts.IsActivity,
                                            ts.Activity,
                                            ts.IsCompleted,
                                            ts.Completed,
                                            ts.CompletedText,
                                            //"<input id='chkCompleted_"+ ts.ProjectNo +"' name='chkCompleted_"+ ts.ProjectNo +"' class='chkCompleted' type='checkbox'  value='"+ ts.ProjectNo +"'"+ ts.IsCompleted == "True" ? "checked='checked'" : " " +"/>",
                                            ts.IsEdited,

                                            ts.DayOne,
                                            ts.DayTwo,
                                            ts.DayThree,
                                            ts.DayFour,
                                            ts.DayFive,
                                            ts.DaySix,
                                            ts.DaySeven,
                                            ts.DayEight,
                                            ts.DayNine,
                                            ts.DayTen
                                            
                            }
                        }).ToArray();

            //var userData = new string[] { CompletedText = "Total: ", DayOne = "85.25" };
            //var footerTotalUserData = new { CompletedText = "Total: ", DayOne = "85.25", DayTwo = "85.25", DayThree = "85.25", DayFour = "85.25", DayFive = "85.25" };
            //var footerFiexiUserData = new { CompletedText = "Flexi: ", DayOne = "25.25", DayTwo = "25.25", DayThree = "25.25", DayFour = "25.25", DayFive = "25.25" };

            //var footerTotalFiexiUserData = new List<TimeSheetFooterUserDataViewModel>{
            //            new TimeSheetFooterUserDataViewModel { CompletedText = "Total: ", DayOne = "85.25", DayTwo = "85.25", DayThree = "85.25", DayFour = "85.25", DayFive = "85.25" },
            //            new TimeSheetFooterUserDataViewModel { CompletedText = "Flexi: ", DayOne = "25.25", DayTwo = "25.25", DayThree = "25.25", DayFour = "25.25", DayFive = "25.25" }
            //                                            };

            //var userData = new string[] { totalData.CompletedText, totalData.DayOne };
            //var userData = new string[] { "Total : ", "85.25" };
            //var userData = footerTotalUserData;
            //var userData = new string[] { footerTotalUserData, footerFiexiUserData };

            //var userDatas = footerTotalFiexiUserData.ToArray();

            var getData = new
            {
                total = totalPages,
                page = 1,
                records = totalRecords,
                rows = rows//,
                //userdata = userData
                //userdata = userDatas
            };
            return Json(getData);
        }

        //Ok
        // for display jqGrid
        [HttpPost]
        //public ActionResult GetTimeSheetDetailsData(TimeSheetGridParamViewModel paramModel)
        public ActionResult GetTimeSheetDetailsData(int fortnightType, int fortnightDayNumber)
        {
            TimeSheetDetailsGridParamViewModel paramModel = new TimeSheetDetailsGridParamViewModel();
            paramModel.FortnightType = fortnightType;
            paramModel.FortnightDayNumber = fortnightDayNumber;

            var jqGridRows = GetJQGridRowsDataListDemo(paramModel);

            //No of total records
            //int totalRecords = (int)viewModels.Count;
            int totalRecords = 0;
            //Calculate total no of page  
            //int totalPages = (int)Math.Ceiling((float)totalRecords / (float)Rows);
            int totalPages = 0;
            var rows = jqGridRows;

            var getData = new
            {
                total = totalPages,
                page = 1,
                records = totalRecords,
                rows = rows//,
                //userdata = userData
                //userdata = userDatas
            };
            return Json(getData);
        }

        private JQGridRowsViewModel[] GetJQGridRowsDataListDemo(TimeSheetDetailsGridParamViewModel paramModel)
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            int fortnightType = 1;
            int fortnightDayNumber = 15;

            if (fortnightType == 1 && fortnightDayNumber == 15)
            {
                rows = GetJQGridRowsForFirstFortnightDataDemo();
            }
            else if (fortnightType == 2 && fortnightDayNumber == 16)
            {

            }
            else if (fortnightType == 2 && fortnightDayNumber == 15)
            {

            }
            else if (fortnightType == 2 && fortnightDayNumber == 14)
            {

            }
            else if (fortnightType == 2 && fortnightDayNumber == 13)
            {

            }

            return rows;
        }

        //Get JQGrid Rows cell data ForFirstFortnight
        private JQGridRowsViewModel[] GetJQGridRowsForFirstFortnightDataDemo()
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            List<TimeSheetDetailsForFirstFortnightGridViewModel> viewModelList = GetTimeSheetDetailsForFirstFortnightDataListDemo();

            rows = (from ts in viewModelList
                    select new JQGridRowsViewModel
                    {
                        cell = new string[] { 
                                            ts.Id,
                                            ts.ProjectNo,
                                            //"<input id='chkProjectNo_"+ ts.ProjectNo +"' name='chkProjectNo_"+ ts.ProjectNo +"' class='chkProjectNo' type='checkbox'  value='"+ ts.ProjectNo +"'"+ ts.IsProject == "True" ? "checked='checked'" : " " +"/>&nbsp;&nbsp;"+ ts.ProjectNo,
                                            ts.ProjectText,
                                            ts.IsProject,
                                            ts.IsApprovalStatus,
                                            ts.ApprovalStatus,
                                            //"<span id='approvalStatus_" + ts.ProjectNo + "'>"+ ts.ApprovalStatus +"</span>",
                                            ts.IsSubmittedTo,
                                            ts.SubmittedTo,
                                            ts.SubmittedText,
                                            //"<input id='rbSubmittedToPL_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPL' type='radio'  value='"+ ts.ProjectNo +"' />&nbsp;&nbsp;PL (MHB)&nbsp;&nbsp;<input id='rbSubmittedToPS_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPS' type='radio'  value='"+ ts.ProjectNo +"' /> PS (OHS)",
                                            //"<input id='rbSubmittedToPL_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPL' type='radio'  value='"+ ts.ProjectNo +"'"+ ts.IsSubmittedTo == "True" ? "checked='checked'" : " " +"/>&nbsp;&nbsp;<input id='rbSubmittedToPS_"+ ts.ProjectNo +"' name='rbSubmittedTo_"+ ts.ProjectNo +"' class='rbSubmittedToPS' type='radio'  value='"+ ts.ProjectNo +"'"+ ts.IsSubmittedTo == "True" ? "checked='checked'" : " " +"/>",
                                            ts.IsActivity,
                                            ts.Activity,
                                            ts.IsCompleted,
                                            ts.Completed,
                                            ts.CompletedText,
                                            //"<input id='chkCompleted_"+ ts.ProjectNo +"' name='chkCompleted_"+ ts.ProjectNo +"' class='chkCompleted' type='checkbox'  value='"+ ts.ProjectNo +"'"+ ts.IsCompleted == "True" ? "checked='checked'" : " " +"/>",
                                            ts.IsEdited,

                                            ts.Day1,
                                            ts.Day2,
                                            ts.Day3,
                                            ts.Day4,
                                            ts.Day5,
                                            ts.Day6,
                                            ts.Day7,
                                            ts.Day8,
                                            ts.Day9,
                                            ts.Day10,
                                            ts.Day11,
                                            ts.Day12,
                                            ts.Day13,
                                            ts.Day14,
                                            ts.Day15
                                            
                            }
                    }).ToArray();

            return rows;
        }

        //Get ForFirstFortnight Demo
        private List<TimeSheetDetailsForFirstFortnightGridViewModel> GetTimeSheetDetailsForFirstFortnightDataListDemo()
        {
            //Get Data for DataBase

            var timeSheetDetailsViewModels = new List<TimeSheetDetailsWithItemViewModel>
                            {
                                new TimeSheetDetailsWithItemViewModel { Id = 1, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "Abra ki jabra, Shomontor cho", Completed = null, DayOne = 0},
                                new TimeSheetDetailsWithItemViewModel { Id = 2, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 3, ProjectNo = 1011, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "C", Completed = null, DayOne = 0 },

                                new TimeSheetDetailsWithItemViewModel { Id = 4, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 5, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 6, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 7, ProjectNo = 1022, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "U", Completed = null, DayOne = 0 },

                                new TimeSheetDetailsWithItemViewModel { Id = 8, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "S", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 9, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 10, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "B", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 11, ProjectNo = 1033, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "U", Completed = null, DayOne = 0 },

                                new TimeSheetDetailsWithItemViewModel { Id = 12, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "R", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 13, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 14, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "N", Completed = null, DayOne = 0 },
                                new TimeSheetDetailsWithItemViewModel { Id = 15, ProjectNo = 1044, ApprovalStatus = "Draft", SubmittedTo = null, Activity = "A", Completed = null, DayOne = 0 }
                            };

            //Get Data for DataBase

            List<TimeSheetDetailsForFirstFortnightGridViewModel> dataList = new List<TimeSheetDetailsForFirstFortnightGridViewModel>();

            dataList = timeSheetDetailsViewModels.Select(x => new TimeSheetDetailsForFirstFortnightGridViewModel
            {
                Id = x.Id.ToString(),
                //ProjectText = JQGridHelper.GenerateCheckBoxForProject("ProjectNo", x.ProjectNo.ToString(), x.ProjectNo.ToString(), true),
                ProjectText = JQGridHelper.GenerateCheckBoxForProject("ProjectNo", x.ProjectNo.ToString(), x.ProjectNo.ToString(), x.IsProject),
                ProjectNo = x.ProjectNo.ToString(),
                IsProject = x.IsProject.ToString(),
                IsApprovalStatus = x.IsApprovalStatus.ToString(),
                ApprovalStatus = JQGridHelper.GenerateValueForApprovalStatus(x.ProjectNo.ToString(), x.ApprovalStatus),
                IsSubmittedTo = x.IsSubmittedTo.ToString(),
                SubmittedTo = x.SubmittedTo,
                //SubmittedText = JQGridHelper.GenerateGroupRadioButtonForSubmitted("Submitted", x.ProjectNo.ToString(), "PL", "PS", "PL (MHB)", "PS (OHS)", true, false),
                SubmittedText = JQGridHelper.GenerateGroupRadioButtonForSubmitted(x.Id.ToString(), "Submitted", x.ProjectNo.ToString(), "PL", "PS", "PL (MHB)", "PS (OHS)", true, false),
                IsActivity = x.IsActivity.ToString(),
                Activity = x.Activity,
                IsCompleted = x.IsCompleted.ToString(),
                Completed = x.Completed,
                CompletedText = JQGridHelper.GenerateCheckBoxForComplete("Completed", x.ProjectNo.ToString(), null, x.IsCompleted),
                IsEdited = x.IsEdited.ToString(),

                Day1 = x.DayOne.ToString(),
                Day2 = x.DayOne.ToString(),
                Day3 = x.DayOne.ToString(),
                Day4 = x.DayOne.ToString(),
                Day5 = x.DayOne.ToString(),

                Day6 = x.DayOne.ToString(),
                Day7 = x.DayOne.ToString(),
                Day8 = x.DayOne.ToString(),
                Day9 = x.DayOne.ToString(),
                Day10 = x.DayOne.ToString(),

                Day11 = x.DayOne.ToString(),
                Day12 = x.DayOne.ToString(),
                Day13 = x.DayOne.ToString(),
                Day14 = x.DayOne.ToString(),
                Day15 = x.DayOne.ToString()


            }).ToList();

            return dataList;
        }

        //Ok
        #region Methods

        private string[] GetFooterColumnNameList()
        {
            string[] strList = new string[] { };

            //Get Data From Database

            strList = new string[] { "Day1", "Day2", "Day3", "Day4", "Day5", "Day6", "Day7", "Day8", "Day9", "Day10", "Day11", "Day12", "Day13", "Day14", "Day15" };

            //Get Data From Database

            return strList;
        }

        private string[] GetHighLightAndOffDayColumnNameList()
        {
            string[] strList = new string[] { };

            //Get Data From Database

            strList = new string[] { "Day1", "Day2" };

            //Get Data From Database

            return strList;
        }

        private string[] GetChangeColumnNameList()
        {
            string[] strList = new string[] { };

            //Get Data From Database

            strList = new string[] { "4", "5", "15" };

            //Get Data From Database

            return strList;
        }

        private string[] GetChangeColumnHeaderList()
        {
            string[] strList = new string[] { };

            //Get Data From Database

            strList = new string[] { "WH", "WH", "GH" };

            //Get Data From Database

            return strList;
        }


        ///
        //private string[,] GetChangeColumnNameList()
        //{
        //    string[,] strList = new string[,] { { "WH", "WH", "GH" }, { "4", "5", "9" } };

        //    //Get Data From Database

        //    //strList = new string[] { "6", "7" };

        //    var list = new List<KeyValuePair<string, string>>();
        //    list.Add(new KeyValuePair<string, string>("WH", "4"));
        //    list.Add(new KeyValuePair<string, string>("WH", "5"));
        //    list.Add(new KeyValuePair<string, string>("GH", "9"));

        //    //Get Data From Database

        //    return strList;
        //}
        ///


        private string GetFlexiValue()
        {
            string strValue = string.Empty;

            //Get Dta From Database
            strValue = "8";
            //Get Dta From Database

            return strValue;
        }

        private string GetMergeColumnHeaderStartColumnName()
        {
            string strValue = string.Empty;

            //Get Dta From Database
            //strValue = GetHighLightAndOffDayColumnNameList().FirstOrDefault();
            strValue = "Day1";
            //Get Dta From Database

            return strValue;
        }

        private string GetMergeColumnHeaderNumberOfColumns()
        {
            string strValue = string.Empty;

            //Get Dta From Database
            strValue = GetFooterColumnNameList().Count().ToString();
            //Get Dta From Database

            return strValue;
        }

        //Get Data row
        private JQGridRowsViewModel[] GetJQGridRowsDataList(TimeSheetDetailsGridParamViewModel paramModel)
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            int fortnightType = 1;
            int fortnightDayNumber = 15;

            if (fortnightType == 1 && fortnightDayNumber == 15)
            {
                rows = GetJQGridRowsForFirstFortnightData();
            }
            else if (fortnightType == 2 && fortnightDayNumber == 16)
            {
                rows = GetJQGridRowsForSecondFortnightOf16DaysData();
            }
            else if (fortnightType == 2 && fortnightDayNumber == 15)
            {
                rows = GetJQGridRowsForSecondFortnightOf15DaysData();
            }
            else if (fortnightType == 2 && fortnightDayNumber == 14)
            {
                rows = GetJQGridRowsForSecondFortnightOf14DaysData();
            }
            else if (fortnightType == 2 && fortnightDayNumber == 13)
            {
                rows = GetJQGridRowsForSecondFortnightOf13DaysData();
            }

            return rows;
        }

        //Get JQGrid Rows cell data ForFirstFortnight
        private JQGridRowsViewModel[] GetJQGridRowsForFirstFortnightData()
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            List<TimeSheetDetailsForFirstFortnightGridViewModel> viewModelList = null;

            return rows;
        }

        //Get JQGrid Rows cell data ForSecondFortnightOf16Days
        private JQGridRowsViewModel[] GetJQGridRowsForSecondFortnightOf16DaysData()
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            List<TimeSheetDetailsForSecondFortnightOf16DaysGridViewModel> viewModelList = null;

            return rows;
        }

        //Get JQGrid Rows cell data ForSecondFortnightOf15Days
        private JQGridRowsViewModel[] GetJQGridRowsForSecondFortnightOf15DaysData()
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            List<TimeSheetDetailsForSecondFortnightOf15DaysGridViewModel> viewModelList = null;

            return rows;
        }

        //Get JQGrid Rows cell data ForSecondFortnightOf14Days
        private JQGridRowsViewModel[] GetJQGridRowsForSecondFortnightOf14DaysData()
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            List<TimeSheetDetailsForSecondFortnightOf14DaysGridViewModel> viewModelList = null;

            return rows;
        }

        //Get JQGrid Rows cell data ForSecondFortnightOf13Days
        private JQGridRowsViewModel[] GetJQGridRowsForSecondFortnightOf13DaysData()
        {
            JQGridRowsViewModel[] rows = new JQGridRowsViewModel[] { };

            List<TimeSheetDetailsForSecondFortnightOf13DaysGridViewModel> viewModelList = null;

            return rows;
        }

        //Get ForFirstFortnight
        private List<TimeSheetDetailsForFirstFortnightGridViewModel> GetTimeSheetDetailsForFirstFortnightDataList()
        {
            //Get Data for DataBase

            //Get Data for DataBase

            List<TimeSheetDetailsForFirstFortnightGridViewModel> dataList = new List<TimeSheetDetailsForFirstFortnightGridViewModel>();

            return dataList;
        }

        //Get ForSecondFortnightOf16Days
        private List<TimeSheetDetailsForSecondFortnightOf16DaysGridViewModel> GetTimeSheetDetailsForSecondFortnightOf16DaysDataList()
        {
            //Get Data for DataBase

            //Get Data for DataBase

            List<TimeSheetDetailsForSecondFortnightOf16DaysGridViewModel> dataList = new List<TimeSheetDetailsForSecondFortnightOf16DaysGridViewModel>();

            return dataList;
        }

        //Get ForSecondFortnightOf15Days
        private List<TimeSheetDetailsForSecondFortnightOf15DaysGridViewModel> GetTimeSheetDetailsForSecondFortnightOf15DaysDataList()
        {
            //Get Data for DataBase

            //Get Data for DataBase

            List<TimeSheetDetailsForSecondFortnightOf15DaysGridViewModel> dataList = new List<TimeSheetDetailsForSecondFortnightOf15DaysGridViewModel>();

            return dataList;
        }

        //Get ForSecondFortnightOf14Days
        private List<TimeSheetDetailsForSecondFortnightOf14DaysGridViewModel> GetTimeSheetDetailsForSecondFortnightOf14DaysDataList()
        {
            //Get Data for DataBase

            //Get Data for DataBase

            List<TimeSheetDetailsForSecondFortnightOf14DaysGridViewModel> dataList = new List<TimeSheetDetailsForSecondFortnightOf14DaysGridViewModel>();

            return dataList;
        }

        //Get ForSecondFortnightOf13Days
        private List<TimeSheetDetailsForSecondFortnightOf13DaysGridViewModel> GetTimeSheetDetailsForSecondFortnightOf13DaysDataList()
        {
            //Get Data for DataBase

            //Get Data for DataBase

            List<TimeSheetDetailsForSecondFortnightOf13DaysGridViewModel> dataList = new List<TimeSheetDetailsForSecondFortnightOf13DaysGridViewModel>();

            return dataList;
        }

        #endregion

    }
}
