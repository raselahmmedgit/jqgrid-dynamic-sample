using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.IMWUISample.ViewModels
{
    public class TimeSheetDetailsWithItemViewModel
    {
        public int Id { get; set; }

        public int ProjectNo { get; set; }
        public bool IsProject { get; set; }

        public bool IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public bool IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }

        public bool IsActivity { get; set; }
        public string Activity { get; set; }

        public bool IsCompleted { get; set; }
        public string Completed { get; set; }

        public int DayOne { get; set; }
        public int DayTwo { get; set; }
        public int DayThree { get; set; }
        public int DayFour { get; set; }
        public int DayFive { get; set; }

        public bool IsEdited { get; set; }
    }

    public class TimeSheetDetailsWithItemViewModelNew
    {
        public int Id { get; set; }

        public int ProjectNo { get; set; }
        public bool IsProject { get; set; }

        public bool IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public bool IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }

        public bool IsActivity { get; set; }
        public string Activity { get; set; }

        public bool IsCompleted { get; set; }
        public string Completed { get; set; }

        public int? Day31 { get; set; }
        public int? Day2 { get; set; }
        public int? Day3 { get; set; }
        public int? Day4 { get; set; }
        public int? Day5 { get; set; }

        public bool IsEdited { get; set; }
    }

    public class PIMTimeSheetDayViewModel
    {
        public System.Int64 Id { get; set; }

        public int TimeSheetId { get; set; }

        public DateTime TSDay { get; set; }

        public double OfficeHour { get; set; }

        public double WorkedHour { get; set; }

        public float FlexiHour { get; set; }
    }

    public class ProjectTimeSheetDetailsViewModel
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectText { get; set; }
        public string IsProject { get; set; }

        public string IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public string ProjectLeaderId { get; set; }
        public string ProjectLeader { get; set; }

        public string ProjectSupervisorId { get; set; }
        public string ProjectSupervisor { get; set; }

        public string IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }
        public string SubmittedText { get; set; }

        public string ActivityId { get; set; }
        public string IsActivity { get; set; }
        public string Activity { get; set; }

        public string IsCompleted { get; set; }
        public string Completed { get; set; }
        public string CompletedText { get; set; }

        public string IsEdited { get; set; }

        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
        public string Day8 { get; set; }
        public string Day9 { get; set; }
        public string Day10 { get; set; }
        public string Day11 { get; set; }
        public string Day12 { get; set; }
        public string Day13 { get; set; }
        public string Day14 { get; set; }
        public string Day15 { get; set; }
        public string Day16 { get; set; }
        public string Day17 { get; set; }
        public string Day18 { get; set; }
        public string Day19 { get; set; }
        public string Day20 { get; set; }
        public string Day21 { get; set; }
        public string Day22 { get; set; }
        public string Day23 { get; set; }
        public string Day24 { get; set; }
        public string Day25 { get; set; }
        public string Day26 { get; set; }
        public string Day27 { get; set; }
        public string Day28 { get; set; }
        public string Day29 { get; set; }
        public string Day30 { get; set; }
        public string Day31 { get; set; }
    }

    public class TimeSheetDetailsGridViewModel
    {
        public string Id { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectText { get; set; }
        public string IsProject { get; set; }

        public string IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public string IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }
        public string SubmittedText { get; set; }

        public string IsActivity { get; set; }
        public string Activity { get; set; }

        public string IsCompleted { get; set; }
        public string Completed { get; set; }
        public string CompletedText { get; set; }

        public string DayOne { get; set; }
        public string DayTwo { get; set; }
        public string DayThree { get; set; }
        public string DayFour { get; set; }
        public string DayFive { get; set; }

        public string DaySix { get; set; }
        public string DaySeven { get; set; }
        public string DayEight { get; set; }
        public string DayNine { get; set; }
        public string DayTen { get; set; }

        public string IsEdited { get; set; }
    }

    public class TimeSheetFooterUserDataViewModel
    {
        public string CompletedText { get; set; }

        public string DayOne { get; set; }
        public string DayTwo { get; set; }
        public string DayThree { get; set; }
        public string DayFour { get; set; }
        public string DayFive { get; set; }
    }

    public class TimeSheetDetailsFilterViewModel
    {
        public int FortnightId { get; set; }
        public string FortnightName { get; set; }
        public int ResourceInitialId { get; set; }
        public string ResourceInitialName { get; set; }
        public DateTime FortnightDateTime { get; set; }

    }

    public class TimeSheetDetailsFilterResultViewModel
    {
        public int FortnightType { get; set; }
        public int FortnightDayNumber { get; set; }
        public string[] MergeCellGroupColumnNameList { get; set; }
        public string[] FooterColumnNameList { get; set; }
        public string FooterTextColumnName { get; set; }
        public string MergeColumnHeaderStartColumnName { get; set; }
        public string MergeColumnHeaderNumberOfColumns { get; set; }
        public string[] HighLightColumnNameList { get; set; }
        public string[] ChangeColumnNameList { get; set; }
        public string[] ChangeColumnHeaderList { get; set; }
        public string[] OffDayColumnNameList { get; set; }
        public string FlexiValue { get; set; }
        //public string[] GridColumnNameList { get; set; }
        //public object[] GridColumnModelNameList { get; set; }
        //public string JqGridUrl { get; set; }
    }

    public class TimeSheetDetailsGridParamViewModel
    {
        public int FortnightType { get; set; }
        public int FortnightDayNumber { get; set; }
    }


    ////////////////////////////////////////////////////////

    //ForFirstFortnight View Model
    public class TimeSheetDetailsForFirstFortnightGridViewModel
    {
        public string Id { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectText { get; set; }
        public string IsProject { get; set; }

        public string IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public string IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }
        public string SubmittedText { get; set; }

        public string IsActivity { get; set; }
        public string Activity { get; set; }

        public string IsCompleted { get; set; }
        public string Completed { get; set; }
        public string CompletedText { get; set; }

        public string IsEdited { get; set; }

        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
        public string Day8 { get; set; }
        public string Day9 { get; set; }
        public string Day10 { get; set; }
        public string Day11 { get; set; }
        public string Day12 { get; set; }
        public string Day13 { get; set; }
        public string Day14 { get; set; }
        public string Day15 { get; set; }

    }

    //ForSecondFortnightOf16Days View Model
    public class TimeSheetDetailsForSecondFortnightOf16DaysGridViewModel
    {
        public string Id { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectText { get; set; }
        public string IsProject { get; set; }

        public string IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public string IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }
        public string SubmittedText { get; set; }

        public string IsActivity { get; set; }
        public string Activity { get; set; }

        public string IsCompleted { get; set; }
        public string Completed { get; set; }
        public string CompletedText { get; set; }

        public string IsEdited { get; set; }

        public string Day16 { get; set; }
        public string Day17 { get; set; }
        public string Day18 { get; set; }
        public string Day19 { get; set; }
        public string Day20 { get; set; }
        public string Day21 { get; set; }
        public string Day22 { get; set; }
        public string Day23 { get; set; }
        public string Day24 { get; set; }
        public string Day25 { get; set; }
        public string Day26 { get; set; }
        public string Day27 { get; set; }
        public string Day28 { get; set; }
        public string Day29 { get; set; }
        public string Day30 { get; set; }
        public string Day31 { get; set; }

    }

    //ForSecondFortnightOf15Days View Model
    public class TimeSheetDetailsForSecondFortnightOf15DaysGridViewModel
    {
        public string Id { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectText { get; set; }
        public string IsProject { get; set; }

        public string IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public string IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }
        public string SubmittedText { get; set; }

        public string IsActivity { get; set; }
        public string Activity { get; set; }

        public string IsCompleted { get; set; }
        public string Completed { get; set; }
        public string CompletedText { get; set; }

        public string IsEdited { get; set; }

        public string Day16 { get; set; }
        public string Day17 { get; set; }
        public string Day18 { get; set; }
        public string Day19 { get; set; }
        public string Day20 { get; set; }
        public string Day21 { get; set; }
        public string Day22 { get; set; }
        public string Day23 { get; set; }
        public string Day24 { get; set; }
        public string Day25 { get; set; }
        public string Day26 { get; set; }
        public string Day27 { get; set; }
        public string Day28 { get; set; }
        public string Day29 { get; set; }
        public string Day30 { get; set; }

    }

    //ForSecondFortnightOf14Days View Model
    public class TimeSheetDetailsForSecondFortnightOf14DaysGridViewModel
    {
        public string Id { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectText { get; set; }
        public string IsProject { get; set; }

        public string IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public string IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }
        public string SubmittedText { get; set; }

        public string IsActivity { get; set; }
        public string Activity { get; set; }

        public string IsCompleted { get; set; }
        public string Completed { get; set; }
        public string CompletedText { get; set; }

        public string IsEdited { get; set; }

        public string Day16 { get; set; }
        public string Day17 { get; set; }
        public string Day18 { get; set; }
        public string Day19 { get; set; }
        public string Day20 { get; set; }
        public string Day21 { get; set; }
        public string Day22 { get; set; }
        public string Day23 { get; set; }
        public string Day24 { get; set; }
        public string Day25 { get; set; }
        public string Day26 { get; set; }
        public string Day27 { get; set; }
        public string Day28 { get; set; }
        public string Day29 { get; set; }

    }

    //ForSecondFortnightOf13Days View Model
    public class TimeSheetDetailsForSecondFortnightOf13DaysGridViewModel
    {
        public string Id { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectText { get; set; }
        public string IsProject { get; set; }

        public string IsApprovalStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public string IsSubmittedTo { get; set; }
        public string SubmittedTo { get; set; }
        public string SubmittedText { get; set; }

        public string IsActivity { get; set; }
        public string Activity { get; set; }

        public string IsCompleted { get; set; }
        public string Completed { get; set; }
        public string CompletedText { get; set; }

        public string IsEdited { get; set; }

        public string Day16 { get; set; }
        public string Day17 { get; set; }
        public string Day18 { get; set; }
        public string Day19 { get; set; }
        public string Day20 { get; set; }
        public string Day21 { get; set; }
        public string Day22 { get; set; }
        public string Day23 { get; set; }
        public string Day24 { get; set; }
        public string Day25 { get; set; }
        public string Day26 { get; set; }
        public string Day27 { get; set; }
        public string Day28 { get; set; }
    }

}