

/*.............................Start Grouping CheckBox Coloumn.......................................*/

function MergeCheckboxCell(grid, groupCol) {
    var rids = $('#' + grid).jqGrid('getDataIDs');
    var celldataParent = $('#' + grid).jqGrid('getCell', rids[0], groupCol);
    var count = 0;
    var range = 0;
    for (var i = 0; i <= rids.length; i++) {
        var celldataCurrent = $('#' + grid).jqGrid('getCell', rids[i], groupCol);
        if (celldataCurrent == celldataParent) {
            count++;
        }
        else {
            for (var k = 0; k < count; k++) {
                if (k == 0) {
                    $('#' + grid).jqGrid('setCell', rids[range + k], 'cb', '', 'visible-cell');
                    SetRowSpan(grid, count);
                }
                else {
                    $('#' + grid).setCell(rids[range + k], 'cb', '', 'hide-cell');
                }
            }
            celldataParent = celldataCurrent;
            range = range + count;
            count = 1;
        }
    }
    RemoveCol(grid);
}

function SetRowSpan(grid, n) {
    $('#' + grid + ' tr').each(function () {
        if (n > 1) {
            $(this).find(".visible-cell").attr("rowspan", n);
        }
    });
    $('#' + grid + ' tr').each(function () {
        $(this).find(".visible-cell").removeClass("visible-cell");
    });
}

function SetRowSpanForLastRow(grid, n) {
    $('#' + grid + ' tr').each(function () {
        if (n > 1) {
            $(this).find(".visible-cell").attr("rowspan", n);
        }
    });
    $('#' + grid + ' tr').each(function () {
        $(this).find(".visible-cell").removeClass("visible-cell");
    });
}

function RemoveCol(grid) {
    $('#' + grid + ' tr').each(function () {
        $(this).find(".hide-cell").hide();

    });
    $('#' + grid).each(function () {
        $(this).find(".jqgroup ui-row-ltr").hide();
    });
}

/*.............................End Grouping CheckBox Coloumn.......................................*/

/*.............................Start Grouping Coloumn.......................................*/

function MergeGridCellGroupWise(grid, columnNameList) {
    for (var y = 0; y <= columnNameList.length - 1; y++) {
        $.extend({
            threadedEach: MergeCell(grid, y, columnNameList)
        });
    }
    RemoveClass(grid);
}

function MergeCell(grid, rowIndex, columnNameList) {
    var i = 0;
    var row = 0;
    var celldataParent = '';
    var count = 0;
    var span = 1;
    var groupcount = 0;
    var cellObjectParent = null;
    var cellClassParent = '';
    var celldataCurrent = '';
    var cellClassCurrent = '';

    var obj = null;
    $('#' + grid + ' tbody tr td').each(function () {
        if (i > 0) {
            obj = $(this);

            if (obj.attr('aria-describedby') == grid + '_' + columnNameList[rowIndex]) {

                if (count == 0) {
                    celldataParent = obj.html();
                    cellClassParent = obj.context.className;
                    //obj.attr('Class', 'Visible');
                    //obj.html(obj.html() + '-Visible1');
                    groupcount++;
                    SetClass(grid, row, rowIndex, groupcount, columnNameList);
                    cellObjectParent = obj;
                }
                else {
                    celldataCurrent = obj.html();
                    cellClassCurrent = obj.context.className;

                }
                if (rowIndex > 0) {
                    if (cellClassCurrent == cellClassParent) {
                        if (celldataCurrent == celldataParent) {
                            span++;
                            obj.hide();
                            //obj.attr('Class', 'Hide');
                            //obj.html(obj.html() + '-Hide');
                            if (span > 1) {
                                cellObjectParent.attr('rowspan', span);
                            }
                            SetClass(grid, row, rowIndex, groupcount, columnNameList);
                        }
                        else if (celldataCurrent != celldataParent) {
                            if (count != 0) {
                                count = 0;
                                groupcount++;
                                span = 1;
                                celldataParent = obj.html();
                                cellClassParent = obj.context.className;
                                //obj.attr('Class', 'Visible');
                                //obj.html(obj.html() + '-Visible2');
                                cellObjectParent = obj;
                                SetClass(grid, row, rowIndex, groupcount, columnNameList);
                            }
                        }
                    }
                    else if (cellClassCurrent != cellClassParent) {
                        if (count != 0) {
                            count = 0;
                            groupcount++;
                            span = 1;
                            celldataParent = obj.html();
                            cellClassParent = obj.context.className;
                            //obj.attr('Class', 'Visible');
                            //obj.html(obj.html() + '-Visible3');
                            cellObjectParent = obj;
                            SetClass(grid, row, rowIndex, groupcount, columnNameList);
                        }
                    }
                    row++;
                    count++;

                }
                if (rowIndex == 0) {
                    if (celldataCurrent == celldataParent) {
                        span++;
                        obj.hide();
                        //obj.attr('Class', 'Hide');
                        //obj.html(obj.html() + '-Hide');
                        if (span > 1) {
                            cellObjectParent.attr('rowspan', span);
                        }
                        SetClass(grid, row, rowIndex, groupcount, columnNameList);
                    }
                    else {
                        if (count != 0) {
                            count = 0;
                            groupcount++;
                            span = 1;
                            celldataParent = obj.html();
                            //obj.attr('Class', 'Visible');
                            //obj.html(obj.html() + '-Visible4');
                            cellObjectParent = obj;
                            SetClass(grid, row, rowIndex, groupcount, columnNameList);
                        }
                    }

                    row++;
                    count++;
                }
            }
        }
        i++;
    });
}

function SetClass(grid, row, rowIndex, groupcount, columnNameList) {
    row = row + 1;
    // for (var y = rowIndex + 1; y <= columnNameList.length - 1; y++) {
    $('#' + grid).jqGrid('setCell', row, columnNameList[rowIndex + 1], '', columnNameList[rowIndex + 1] + '_' + groupcount);
    //}
}

function RemoveClass(grid) {
    var obj = null;
    $('#' + grid + ' tbody tr td').each(function () {
        obj = $(this);
        obj.removeAttr('Class');
    });
}

/*.............................End Grouping Coloumn.......................................*/

function MergeFirstGroupCell(grid, groupCol) {
    var rids = $('#' + grid).jqGrid('getDataIDs');
    var celldataParent = $('#' + grid).jqGrid('getCell', rids[0], groupCol);
    var count = 0;
    var range = 0;
    for (var i = 0; i <= rids.length; i++) {
        var celldataCurrent = $('#' + grid).jqGrid('getCell', rids[i], groupCol);
        if (celldataCurrent == celldataParent) {
            count++;
        }
        else {
            for (var k = 0; k < count; k++) {
                if (k == 0) {

                    $('#' + grid).jqGrid('setCell', rids[range + k], groupCol, '', 'visible-cell');
                    SetRowSpan(grid, count);

                }
                else {
                    $('#' + grid).jqGrid('setCell', rids[range + k], groupCol, '', 'hide-cell');
                }
            }
            celldataParent = celldataCurrent;
            range = range + count;
            count = 1;
        }
    }
    RemoveCol(grid);
}

