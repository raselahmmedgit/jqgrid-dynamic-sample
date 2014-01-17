using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.IMWUISample.Helpers
{
    public class JQGridRowsViewModel
    {
        public string[] cell { get; set; }
    }

    public static class JQGridHelper
    {
        public static string GenerateCheckBox(string name, string id, string text, bool isCheck)
        {
            string strCheckBox = "<input type='checkbox' ";

            strCheckBox += "class='chk" + name + "'";
            strCheckBox += "id='chk" + name + "_" + id;
            strCheckBox += "' name='chk" + name + "_" + id;
            strCheckBox += "' value='" + id;
            if (isCheck)
            {
                strCheckBox += "' checked='checked";
            }
            strCheckBox += "' />&nbsp;&nbsp;" + text;


            return strCheckBox;
        }

        public static string GenerateRadioButton(string name, string id, string text, bool isCheck)
        {
            string strRadioButton = "<input type='radio' ";

            strRadioButton += "class='rb" + name + "'";
            strRadioButton += "id='rb" + name + "_" + id;
            strRadioButton += "' name='rb" + name + "_" + id;
            strRadioButton += "' value='" + id;
            if (isCheck)
            {
                strRadioButton += "' checked='checked";
            }
            strRadioButton += "' />&nbsp;&nbsp;" + text;




            return strRadioButton;
        }

        public static string GenerateGroupRadioButton(string name, string id, string text, bool isCheck, int numberButton)
        {
            string strRadioButton = "<ul class='rb-group'>";

            for (int i = 1; i <= numberButton; i++)
            {
                strRadioButton += "<li><input type='radio' ";

                strRadioButton += "class='rb" + name + "'";
                strRadioButton += "id='rb" + name + "_" + id;
                strRadioButton += "' name='rb" + name + "_" + id;
                strRadioButton += "' value='" + id;
                if (isCheck)
                {
                    strRadioButton += "' checked='checked";
                }
                strRadioButton += "' />&nbsp;&nbsp;" + text;

                strRadioButton += "</li>";
            }

            strRadioButton += "</ul>";

            return strRadioButton;
        }

        public static string GenerateCheckBoxForProject(string name, string id, string text, bool isCheck)
        {
            string strCheckBox = "<input type='checkbox' ";

            strCheckBox += "class='chk-projectno' ";
            strCheckBox += "id='chk" + name + "_" + id;
            strCheckBox += "' name='chk" + name + "_" + id;
            strCheckBox += "' onclick='ProjectCheck(" + id + ");";
            strCheckBox += "' value='" + id;
            if (isCheck)
            {
                strCheckBox += "' checked='checked";
            }

            strCheckBox += "' />&nbsp;&nbsp;<label class='lbl-projectno' ";

            strCheckBox += "id='chk" + name + "_" + id;

            strCheckBox += "' for='chk" + name + "_" + id;

            strCheckBox += "' >" + text + "</label>";

            return strCheckBox;
        }

        public static string GenerateGroupRadioButtonForSubmitted(string name, string id, string textPL, string textPS, bool isCheckPL = false, bool isCheckPS = false)
        {
            string strRadioButton = "<ul class='ul-submitted' >";

            //PL Radio
            strRadioButton += "<li>";
            strRadioButton += "<input type='radio' ";
            strRadioButton += "class='rb-submitted' ";
            strRadioButton += "id='rbSubmittedToPL_" + id;
            strRadioButton += "' name='rbSubmittedTo_" + id;
            strRadioButton += "' value='" + id;

            if (isCheckPL)
            {
                strRadioButton += "' checked='checked";
            }

            //strRadioButton += "' />&nbsp;&nbsp;" + textPL + "&nbsp;&nbsp;";
            strRadioButton += "' />&nbsp;&nbsp;<label class='lblSubmitted' ";
            strRadioButton += "id='rbSubmittedToPL_" + id;
            strRadioButton += "' for='rbSubmittedToPL_" + id;
            strRadioButton += "' >" + textPL + "</label>";
            strRadioButton += "</li>";

            //PS Radio
            strRadioButton += "<li>";
            strRadioButton += "<input type='radio' ";
            strRadioButton += "class='rb-submitted' ";
            strRadioButton += "id='rbSubmittedToPS_" + id;
            strRadioButton += "' name='rbSubmittedTo_" + id;
            strRadioButton += "' value='" + id;

            if (isCheckPS)
            {
                strRadioButton += "' checked='checked";
            }

            //strRadioButton += "' />&nbsp;&nbsp;" + textPS;
            strRadioButton += "' />&nbsp;&nbsp;<label class='lblSubmitted' ";
            strRadioButton += "id='rbSubmittedToPS_" + id;
            strRadioButton += "' for='rbSubmittedToPS_" + id;
            strRadioButton += "' >" + textPS + "</label>";
            strRadioButton += "</li>";

            strRadioButton += "</ul>";

            return strRadioButton;
        }

        public static string GenerateGroupRadioButtonForSubmitted(string name, string id, string idPL, string idPS, string textPL, string textPS, bool isCheckPL = false, bool isCheckPS = false)
        {
            string strRadioButton = "<ul id='rbSubmitted_" + id + "' class='ul-submitted' >";

            //PL Radio
            strRadioButton += "<li>";
            strRadioButton += "<input type='radio' ";
            strRadioButton += "class='rb-submitted' ";
            strRadioButton += "id='rbSubmittedToPL_" + id;
            strRadioButton += "' name='rbSubmittedTo_" + id;
            strRadioButton += "' value='" + idPL;

            if (isCheckPL)
            {
                strRadioButton += "' CHECKED='checked";
            }

            //strRadioButton += "' />&nbsp;&nbsp;" + textPL + "&nbsp;&nbsp;";
            strRadioButton += "' />&nbsp;&nbsp;<label class='lblSubmitted' ";
            strRadioButton += "id='rbSubmittedToPL_" + id;
            strRadioButton += "' for='rbSubmittedToPL_" + id;
            strRadioButton += "' >" + textPL + "</label>";
            strRadioButton += "</li>";

            //PS Radio
            strRadioButton += "<li>";
            strRadioButton += "<input type='radio' ";
            strRadioButton += "class='rb-submitted' ";
            strRadioButton += "id='rbSubmittedToPS_" + id;
            strRadioButton += "' name='rbSubmittedTo_" + id;
            strRadioButton += "' value='" + idPS;

            if (isCheckPS)
            {
                strRadioButton += "' CHECKED='checked";
            }

            //strRadioButton += "' />&nbsp;&nbsp;" + textPS;
            strRadioButton += "' />&nbsp;&nbsp;<label class='lblSubmitted' ";
            strRadioButton += "id='rbSubmittedToPS_" + id;
            strRadioButton += "' for='rbSubmittedToPS_" + id;
            strRadioButton += "' >" + textPS + "</label>";
            strRadioButton += "</li>";

            strRadioButton += "</ul>";

            return strRadioButton;
        }

        public static string GenerateGroupRadioButtonForSubmitted(string rowId, string name, string id, string idPL, string idPS, string textPL, string textPS, bool isCheckPL = false, bool isCheckPS = false)
        {
            string strRadioButton = "<ul id='rbSubmitted_" + id + "' class='ul-submitted' >";

            //PL Radio
            strRadioButton += "<li>";
            strRadioButton += "<input type='radio' ";
            strRadioButton += "class='rb-submitted' ";
            strRadioButton += "id='rbSubmittedToPL_" + id + "_" + rowId;
            strRadioButton += "' name='rbSubmittedTo_" + id + "_" + rowId;
            strRadioButton += "' value='" + idPL;

            if (isCheckPL)
            {
                strRadioButton += "' CHECKED='checked";
            }

            //strRadioButton += "' />&nbsp;&nbsp;" + textPL + "&nbsp;&nbsp;";
            strRadioButton += "' />&nbsp;&nbsp;<label class='lblSubmitted' ";
            strRadioButton += "id='rbSubmittedToPL_" + id + "_" + rowId;
            strRadioButton += "' for='rbSubmittedToPL_" + id + "_" + rowId;
            strRadioButton += "' >" + textPL + "</label>";
            strRadioButton += "</li>";

            //PS Radio
            strRadioButton += "<li>";
            strRadioButton += "<input type='radio' ";
            strRadioButton += "class='rb-submitted' ";
            strRadioButton += "id='rbSubmittedToPS_" + id + "_" + rowId;
            strRadioButton += "' name='rbSubmittedTo_" + id + "_" + rowId;
            strRadioButton += "' value='" + idPS;

            if (isCheckPS)
            {
                strRadioButton += "' CHECKED='checked";
            }

            //strRadioButton += "' />&nbsp;&nbsp;" + textPS;
            strRadioButton += "' />&nbsp;&nbsp;<label class='lblSubmitted' ";
            strRadioButton += "id='rbSubmittedToPS_" + id + "_" + rowId;
            strRadioButton += "' for='rbSubmittedToPS_" + id + "_" + rowId;
            strRadioButton += "' >" + textPS + "</label>";
            strRadioButton += "</li>";

            strRadioButton += "</ul>";

            return strRadioButton;
        }

        public static string GenerateCheckBoxForComplete(string name, string id, string text, bool isCheck)
        {
            string strCheckBox = "<input type='checkbox' ";

            strCheckBox += "class='chk-complete' ";
            strCheckBox += "id='chk" + name + "_" + id;
            strCheckBox += "' name='chk" + name + "_" + id;
            strCheckBox += "' onclick='CompleteCheck(" + id + ", this);";
            strCheckBox += "' value='" + id;
            if (isCheck)
            {
                strCheckBox += "' checked='checked";
            }
            strCheckBox += "' />&nbsp;&nbsp;" + text;


            return strCheckBox;
        }

        public static string GenerateValueForApprovalStatus(string id, string text)
        {
            string strValue = @"<span class='approval-status' id='approvalStatus_" + id + "' >" + text + "</span>";

            return strValue;
        }

    }
}