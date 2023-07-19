﻿using DigitalPortfolio.Models.Entities;
using DigitalPortfolio.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;
using System;

@model IEnumerable<DigitalPortfolio.Models.Entities.ContactMessage>

<div class= "row" style = "margin-left:100px;margin-top:100px;" >
    < div class= "col-md-4" >
        < div class= "row" ></ div >
        < div class= " col-md-9" >
            < input type = "text" class= "form-control" name = "Name" id = "Name" placeholder = "Your Name" >
            < input type = "text" class= "form-control" name = "Email" id = "Email" placeholder = "Your Email" >
            < input type = "text" class= "form-control" name = "Subject" id = "Subject" placeholder = "Your Subject" >
            < input type = "text" class= "form-control" name = "Message" id = "Message" placeholder = "Your Message" >

        </ div >
        < div class= " col-md-3" >
            < button type = "button" id = "submit" onclick = "SaveData()" > Save </ button >

        </ div >
    </ div >
    < div class= "col-md-7" >
        < table class= "table" >
            < thead >
                < tr >
                    < th >
                        Name
                    </ th >
                    < th >
                        Email
                    </ th >
                    < th >
                        Subject
                    </ th >
                    < th >
                        Message
                    </ th >
                    < th ></ th >
                </ tr >
            </ thead >
            < tbody class= "cat_body" >
                @*@foreach(var item in Model)
                {
                < tr >
                < td >
    @Html.DisplayFor(modelItem => item.Name)
                </ td >
                < td >
                < a asp - action = "Edit" asp - route - id = "@item.Id" > Edit </ a > |
                < a asp - action = "Details" asp - route - id = "@item.Id" > Details </ a > |
                < a asp - action = "Delete" asp - route - id = "@item.Id" > Delete </ a >
                </ td >
                </ tr >
                *@
            </ tbody >
        </ table >

    </ div >
</ div >

< script src = "https://code.jquery.com/jquery-3.2.1.min.js"
        integrity = "sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4="
        crossorigin = "anonymous" ></ script >

< script >

    $(document).ready(function() {
        $('#Id').val(0);
        $('#Name').val('');
        $('#Email').val('');
        $('#Subject').val('');
        $('#Message').val('');
        getContactList();
    });
    function SaveData()
    {
        // Call Web API to get a list of Contact
        if ($('#Name').val() == '' || $('#Name').val() == undefined || $('#Email').val() == undefined || $('#Subject').val() == undefined || $('#Message').val() == undefined) {
        alert("Please Insert Valid Input!!");
    } else
    {
            $.ajax({
        url: '../ContactMessages/AddorUpdate/',
                type: 'POST',
                dataType: 'json',
                data: { Id: $('#Id').val(), Name: $('#Name').val(), Email: $('#Email').val(), Subject: $('#Subject').val(), Message: $('#Name').val() },
                success: function(data) {
                debugger
                    if (data.Status == "success")
                {
                    alert("Data Inserted Successfully!");
                    getContactList();
                        $('#Name').val('');
                         $('#Email').val('');
                          $('#Subject').val('');
                        $('#Message').val('');
                        $('#Id').val(0);

                }
                else
                {
                    alert(data.msg);
                }
            },
                error: function(request, message, error) {
                debugger
                    handleException(request, message, error);
            }
        });
    }

}


// Get all Contact to display
function getContactList()
{
        // Call Web API to get a list of Contact
        $.ajax({
    url: '../ContactMessages/GetAllContact/',
            type: 'GET',
            dataType: 'json',
            success: function(employees) {
            debugger
                $('.cat_row').remove();
            var cat_rows = "";
            for (var i = 0; i < employees.length; i++)
            {

                cat_rows = cat_rows + '<tr class="cat_row" ondblclick="updatedata(' + employees[i].Id + ',\'' + employees[i].Name + '\')"><td>' + employees[i].Name + '</td><td>' + employees[i].Email + '</td><td>' + employees[i].Subject + '</td><td>' + employees[i].Message + '</td><td><button type="button" onclick="DeleteContact(' + employees[i].Id + ')" >Delete</button></td></tr>';

            }

                $('.cat_body').append(cat_rows);

        },
            error: function(request, message, error) {
            debugger
                alert(message);
        }
    });
    }

    function updatedata(id, name)
{
        $('#Id').val(id);
        $('#Name').val(name);
}

function DeleteContact(id)
{
    // Call Web API to get a list of Contact
    if (isNaN(id) || id == 0)
    {
        alert("Please Select Valid Data!!");
    }
    else
    {
            $.ajax({
        url: '../ContactMessages/DeleteContact/',
                type: 'POST',
                dataType: 'json',
                data: { Id: id },
                success: function(data) {
                debugger
                    if (data.Status == "success")
                {
                    alert("Data Deleted Successfully!");
                    getContactList();


                }
                else
                {
                    alert(data.msg);
                }
            },
                error: function(request, message, error) {
                debugger
                    handleException(request, message, error);
            }
        });
        }

    }

</ script >