function MergeGridCellByProjectNo(grid, groupCol) {
    var rids = $('#' + grid).jqGrid('getDataIDs');
    var rowDataParent = $('#' + grid).jqGrid('getRowData', rids[0]);
    var parentProjectNo = rowDataParent.ProjectNo;
    var count = 0;
    var range = 0;

    for (var i = 0; i <= rids.length; i++) {

        var rowId = rids[i];
        var rowDataCurrent = $('#' + grid).jqGrid('getRowData', rowId);

        var currentProjectNo = rowDataCurrent.ProjectNo;

        if (currentProjectNo == parentProjectNo) {
            count++;
        }
        else {
            for (var k = 0; k < count; k++) {
                if (k == 0) {
                    $('#' + grid).jqGrid('setCell', rids[range + k], groupCol, '', 'visible-cell');
                    SetRowSpan(grid, count);

                }
                else {
                    $('#' + grid).jqGrid('setCell', rids[range + k], groupCol, '', 'hide-cell');
                }
            }
            parentProjectNo = currentProjectNo;
            range = range + count;
            count = 1;
        }
    }
    RemoveCol(grid);
}

/*.............................Start CalculateFooterTotalAndFlexi.......................................*/

function CalculateFooterTotalAndFlexi(grid, e, rowId, cellName, cellValue, flexiValue) {

    var sum = $('#' + grid).jqGrid("getCol", cellName, false, "sum");

    var totalSum = parseFloat(sum);
    var flexiSum = parseFloat(sum) - parseFloat(flexiValue);

    var flexiTotalFooterRow = $(e.grid.sDiv).find("tr.flexiTotalFooterRow");
    if (flexiTotalFooterRow.length === 0) {
        // add second row of the footer if it's not exist
        flexiTotalFooterRow = footerRow.clone();
        flexiTotalFooterRow.removeClass("footrow").addClass("flexiTotalFooterRow ui-widget-content");
        flexiTotalFooterRow.children("td").each(function () {
            e.style.width = ""; // remove width from inline CSS
        });
        flexiTotalFooterRow.insertAfter(footerRow);
    }

    flexiTotalFooterRow.find(">td[aria-describedby=" + e.id + "_" + cellName + "]").text(
                        $.fmatter.util.NumberFormat(flexiSum, $.jgrid.formatter.number)
                    );

    var totalFooterRow = $(e.grid.sDiv).find("tr.totalFooterRow");
    if (totalFooterRow.length === 0) {
        // add second row of the footer if it's not exist
        totalFooterRow = footerRow.clone();
        totalFooterRow.removeClass("footrow").addClass("totalFooterRow ui-widget-content");
        totalFooterRow.children("td").each(function () {
            e.style.width = ""; // remove width from inline CSS
        });
        totalFooterRow.insertAfter(footerRow);
    }

    totalFooterRow.find(">td[aria-describedby=" + e.id + "_" + cellName + "]").text(
                        $.fmatter.util.NumberFormat(totalSum, $.jgrid.formatter.number)
                    );

}

function CalculateFooterTotalAndFlexiWithOffDay(grid, e, rowId, cellName, cellValue, flexiValue, offDatColumnNameList) {

    var sum = $('#' + grid).jqGrid("getCol", cellName, false, "sum");

    var totalSum = parseFloat(sum);
    var flexiSum = parseFloat(sum) - parseFloat(flexiValue);

    //    var innerFlexiSum = parseFloat(sum) - parseFloat(flexiValue);

    //    if (innerFlexiSum > 0) {
    //        flexiSum = parseFloat(innerFlexiSum);
    //    }

    for (var i = 0; i <= offDatColumnNameList.length - 1; i++) {

        var columnName = offDatColumnNameList[i];

        if (columnName == cellName) {

            flexiSum = parseFloat(totalSum);

            break;

        }
    }

    var maxTotal = parseFloat(24);

    if (totalSum > maxTotal || flexiSum > maxTotal) {

        var dialogContent = 'Total = ' + totalSum + ', Flexi = ' + flexiSum + ' : value must be less than or equal to 24';
        var dialogDiv = $("<div>" + dialogContent + "</div>");
        dialogDiv.dialog({
            title: "Warning",
            resizable: false,
            width: 'auto',
            buttons: [
                        {
                            text: "Close",
                            click: function () {
                                dialogDiv.dialog("close");
                            }
                        }
                    ]
        });

        $('#' + grid).jqGrid('setCell', rowId, cellName, 0);

    }
    else {

        var flexiTotalFooterRow = $(e.grid.sDiv).find("tr.flexiTotalFooterRow");
        if (flexiTotalFooterRow.length === 0) {
            // add second row of the footer if it's not exist
            flexiTotalFooterRow = footerRow.clone();
            flexiTotalFooterRow.removeClass("footrow").addClass("flexiTotalFooterRow ui-widget-content");
            flexiTotalFooterRow.children("td").each(function () {
                e.style.width = ""; // remove width from inline CSS
            });
            flexiTotalFooterRow.insertAfter(footerRow);
        }

        flexiTotalFooterRow.find(">td[aria-describedby=" + e.id + "_" + cellName + "]").text(
                        $.fmatter.util.NumberFormat(flexiSum, $.jgrid.formatter.number)
                    );

        var totalFooterRow = $(e.grid.sDiv).find("tr.totalFooterRow");
        if (totalFooterRow.length === 0) {
            // add second row of the footer if it's not exist
            totalFooterRow = footerRow.clone();
            totalFooterRow.removeClass("footrow").addClass("totalFooterRow ui-widget-content");
            totalFooterRow.children("td").each(function () {
                e.style.width = ""; // remove width from inline CSS
            });
            totalFooterRow.insertAfter(footerRow);
        }

        totalFooterRow.find(">td[aria-describedby=" + e.id + "_" + cellName + "]").text(
                        $.fmatter.util.NumberFormat(totalSum, $.jgrid.formatter.number)
                    );

        if (cellValue > 0) {
            //Set Row Data
            $('#' + grid).jqGrid('setCell', rowId, 'IsEdited', 'True');
        }
        else if (cellValue == 0) {
            //Set Row Data
            $('#' + grid).jqGrid('setCell', rowId, 'IsEdited', 'False');
        }

    } //End If Else





}


/*.............................End CalculateFooterTotalAndFlexi.......................................*/

/*.............................Start SetFooterTotalAndFlexi.......................................*/

function SetFooterTotalAndFlexiColumnWise(grid, e, columnNameList, footerTextColumnName) {

    for (var i = 0; i <= columnNameList.length - 1; i++) {

        var columnName = columnNameList[i];

        $.extend({
            threadedEach: SetFooterTotalAndFlexi(grid, e, columnName, footerTextColumnName)
        });
    }

}

