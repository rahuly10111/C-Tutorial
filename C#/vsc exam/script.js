$(document).ready(function () {
    $.ajax({
        url: "EmployeeData_TodayDate.json",
        type: 'GET',
        success: function (data) {
            data.forEach(function (item, index) {
                item.index = index + 1;
            });
            var eventTable = $('#eventTable').DataTable({
                "dom": '<"toolbar">frtip',
                "searching": true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: 'Search...'
                },
                data: data,
                columns: [
                    { data: "index", className: 'text-center', orderable: false },
                    { data: "employeeName", className: 'text-center', orderable: true },
                    {
                        data: null,className: 'text-center', orderable: true,
                        render: function (data, type, row, meta) {
                            if (row.employeeDepartMent == "Development") { // here is your condition
                                return '<div class="black-color">' + row.employeeDepartMent + '</div>';
                            }else if (row.employeeDepartMent == "Sales") {
                                return '<div class="red-color">' + row.employeeDepartMent + '</div>';
                            }else if (row.employeeDepartMent == "Marketing") {
                                return '<div class="green-color">' + row.employeeDepartMent + '</div>';
                            }else if (row.employeeDepartMent == "QA") {
                                return '<div class="blue-color">' + row.employeeDepartMent + '</div>';
                            }else if (row.employeeDepartMent == "HR") {
                                return '<div class="orange-color">' + row.employeeDepartMent + '</div>';
                            }else if (row.employeeDepartMent == "SEO") {
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
                                '<a href="' + data + '">' + row.employeeEmail + '</a>'
                            );
                        },
                    },
                    {
                        // data: null,
                        className: 'text-center',
                        "data": "weblink",
                        render: function (data, type, row) {
                            return (
                                '<a href="' + data + '">' + row.employeePhoneNo + '</a>'
                            );
                        },
                        orderable: false
                    },
                    { data: "employeeGender", className: 'text-center', orderable: false },
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
                var viewDetails = $(this).attr('view-id');
                var row = eventTable.row($(this).closest('tr')).data();
                $("#name").val(row.employeeName);
                $("#email").val(row.employeeEmail);
                $("#dateofBirth").val(row.employeeDOB);
                $("#gender").val(row.employeeGender);
                $("#designation").val(row.employeeDesignation);
                $("#State").val(row.employeeState);
                $("#city").val(row.employeeCity);
                $("#postcode").val(row.employeePostCode);
                $("#phoneno").val(row.employeePhoneNo);
                $("#department").val(row.employeeDepartMent);
                $("#monthlysalary").val(row.employeeMonthlySalary);
                $("#doj").val(row.employeeDateOfJoining);
                $("#totalexp").val(row.employeeTotalExperience);
                $("#remark").val(row.employeeRemark);

                console.log(row.employeeName);
                // $('#exampleModal').modal('show');
                // console.log(row.employeeEmail);
            });

            var color = 'blue';
            if ($("#department").val() == "Development") {
                console.log(data.employeeDepartMent);
                $("input").css("background", color);
            }


        },
        error: function () {
            alert('Error retrieving data!');
        }
    });





});

