$(document).ready(function () {
    $.ajax({
        url: "EmployeeData_TodayDate.json",
        type: 'GET',
        success: function (data) {
            data.forEach(function (item, index) {
                item.index = index + 1;
            });
            var eventTable = $('#maintable').DataTable({
                "dom": '<"toolbar">frtip',
                "searching": true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: 'Search here ...'
                },
                data: data,
                columns: [
                    { data: "index", className: 'text-center', orderable: false },
                    { data: "employeeName", className: 'text-center', orderable: true },
                    {
                        data: null, className: 'text-center', orderable: true,
                        render: function (data, type, row, meta) {
                            if (row.employeeDepartMent == "Development") { // here is your condition
                                return '<div class="black-color">' + row.employeeDepartMent + '</div>';
                            } else if (row.employeeDepartMent == "Sales") {
                                return '<div class="red-color">' + row.employeeDepartMent + '</div>';
                            } else if (row.employeeDepartMent == "Marketing") {
                                return '<div class="green-color">' + row.employeeDepartMent + '</div>';
                            } else if (row.employeeDepartMent == "QA") {
                                return '<div class="blue-color">' + row.employeeDepartMent + '</div>';
                            } else if (row.employeeDepartMent == "HR") {
                                return '<div class="orange-color">' + row.employeeDepartMent + '</div>';
                            } else if (row.employeeDepartMent == "SEO") {
                                return '<div class="pink-color">' + row.employeeDepartMent + '</div>';
                            }
                            else {
                                return row;
                            }
                        },
                    },
                    {
                        // data: null,
                        className: 'text-center',
                        "data": "weblink",
                        render: function (data, type, row) {
                            return (
                                '<a href="mailto:">' + row.employeeEmail + '</a>'
                            );
                        },
                    },
                    {
                        data: null,
                        className: 'text-center',
                        "data": "weblink",
                        render: function (data, type, row) {
                            return (
                                '<a href="tel:">' + row.employeePhoneNo + '</a>'
                            );
                        },
                        orderable: false
                    },
                    {
                        data: null, className: 'text-center', orderable: false, render: function (data, type, row) {
                            if (row.employeeGender == "Male") {
                                return 'M'
                            } else {
                                return 'F'
                            }
                        }
                    },
                    {
                        data: null,
                        className: 'text-center',
                        render: function (data, type, row) {
                            return (
                                '<button type="button" class="btn btn-sm viewdetails" view-id="' + row.employeeId + '" data-bs-toggle="modal" data-bs-target="#exampleModal"><i class="fa fa-eye"></i></button>'
                            );
                        },
                        orderable: false
                    },
                ]
            });

            $(document).on('click', '.viewdetails', function () {
                // var viewDetails = $(this).attr('view-id');
                var row = eventTable.row($(this).closest('tr')).data();
                $("#name").text(row.employeeName);
                $("#email").text(row.employeeEmail);
                $("#dateofBirth").text(row.employeeDOB);
                $("#gender").text(row.employeeGender);
                $("#designation").text(row.employeeDesignation);
                $("#State").text(row.employeeState);
                $("#city").text(row.employeeCity);
                $("#postcode").text(row.employeePostCode);
                $("#phoneno").text(row.employeePhoneNo);
                $("#department").text(row.employeeDepartMent);
                $("#monthlysalary").text("$" + row.employeeMonthlySalary);
                $("#doj").text(row.employeeDateOfJoining);
                $("#totalexp").text(row.employeeTotalExperience + ' years ');
                $("#remark").text(row.employeeRemark);
            });

        },
        error: function (response) {
            console.log(response);
        }
    });





});