function SetFooterTotalAndFlexi(grid, e, columnName, footerTextColumnName) {

    var sum = $('#' + grid).jqGrid("getCol", columnName, false, "sum");
    var footerRow = $(e.grid.sDiv).find("tr.footrow");

    var totalSum = parseFloat(sum);

    var flexiTotalFooterRow = $(e.grid.sDiv).find("tr.flexiTotalFooterRow");
    if (flexiTotalFooterRow.length === 0) {
        // add second row of the footer if it's not exist
        flexiTotalFooterRow = footerRow.clone();
        flexiTotalFooterRow.removeClass("footrow").addClass("flexiTotalFooterRow ui-widget-content");
        flexiTotalFooterRow.children("td").each(function () {
            e.style.width = ""; // remove width from inline CSS
        });
        flexiTotalFooterRow.insertAfter(footerRow);
    }

    flexiTotalFooterRow.find(">td[aria-describedby=" + e.id + "_" + footerTextColumnName + "]").text("Flexi:");
    flexiTotalFooterRow.find(">td[aria-describedby=" + e.id + "_" + columnName + "]").text(
                        $.fmatter.util.NumberFormat(totalSum, $.jgrid.formatter.number)
                    );

    var totalFooterRow = $(e.grid.sDiv).find("tr.totalFooterRow");
    if (totalFooterRow.length === 0) {
        // add second row of the footer if it's not exist
        totalFooterRow = footerRow.clone();
        totalFooterRow.removeClass("footrow").addClass("totalFooterRow ui-widget-content");
        totalFooterRow.children("td").each(function () {
            e.style.width = ""; // remove width from inline CSS
        });
        totalFooterRow.insertAfter(footerRow);
    }

    totalFooterRow.find(">td[aria-describedby=" + e.id + "_" + footerTextColumnName + "]").text("Total:");
    totalFooterRow.find(">td[aria-describedby=" + e.id + "_" + columnName + "]").text(
                                $.fmatter.util.NumberFormat(totalSum, $.jgrid.formatter.number)
                            );
}

/*.............................End SetFooterTotalAndFlexi.......................................*/

/*.............................Start MergeGridColumnsHeader.......................................*/

function MergeGridColumnsHeader(grid, startColumnName, numberOfColumns, titleText) {

    $('#' + grid).jqGrid('setGroupHeaders', {
        useColSpanStyle: true,
        groupHeaders: [
                      { startColumnName: startColumnName, numberOfColumns: numberOfColumns, titleText: '<div style="text-align:center;">' + titleText + '</div>' }
                  ]
    });

}

/*.............................End MergeGridColumnsHeader.......................................*/

/*.............................Start SetGridColumnHighLight.......................................*/

function SetGridColumnHighLight(grid, columnNameList) {

    var dataIDs = $('#' + grid).getDataIDs();

    for (var i = 0; i <= dataIDs.length; i++) {

        var rowId = dataIDs[i];

        for (var y = 0; y <= columnNameList.length - 1; y++) {

            var columnName = columnNameList[y];

            $.extend({
                threadedEach: SetGridColumnCellHighLight(grid, rowId, columnName)
            });
        }

    }

}

function SetGridColumnCellHighLight(grid, rowId, columnName) {

    $('#' + grid).jqGrid('setCell', rowId, columnName, "", 'offday-highlight');

}

/*.............................End SetGridColumnHighLight.......................................*/

/*.............................Start ChangeGridColumnHeaderTitle.......................................*/

function ChangeGridColumnHeaderTitle(grid, columnNameList, columnHeaderList) {

    console.log(columnNameList.length);
    console.log(columnHeaderList.length);

    if (columnNameList.length > 1 && columnHeaderList.length > 1) {
        console.log("if");
    }
    else {
        console.log("else");
    }

    for (var c = 0; c <= columnNameList.length - 1; c++) {

        var tempColumnName = columnNameList[c];
        var tempColumnHeader = columnHeaderList[c];

        var columnNameValue = parseInt(tempColumnName) + 1;
        var columnName = 'Day' + columnNameValue;
        var newHeaderTitle = tempColumnHeader + '<br/>' + tempColumnName;
        var columnHeaderHigh = 'Day' + tempColumnName;

        $.extend({
            threadedEach: SetGridColumnHeaderTitle(grid, columnName, newHeaderTitle, columnHeaderHigh)
        });



    } //end for

}

function SetGridColumnHeaderTitle(grid, columnName, newTitle, columnHeaderHigh) {

    //$('#' + grid).jqGrid('setLabel', columnName, newTitle);
    //$('#' + grid).setLabel(columnName, newTitle);

    //var thId = '#' + grid + '_' + columnHeaderHigh;

    //$('#' + grid).children('table').children('thead').children('th').children(thId).addClass('offday-highlight');

    //var addClassValue = '#' + grid + ' table thead tr th' + thId;
    //var addClassValue = '#' + grid + ' table thead ';
    //var addClassValue = '#' + grid + ' thead ';

    //var thText = $(addClassValue).text();
    //var thText = $(thId).text();

    //console.log(thId);
    //console.log(addClassValue);
    //console.log(thText);

    //$('#' + grid + 'table thead th' + thId).addClass('offday-highlight');
    //$(addClassValue).removeClass('ui-state-default').addClass('offday-highlight');
    //$(thId).removeClass('ui-state-default').addClass('offday-highlight');
    //$(addClassValue).find(thId).removeClass('ui-state-default').addClass('offday-highlight');

    //var jqGridColumnHead = '#jqgh_timeSheetJQGrid_' + columnHeaderHigh;
    //$(jqGridColumnHead).html('');
    //$(jqGridColumnHead).html(newTitle);

    var jqGridColumnHeadIdForAddClass = '#' + grid + '_' + columnHeaderHigh;
    var jqGridColumnHeadIdForChangeText = '#jqgh_' + grid + '_' + columnHeaderHigh;

    $(jqGridColumnHeadIdForAddClass).removeClass('ui-state-default').addClass('offday-highlight');
    $(jqGridColumnHeadIdForChangeText).html('');
    $(jqGridColumnHeadIdForChangeText).html(newTitle);

}

/*.............................End ChangeGridColumnHeaderTitle.......................................*/

/*.............................Start Create JqGrid Dynamic Coloumn.......................................*/

function ProjectCheck(id) {

}

function CompleteCheck(id, e) {

    //    if (confirm("Confirm! Do you want to complete?")) {
    //        $(e).attr('checked', 'checked');
    //    }
    //    else {
    //        $(e).removeAttr('checked');
    //    }

    var dialogContent = 'Are you sure the task is completed?';
    var dialogDiv = $("<div>" + dialogContent + "</div>");
    dialogDiv.dialog({
        title: "Confirm",
        resizable: false,
        width: 'auto',
        modal: true,
        buttons: [
                        {
                            text: "Yes",
                            click: function () {
                                //add ur stuffs here
                                $(e).attr('checked', 'checked');
                                dialogDiv.dialog("close");
                            }
                        },
                        {
                            text: "No",
                            click: function () {
                                $(e).removeAttr('checked');
                                dialogDiv.dialog("close");
                            }
                        }
                    ]
    });

}

function SetHiddenFieldValue(dataObj) {
    $("#hdFortnightType").val(dataObj.FortnightType);
    $("#hdFortnightDayNumber").val(dataObj.FortnightDayNumber);
    $("#hdMergeCellGroupColumnNameList").val(dataObj.MergeCellGroupColumnNameList);
    $("#hdFooterColumnNameList").val(dataObj.FooterColumnNameList);
    $("#hdFooterTextColumnName").val(dataObj.FooterTextColumnName);
    $("#hdMergeColumnHeaderStartColumnName").val(dataObj.MergeColumnHeaderStartColumnName);
    $("#hdMergeColumnHeaderNumberOfColumns").val(dataObj.MergeColumnHeaderNumberOfColumns);
    $("#hdHighLightColumnNameList").val(dataObj.HighLightColumnNameList);

    $("#hdChangeColumnNameList").val(dataObj.ChangeColumnNameList);
    $("#hdChangeColumnHeaderList").val(dataObj.ChangeColumnHeaderList);

    $("#hdOffDayColumnNameList").val(dataObj.OffDayColumnNameList);
    $("#hdFlexiValue").val(dataObj.FlexiValue);
    $("#hdJqGridUrl").val(dataObj.JqGridUrl);
}

function CreateTimeSheetJqGridForFirstFortnight(gridId, gridUrl) {

    $('#' + gridId).jqGrid({
        url: gridUrl,
        datatype: "json",
        mtype: 'POST',
        colNames: [
                    'Id',
                    'ProjectNo',
                    'Project No',
                    'IsProject',
                    'IsApprovalStatus',
                    'Approval Status',
                    'IsSubmittedTo',
                    'SubmittedTo',
                    'Submitted To',
                    'IsActivity',
                    'Activity',
                    'IsCompleted',
                    'Completed',
                    'Is Complete',
                    'IsEdited',

                    '1',
                    '2',
                    '3',
                    '4',
                    '5',
                    '6',
                    '7',
                    '8',
                    '9',
                    '10',
                    '11',
                    '12',
                    '13',
                    '14',
                    '15'
                    ],
        //colNames: gridColumnNameList,
        //colModel: gridColumnModelList,
        colModel: [
                                                { name: 'Id', index: 'Id', key: true, hidden: true },
                                                { name: 'ProjectNo', index: 'ProjectNo', hidden: true },
                                                { name: 'ProjectText', index: 'ProjectText', align: 'left', hidden: false },
                                                { name: 'IsProject', index: 'IsProject', hidden: true },
                                                { name: 'IsApprovalStatus', index: 'IsApprovalStatus', hidden: true },
                                                { name: 'ApprovalStatus', index: 'ApprovalStatus', align: 'center' },
                                                { name: 'IsSubmittedTo', index: 'IsSubmittedTo', hidden: true },
                                                { name: 'SubmittedTo', index: 'SubmittedTo', hidden: true },
                                                { name: 'SubmittedText', index: 'SubmittedText', align: 'center' },

                                                { name: 'IsActivity', index: 'IsActivity', hidden: true },
                                                { name: 'Activity', index: 'Activity', align: 'center' },
                                                { name: 'IsCompleted', index: 'IsCompleted', hidden: true },
                                                { name: 'Completed', index: 'Completed', hidden: true },
                                                { name: 'CompletedText', index: 'CompletedText', align: 'center' },
                                                { name: 'IsEdited', index: 'IsEdited', hidden: true, editable: true },

                                                { name: 'Day1', index: 'Day1', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day2', index: 'Day2', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day3', index: 'Day3', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day4', index: 'Day4', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day5', index: 'Day5', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day6', index: 'Day6', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day7', index: 'Day7', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day8', index: 'Day8', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day9', index: 'Day9', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day10', index: 'Day10', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day11', index: 'Day11', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day12', index: 'Day12', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day13', index: 'Day13', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day14', index: 'Day14', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day15', index: 'Day15', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} }
                                                ],
        cmTemplate: { sortable: false },
        cellEdit: true,
        cellsubmit: 'clientArray',
        height: 'auto',
        autowidth: true,
        grouping: false,
        sortname: 'id',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: false,
        multiselect: false,                        //checkbox list
        //shrinkToFit: true,
        footerrow: true,
        caption: "Time Sheet Details List",
        loadComplete: function (data) {

            //Get Hidden Field Value
            var hdMergeCellGroupColumnNameListValue = $("#hdMergeCellGroupColumnNameList").val();
            var hdFooterColumnNameListValue = $("#hdFooterColumnNameList").val();
            var hdFooterTextColumnNameValue = $("#hdFooterTextColumnName").val();
            var hdMergeColumnHeaderStartColumnNameValue = $("#hdMergeColumnHeaderStartColumnName").val();
            var hdMergeColumnHeaderNumberOfColumnsValue = $("#hdMergeColumnHeaderNumberOfColumns").val();
            var hdHighLightColumnNameListValue = $("#hdHighLightColumnNameList").val();
            var hdJqGridUrlValue = $("#hdJqGridUrl").val();
            //Get Hidden Field Value

            //Pass To Array Hidden Field Value
            var mergeCellGroupColumnNameList = hdMergeCellGroupColumnNameListValue.split(",");
            var footerColumnNameList = hdFooterColumnNameListValue.split(",");
            var footerTextColumnName = hdFooterTextColumnNameValue;
            var mergeColumnHeaderStartColumnName = hdMergeColumnHeaderStartColumnNameValue;
            var mergeColumnHeaderNumberOfColumns = hdMergeColumnHeaderNumberOfColumnsValue;
            var highLightColumnNameList = hdHighLightColumnNameListValue.split(",");
            var jqGridUrl = hdJqGridUrlValue;
            //Pass To Array Hidden Field Value

            //Merge Cell Need: columnNameList FROM SERVER ( mergeCellGroupColumnNameList )
            MergeGridCellGroupWise('timeSheetJQGrid', columnNameList = mergeCellGroupColumnNameList);

            //Set Total an Grand Total Need: columnNameList, footerTextColumnName FROM SERVER (footerColumnNameList, footerTextColumnName)
            SetFooterTotalAndFlexiColumnWise('timeSheetJQGrid', this, columnNameList = footerColumnNameList, footerTextColumnName = footerTextColumnName);

            //Merge GridColumns Header Need: startColumnName, numberOfColumns FROM SERVER ( mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns )
            MergeGridColumnsHeader('timeSheetJQGrid', mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns, "Days");

            //GridColumn HighLight Need: columnNameList FROM SERVER ( highLightColumnNameList )
            SetGridColumnHighLight('timeSheetJQGrid', columnNameList = highLightColumnNameList);

        },
        loadError: function (xhr, status, str) {   //function calling when grid load exception occured 
            alert(xhr.msg);           //set div text by error message
        },
        afterSaveCell: function (rowid, name, val, iRow, iCol) {

            if (rowid != 0) {

                //Get Hidden Field Value
                var hdOffDayColumnNameListValue = $("#hdOffDayColumnNameList").val();
                var hdFlexiValueValue = $("#hdFlexiValue").val();
                //Get Hidden Field Value

                //Pass To Array Hidden Field Value
                var offDayColumnNameList = hdOffDayColumnNameListValue.split(",");
                var flexiValue = hdFlexiValueValue;
                //Pass To Array Hidden Field Value


                //Calculate FooterData
                CalculateFooterTotalAndFlexiWithOffDay('timeSheetJQGrid', this, rowid, name, val, flexiValue, offDayColumnNameList = offDayColumnNameList);

                //Set Row Data
                $(this).jqGrid('setCell', rowid, 'IsEdited', 'True');
            }

            return false;
        },
        afterEditCell: function (rowid, name, val, iRow, iCol) {
            if (rowid != 0) { }
            return false;
        },
        errorCell: function () {                   //function calling when cell exception occured
            alert('An error has occurred while processing your request.');
        }

    });

    return false;
}

function CreateTimeSheetJqGridForSecondFortnightOf16Days(gridId, gridUrl) {

    $('#' + gridId).jqGrid({
        url: gridUrl,
        datatype: "json",
        mtype: 'POST',
        colNames: [
                    'Id',
                    'ProjectNo',
                    'Project No',
                    'IsProject',
                    'IsApprovalStatus',
                    'Approval Status',
                    'IsSubmittedTo',
                    'SubmittedTo',
                    'Submitted To',
                    'IsActivity',
                    'Activity',
                    'IsCompleted',
                    'Completed',
                    'Is Complete',
                    'IsEdited',

                    '16',
                    '17',
                    '18',
                    '19',
                    '20',
                    '21',
                    '22',
                    '23',
                    '24',
                    '25',
                    '26',
                    '27',
                    '28',
                    '29',
                    '30',
                    '31'
                    ],
        //colNames: gridColumnNameList,
        //colModel: gridColumnModelList,
        colModel: [
                                                { name: 'Id', index: 'Id', key: true, hidden: true },
                                                { name: 'ProjectNo', index: 'ProjectNo', hidden: true },
                                                { name: 'ProjectText', index: 'ProjectText', align: 'left', hidden: false },
                                                { name: 'IsProject', index: 'IsProject', hidden: true },
                                                { name: 'IsApprovalStatus', index: 'IsApprovalStatus', hidden: true },
                                                { name: 'ApprovalStatus', index: 'ApprovalStatus', align: 'center' },
                                                { name: 'IsSubmittedTo', index: 'IsSubmittedTo', hidden: true },
                                                { name: 'SubmittedTo', index: 'SubmittedTo', hidden: true },
                                                { name: 'SubmittedText', index: 'SubmittedText', align: 'center' },

                                                { name: 'IsActivity', index: 'IsActivity', hidden: true },
                                                { name: 'Activity', index: 'Activity', align: 'center' },
                                                { name: 'IsCompleted', index: 'IsCompleted', hidden: true },
                                                { name: 'Completed', index: 'Completed', hidden: true },
                                                { name: 'CompletedText', index: 'CompletedText', align: 'center' },
                                                { name: 'IsEdited', index: 'IsEdited', hidden: true, editable: true },

                                                { name: 'Day16', index: 'Day16', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day17', index: 'Day17', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day18', index: 'Day18', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day19', index: 'Day19', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day20', index: 'Day20', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day21', index: 'Day21', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day22', index: 'Day22', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day23', index: 'Day23', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day24', index: 'Day24', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day25', index: 'Day25', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day26', index: 'Day26', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day27', index: 'Day27', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day28', index: 'Day28', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day29', index: 'Day29', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day30', index: 'Day30', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day31', index: 'Day30', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} }
                                                ],
        cmTemplate: { sortable: false },
        cellEdit: true,
        cellsubmit: 'clientArray',
        height: 'auto',
        autowidth: true,
        grouping: false,
        sortname: 'id',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: false,
        multiselect: false,                        //checkbox list
        //shrinkToFit: true,
        footerrow: true,
        loadComplete: function (data) {

            //Get Hidden Field Value
            var hdMergeCellGroupColumnNameListValue = $("#hdMergeCellGroupColumnNameList").val();
            var hdFooterColumnNameListValue = $("#hdFooterColumnNameList").val();
            var hdFooterTextColumnNameValue = $("#hdFooterTextColumnName").val();
            var hdMergeColumnHeaderStartColumnNameValue = $("#hdMergeColumnHeaderStartColumnName").val();
            var hdMergeColumnHeaderNumberOfColumnsValue = $("#hdMergeColumnHeaderNumberOfColumns").val();
            var hdHighLightColumnNameListValue = $("#hdHighLightColumnNameList").val();
            var hdJqGridUrlValue = $("#hdJqGridUrl").val();
            //Get Hidden Field Value

            //Pass To Array Hidden Field Value
            var mergeCellGroupColumnNameList = hdMergeCellGroupColumnNameListValue.split(",");
            var footerColumnNameList = hdFooterColumnNameListValue.split(",");
            var footerTextColumnName = hdFooterTextColumnNameValue;
            var mergeColumnHeaderStartColumnName = hdMergeColumnHeaderStartColumnNameValue;
            var mergeColumnHeaderNumberOfColumns = hdMergeColumnHeaderNumberOfColumnsValue;
            var highLightColumnNameList = hdHighLightColumnNameListValue.split(",");
            var jqGridUrl = hdJqGridUrlValue;
            //Pass To Array Hidden Field Value

            //Merge Cell Need: columnNameList FROM SERVER ( mergeCellGroupColumnNameList )
            MergeGridCellGroupWise('timeSheetJQGrid', columnNameList = mergeCellGroupColumnNameList);

            //Set Total an Grand Total Need: columnNameList, footerTextColumnName FROM SERVER (footerColumnNameList, footerTextColumnName)
            SetFooterTotalAndFlexiColumnWise('timeSheetJQGrid', this, columnNameList = footerColumnNameList, footerTextColumnName = footerTextColumnName);

            //Merge GridColumns Header Need: startColumnName, numberOfColumns FROM SERVER ( mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns )
            MergeGridColumnsHeader('timeSheetJQGrid', mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns, "Days");

            //GridColumn HighLight Need: columnNameList FROM SERVER ( highLightColumnNameList )
            SetGridColumnHighLight('timeSheetJQGrid', columnNameList = highLightColumnNameList);

        },
        loadError: function (xhr, status, str) {   //function calling when grid load exception occured 
            alert(xhr.msg);           //set div text by error message
        },
        afterSaveCell: function (rowid, name, val, iRow, iCol) {

            if (rowid != 0) {

                //Get Hidden Field Value
                var hdOffDayColumnNameListValue = $("#hdOffDayColumnNameList").val();
                var hdFlexiValueValue = $("#hdFlexiValue").val();
                //Get Hidden Field Value

                //Pass To Array Hidden Field Value
                var offDayColumnNameList = hdOffDayColumnNameListValue.split(",");
                var flexiValue = hdFlexiValueValue;
                //Pass To Array Hidden Field Value


                //Calculate FooterData
                CalculateFooterTotalAndFlexiWithOffDay('timeSheetJQGrid', this, rowid, name, val, flexiValue, offDayColumnNameList = offDayColumnNameList);

                //Set Row Data
                $(this).jqGrid('setCell', rowid, 'IsEdited', 'True');
            }

            return false;
        },
        afterEditCell: function (rowid, name, val, iRow, iCol) {
            if (rowid != 0) { }
            return false;
        },
        errorCell: function () {                   //function calling when cell exception occured
            alert('An error has occurred while processing your request.');
        }

    });

    return false;
}

function CreateTimeSheetJqGridForSecondFortnightOf15Days(gridId, gridUrl) {

    $('#' + gridId).jqGrid({
        url: gridUrl,
        datatype: "json",
        mtype: 'POST',
        colNames: [
                    'Id',
                    'ProjectNo',
                    'Project No',
                    'IsProject',
                    'IsApprovalStatus',
                    'Approval Status',
                    'IsSubmittedTo',
                    'SubmittedTo',
                    'Submitted To',
                    'IsActivity',
                    'Activity',
                    'IsCompleted',
                    'Completed',
                    'Is Complete',
                    'IsEdited',

                    '16',
                    '17',
                    '18',
                    '19',
                    '20',
                    '21',
                    '22',
                    '23',
                    '24',
                    '25',
                    '26',
                    '27',
                    '28',
                    '29',
                    '30'
                    ],
        //colNames: gridColumnNameList,
        //colModel: gridColumnModelList,
        colModel: [
                                                { name: 'Id', index: 'Id', key: true, hidden: true },
                                                { name: 'ProjectNo', index: 'ProjectNo', hidden: true },
                                                { name: 'ProjectText', index: 'ProjectText', align: 'left', hidden: false },
                                                { name: 'IsProject', index: 'IsProject', hidden: true },
                                                { name: 'IsApprovalStatus', index: 'IsApprovalStatus', hidden: true },
                                                { name: 'ApprovalStatus', index: 'ApprovalStatus', align: 'center' },
                                                { name: 'IsSubmittedTo', index: 'IsSubmittedTo', hidden: true },
                                                { name: 'SubmittedTo', index: 'SubmittedTo', hidden: true },
                                                { name: 'SubmittedText', index: 'SubmittedText', align: 'center' },

                                                { name: 'IsActivity', index: 'IsActivity', hidden: true },
                                                { name: 'Activity', index: 'Activity', align: 'center' },
                                                { name: 'IsCompleted', index: 'IsCompleted', hidden: true },
                                                { name: 'Completed', index: 'Completed', hidden: true },
                                                { name: 'CompletedText', index: 'CompletedText', align: 'center' },
                                                { name: 'IsEdited', index: 'IsEdited', hidden: true, editable: true },

                                                { name: 'Day16', index: 'Day16', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day17', index: 'Day17', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day18', index: 'Day18', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day19', index: 'Day19', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day20', index: 'Day20', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day21', index: 'Day21', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day22', index: 'Day22', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day23', index: 'Day23', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day24', index: 'Day24', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day25', index: 'Day25', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day26', index: 'Day26', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day27', index: 'Day27', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day28', index: 'Day28', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day29', index: 'Day29', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day30', index: 'Day30', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} }
                                                ],
        cmTemplate: { sortable: false },
        cellEdit: true,
        cellsubmit: 'clientArray',
        height: 'auto',
        autowidth: true,
        grouping: false,
        sortname: 'id',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: false,
        multiselect: false,                        //checkbox list
        //shrinkToFit: true,
        footerrow: true,
        loadComplete: function (data) {

            //Get Hidden Field Value
            var hdMergeCellGroupColumnNameListValue = $("#hdMergeCellGroupColumnNameList").val();
            var hdFooterColumnNameListValue = $("#hdFooterColumnNameList").val();
            var hdFooterTextColumnNameValue = $("#hdFooterTextColumnName").val();
            var hdMergeColumnHeaderStartColumnNameValue = $("#hdMergeColumnHeaderStartColumnName").val();
            var hdMergeColumnHeaderNumberOfColumnsValue = $("#hdMergeColumnHeaderNumberOfColumns").val();
            var hdHighLightColumnNameListValue = $("#hdHighLightColumnNameList").val();
            var hdJqGridUrlValue = $("#hdJqGridUrl").val();
            //Get Hidden Field Value

            //Pass To Array Hidden Field Value
            var mergeCellGroupColumnNameList = hdMergeCellGroupColumnNameListValue.split(",");
            var footerColumnNameList = hdFooterColumnNameListValue.split(",");
            var footerTextColumnName = hdFooterTextColumnNameValue;
            var mergeColumnHeaderStartColumnName = hdMergeColumnHeaderStartColumnNameValue;
            var mergeColumnHeaderNumberOfColumns = hdMergeColumnHeaderNumberOfColumnsValue;
            var highLightColumnNameList = hdHighLightColumnNameListValue.split(",");
            var jqGridUrl = hdJqGridUrlValue;
            //Pass To Array Hidden Field Value

            //Merge Cell Need: columnNameList FROM SERVER ( mergeCellGroupColumnNameList )
            MergeGridCellGroupWise('timeSheetJQGrid', columnNameList = mergeCellGroupColumnNameList);

            //Set Total an Grand Total Need: columnNameList, footerTextColumnName FROM SERVER (footerColumnNameList, footerTextColumnName)
            SetFooterTotalAndFlexiColumnWise('timeSheetJQGrid', this, columnNameList = footerColumnNameList, footerTextColumnName = footerTextColumnName);

            //Merge GridColumns Header Need: startColumnName, numberOfColumns FROM SERVER ( mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns )
            MergeGridColumnsHeader('timeSheetJQGrid', mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns, "Days");

            //GridColumn HighLight Need: columnNameList FROM SERVER ( highLightColumnNameList )
            SetGridColumnHighLight('timeSheetJQGrid', columnNameList = highLightColumnNameList);

        },
        loadError: function (xhr, status, str) {   //function calling when grid load exception occured 
            alert(xhr.msg);           //set div text by error message
        },
        afterSaveCell: function (rowid, name, val, iRow, iCol) {

            if (rowid != 0) {

                //Get Hidden Field Value
                var hdOffDayColumnNameListValue = $("#hdOffDayColumnNameList").val();
                var hdFlexiValueValue = $("#hdFlexiValue").val();
                //Get Hidden Field Value

                //Pass To Array Hidden Field Value
                var offDayColumnNameList = hdOffDayColumnNameListValue.split(",");
                var flexiValue = hdFlexiValueValue;
                //Pass To Array Hidden Field Value


                //Calculate FooterData
                CalculateFooterTotalAndFlexiWithOffDay('timeSheetJQGrid', this, rowid, name, val, flexiValue, offDayColumnNameList = offDayColumnNameList);

                //Set Row Data
                $(this).jqGrid('setCell', rowid, 'IsEdited', 'True');
            }

            return false;
        },
        afterEditCell: function (rowid, name, val, iRow, iCol) {
            if (rowid != 0) { }
            return false;
        },
        errorCell: function () {                   //function calling when cell exception occured
            alert('An error has occurred while processing your request.');
        }

    });

    return false;
}

function CreateTimeSheetJqGridForSecondFortnightOf14Days(gridId, gridUrl) {

    $('#' + gridId).jqGrid({
        url: gridUrl,
        datatype: "json",
        mtype: 'POST',
        colNames: [
                    'Id',
                    'ProjectNo',
                    'Project No',
                    'IsProject',
                    'IsApprovalStatus',
                    'Approval Status',
                    'IsSubmittedTo',
                    'SubmittedTo',
                    'Submitted To',
                    'IsActivity',
                    'Activity',
                    'IsCompleted',
                    'Completed',
                    'Is Complete',
                    'IsEdited',

                    '16',
                    '17',
                    '18',
                    '19',
                    '20',
                    '21',
                    '22',
                    '23',
                    '24',
                    '25',
                    '26',
                    '27',
                    '28',
                    '29'
                    ],
        //colNames: gridColumnNameList,
        //colModel: gridColumnModelList,
        colModel: [
                                                { name: 'Id', index: 'Id', key: true, hidden: true },
                                                { name: 'ProjectNo', index: 'ProjectNo', hidden: true },
                                                { name: 'ProjectText', index: 'ProjectText', align: 'left', hidden: false },
                                                { name: 'IsProject', index: 'IsProject', hidden: true },
                                                { name: 'IsApprovalStatus', index: 'IsApprovalStatus', hidden: true },
                                                { name: 'ApprovalStatus', index: 'ApprovalStatus', align: 'center' },
                                                { name: 'IsSubmittedTo', index: 'IsSubmittedTo', hidden: true },
                                                { name: 'SubmittedTo', index: 'SubmittedTo', hidden: true },
                                                { name: 'SubmittedText', index: 'SubmittedText', align: 'center' },

                                                { name: 'IsActivity', index: 'IsActivity', hidden: true },
                                                { name: 'Activity', index: 'Activity', align: 'center' },
                                                { name: 'IsCompleted', index: 'IsCompleted', hidden: true },
                                                { name: 'Completed', index: 'Completed', hidden: true },
                                                { name: 'CompletedText', index: 'CompletedText', align: 'center' },
                                                { name: 'IsEdited', index: 'IsEdited', hidden: true, editable: true },

                                                { name: 'Day16', index: 'Day16', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day17', index: 'Day17', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day18', index: 'Day18', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day19', index: 'Day19', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day20', index: 'Day20', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day21', index: 'Day21', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day22', index: 'Day22', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day23', index: 'Day23', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day24', index: 'Day24', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day25', index: 'Day25', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day26', index: 'Day26', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day27', index: 'Day27', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day28', index: 'Day28', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day29', index: 'Day29', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} }
                                                ],
        cmTemplate: { sortable: false },
        cellEdit: true,
        cellsubmit: 'clientArray',
        height: 'auto',
        autowidth: true,
        grouping: false,
        sortname: 'id',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: false,
        multiselect: false,                        //checkbox list
        //shrinkToFit: true,
        footerrow: true,
        loadComplete: function (data) {

            //Get Hidden Field Value
            var hdMergeCellGroupColumnNameListValue = $("#hdMergeCellGroupColumnNameList").val();
            var hdFooterColumnNameListValue = $("#hdFooterColumnNameList").val();
            var hdFooterTextColumnNameValue = $("#hdFooterTextColumnName").val();
            var hdMergeColumnHeaderStartColumnNameValue = $("#hdMergeColumnHeaderStartColumnName").val();
            var hdMergeColumnHeaderNumberOfColumnsValue = $("#hdMergeColumnHeaderNumberOfColumns").val();
            var hdHighLightColumnNameListValue = $("#hdHighLightColumnNameList").val();
            var hdJqGridUrlValue = $("#hdJqGridUrl").val();
            //Get Hidden Field Value

            //Pass To Array Hidden Field Value
            var mergeCellGroupColumnNameList = hdMergeCellGroupColumnNameListValue.split(",");
            var footerColumnNameList = hdFooterColumnNameListValue.split(",");
            var footerTextColumnName = hdFooterTextColumnNameValue;
            var mergeColumnHeaderStartColumnName = hdMergeColumnHeaderStartColumnNameValue;
            var mergeColumnHeaderNumberOfColumns = hdMergeColumnHeaderNumberOfColumnsValue;
            var highLightColumnNameList = hdHighLightColumnNameListValue.split(",");
            var jqGridUrl = hdJqGridUrlValue;
            //Pass To Array Hidden Field Value

            //Merge Cell Need: columnNameList FROM SERVER ( mergeCellGroupColumnNameList )
            MergeGridCellGroupWise('timeSheetJQGrid', columnNameList = mergeCellGroupColumnNameList);

            //Set Total an Grand Total Need: columnNameList, footerTextColumnName FROM SERVER (footerColumnNameList, footerTextColumnName)
            SetFooterTotalAndFlexiColumnWise('timeSheetJQGrid', this, columnNameList = footerColumnNameList, footerTextColumnName = footerTextColumnName);

            //Merge GridColumns Header Need: startColumnName, numberOfColumns FROM SERVER ( mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns )
            MergeGridColumnsHeader('timeSheetJQGrid', mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns, "Days");

            //GridColumn HighLight Need: columnNameList FROM SERVER ( highLightColumnNameList )
            SetGridColumnHighLight('timeSheetJQGrid', columnNameList = highLightColumnNameList);

        },
        loadError: function (xhr, status, str) {   //function calling when grid load exception occured 
            alert(xhr.msg);           //set div text by error message
        },
        afterSaveCell: function (rowid, name, val, iRow, iCol) {

            if (rowid != 0) {

                //Get Hidden Field Value
                var hdOffDayColumnNameListValue = $("#hdOffDayColumnNameList").val();
                var hdFlexiValueValue = $("#hdFlexiValue").val();
                //Get Hidden Field Value

                //Pass To Array Hidden Field Value
                var offDayColumnNameList = hdOffDayColumnNameListValue.split(",");
                var flexiValue = hdFlexiValueValue;
                //Pass To Array Hidden Field Value


                //Calculate FooterData
                CalculateFooterTotalAndFlexiWithOffDay('timeSheetJQGrid', this, rowid, name, val, flexiValue, offDayColumnNameList = offDayColumnNameList);

                //Set Row Data
                $(this).jqGrid('setCell', rowid, 'IsEdited', 'True');
            }

            return false;
        },
        afterEditCell: function (rowid, name, val, iRow, iCol) {
            if (rowid != 0) { }
            return false;
        },
        errorCell: function () {                   //function calling when cell exception occured
            alert('An error has occurred while processing your request.');
        }

    });

    return false;
}

function CreateTimeSheetJqGridForSecondFortnightOf13Days(gridId, gridUrl) {

    $('#' + gridId).jqGrid({
        url: gridUrl,
        datatype: "json",
        mtype: 'POST',
        colNames: [
                    'Id',
                    'ProjectNo',
                    'Project No',
                    'IsProject',
                    'IsApprovalStatus',
                    'Approval Status',
                    'IsSubmittedTo',
                    'SubmittedTo',
                    'Submitted To',
                    'IsActivity',
                    'Activity',
                    'IsCompleted',
                    'Completed',
                    'Is Complete',
                    'IsEdited',

                    '16',
                    '17',
                    '18',
                    '19',
                    '20',
                    '21',
                    '22',
                    '23',
                    '24',
                    '25',
                    '26',
                    '27',
                    '28'
                    ],
        //colNames: gridColumnNameList,
        //colModel: gridColumnModelList,
        colModel: [
                                                { name: 'Id', index: 'Id', key: true, hidden: true },
                                                { name: 'ProjectNo', index: 'ProjectNo', hidden: true },
                                                { name: 'ProjectText', index: 'ProjectText', align: 'left', hidden: false },
                                                { name: 'IsProject', index: 'IsProject', hidden: true },
                                                { name: 'IsApprovalStatus', index: 'IsApprovalStatus', hidden: true },
                                                { name: 'ApprovalStatus', index: 'ApprovalStatus', align: 'center' },
                                                { name: 'IsSubmittedTo', index: 'IsSubmittedTo', hidden: true },
                                                { name: 'SubmittedTo', index: 'SubmittedTo', hidden: true },
                                                { name: 'SubmittedText', index: 'SubmittedText', align: 'center' },

                                                { name: 'IsActivity', index: 'IsActivity', hidden: true },
                                                { name: 'Activity', index: 'Activity', align: 'center' },
                                                { name: 'IsCompleted', index: 'IsCompleted', hidden: true },
                                                { name: 'Completed', index: 'Completed', hidden: true },
                                                { name: 'CompletedText', index: 'CompletedText', align: 'center' },
                                                { name: 'IsEdited', index: 'IsEdited', hidden: true, editable: true },

                                                { name: 'Day16', index: 'Day16', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day17', index: 'Day17', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day18', index: 'Day18', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day19', index: 'Day19', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day20', index: 'Day20', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day21', index: 'Day21', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day22', index: 'Day22', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day23', index: 'Day23', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day24', index: 'Day24', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day25', index: 'Day25', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day26', index: 'Day26', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day27', index: 'Day27', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} },
                                                { name: 'Day28', index: 'Day28', align: 'center', formatter: 'number', editable: true, editrules: { number: true, maxValue: 24 }, editoptions: { maxlength: 5} }

                                                ],
        cmTemplate: { sortable: false },
        cellEdit: true,
        cellsubmit: 'clientArray',
        height: 'auto',
        autowidth: true,
        grouping: false,
        sortname: 'id',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: false,
        multiselect: false,                        //checkbox list
        //shrinkToFit: true,
        footerrow: true,
        loadComplete: function (data) {

            //Get Hidden Field Value
            var hdMergeCellGroupColumnNameListValue = $("#hdMergeCellGroupColumnNameList").val();
            var hdFooterColumnNameListValue = $("#hdFooterColumnNameList").val();
            var hdFooterTextColumnNameValue = $("#hdFooterTextColumnName").val();
            var hdMergeColumnHeaderStartColumnNameValue = $("#hdMergeColumnHeaderStartColumnName").val();
            var hdMergeColumnHeaderNumberOfColumnsValue = $("#hdMergeColumnHeaderNumberOfColumns").val();
            var hdHighLightColumnNameListValue = $("#hdHighLightColumnNameList").val();
            var hdJqGridUrlValue = $("#hdJqGridUrl").val();
            //Get Hidden Field Value

            //Pass To Array Hidden Field Value
            var mergeCellGroupColumnNameList = hdMergeCellGroupColumnNameListValue.split(",");
            var footerColumnNameList = hdFooterColumnNameListValue.split(",");
            var footerTextColumnName = hdFooterTextColumnNameValue;
            var mergeColumnHeaderStartColumnName = hdMergeColumnHeaderStartColumnNameValue;
            var mergeColumnHeaderNumberOfColumns = hdMergeColumnHeaderNumberOfColumnsValue;
            var highLightColumnNameList = hdHighLightColumnNameListValue.split(",");
            var jqGridUrl = hdJqGridUrlValue;
            //Pass To Array Hidden Field Value

            //Merge Cell Need: columnNameList FROM SERVER ( mergeCellGroupColumnNameList )
            MergeGridCellGroupWise('timeSheetJQGrid', columnNameList = mergeCellGroupColumnNameList);

            //Set Total an Grand Total Need: columnNameList, footerTextColumnName FROM SERVER (footerColumnNameList, footerTextColumnName)
            SetFooterTotalAndFlexiColumnWise('timeSheetJQGrid', this, columnNameList = footerColumnNameList, footerTextColumnName = footerTextColumnName);

            //Merge GridColumns Header Need: startColumnName, numberOfColumns FROM SERVER ( mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns )
            MergeGridColumnsHeader('timeSheetJQGrid', mergeColumnHeaderStartColumnName, mergeColumnHeaderNumberOfColumns, "Days");

            //GridColumn HighLight Need: columnNameList FROM SERVER ( highLightColumnNameList )
            SetGridColumnHighLight('timeSheetJQGrid', columnNameList = highLightColumnNameList);

        },
        loadError: function (xhr, status, str) {   //function calling when grid load exception occured 
            alert(xhr.msg);           //set div text by error message
        },
        afterSaveCell: function (rowid, name, val, iRow, iCol) {

            if (rowid != 0) {

                //Get Hidden Field Value
                var hdOffDayColumnNameListValue = $("#hdOffDayColumnNameList").val();
                var hdFlexiValueValue = $("#hdFlexiValue").val();
                //Get Hidden Field Value

                //Pass To Array Hidden Field Value
                var offDayColumnNameList = hdOffDayColumnNameListValue.split(",");
                var flexiValue = hdFlexiValueValue;
                //Pass To Array Hidden Field Value


                //Calculate FooterData
                CalculateFooterTotalAndFlexiWithOffDay('timeSheetJQGrid', this, rowid, name, val, flexiValue, offDayColumnNameList = offDayColumnNameList);

                //Set Row Data
                $(this).jqGrid('setCell', rowid, 'IsEdited', 'True');
            }

            return false;
        },
        afterEditCell: function (rowid, name, val, iRow, iCol) {
            if (rowid != 0) { }
            return false;
        },
        errorCell: function () {                   //function calling when cell exception occured
            alert('An error has occurred while processing your request.');
        }

    });

    return false;
}


/*.............................End Create JqGrid Dynamic Coloumn.......................................*/