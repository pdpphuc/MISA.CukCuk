$(document).ready(function () {
	var employeeJS = new EmployeeJS();
})

class EmployeeJS {
	constructor() {
		this.mode = null;
		this.loadData();
		this.initEvents();
	}
	initEvents() {
		$('#btnAdd').click(this.btnAddOnClick.bind(this));
		$('#btnCancel').click(this.btnCancelOnClick.bind(this));
		$('#btnSave').click(this.btnSaveOnClick.bind(this));
		$('#btnEdit').click(this.btnEditOnClick.bind(this));
		$('#btnDelete').click(this.btnDeleteOnClick.bind(this));
		$('.title-close-button').click(this.btnCancelOnClick.bind(this));
		$('input[required]').blur(this.checkRequired);
		$("table tbody").on("click", "tr", this.rowOnSelect);
	}
	loadData() {
		// Lấy dữ liệu trên server thông qua lời gọi tới api service
		$.ajax({
			url: "/api/v1/employees",
			method: "GET",
			data: "", // Tham số sẽ truyền qua body request
			contentType: "application/json",
			dataType: ""
		}).done(function (response) {
			$('.grid tbody').empty();
			$.each(response, function (index, item) {
				var trHTML = $(`<tr employeeID = ` + item.EmployeeID + `>
				<td>`+ item.EmployeeCode + `</td>
				<td>`+ item.FullName + `</td>
				<td>`+ item.Email + `</td>
				<td>`+ item.Phone + `</td>
				<td>`+ item.Address + `</td>
			</tr>`);
				$('.grid tbody').append(trHTML);
			})
		}).fail(function (response) {

		})
	}
	checkRequired() {
		var value = this.value;
		if (!value) {
			$(this).addClass('required-error');
			$(this).attr('title', 'Bạn phải nhập thông tin này!');
		}
		else {
			$(this).removeClass('required-error');
			$(this).removeAttr('title');
		}
	}
	rowOnSelect() {
		$(this).siblings().removeClass("row-selected");
		$(this).addClass("row-selected");
	}
	showDialog() {
		$('.dialog input').val(null);
		$('.dialog-modal').show();
		$('.dialog').show();
		$('#txtEmployeeCode').focus();
	}
	hideDialog() {
		$('.dialog-modal').hide();
		$('.dialog').hide();
	}
	getID() {
		return $("#tbEmployeeList tr.row-selected").attr('employeeID');
	}
	getEmployeeCodeSeleted() {
		var empCode = null;
		var trSelected = $("#tbEmployeeList tr.row-selected");
		if (trSelected.length > 0) {
			empCode = $(trSelected).children()[0].textContent;
		}
		return empCode;
	}
	btnAddOnClick() {
		this.mode = "add";
		this.showDialog();
	}
	btnCancelOnClick() {
		this.hideDialog();
	}
	btnDeleteOnClick() {
		var self = this;
		// Kiểm tra đã chọn nhân viên?
		var employeeID = this.getID();
		if (!employeeID) {
			alert('Bạn chưa chọn nhân viên muốn xóa!');
			return;
		}
		if (!confirm("Bạn có chắc muốn xóa nhân viên đã chọn?")) {
			return;
		}
		$.ajax({
			url: "/api/v1/employees/" + employeeID,
			method: "DELETE"
		}).done(function (response) {
			if (response) {
				alert('Đã xóa nhân viên!');
			}
			else {
				alert('Nhân viên muốn xóa không tồn tại trong hệ thống!');
			}
			self.loadData();
		}).fail(function (response) {

		})
	}
	btnEditOnClick() {
		var self = this;
		this.mode = "edit";
		// Kiểm tra đã chọn nhân viên?
		var employeeID = this.getID();
		if (!employeeID) {
			alert('Bạn chưa chọn nhân viên muốn sửa!');
			return;
		}
		// Hiển thị form chi tiết
		this.showDialog();
		// Lấy dữ liệu của nhân viên tương ứng đã chọn

		$.ajax({
			url: "/api/v1/employees/" + employeeID,
			method: "GET"
		}).done(function (employee) {
			if (!employee) {
				alert('Nhân viên muốn sửa không tồn tại trong hệ thống!');
				self.loadData();
				self.hideDialog();
				self.mode = null;
				return;
			}
			// Binding các thông tin của nhân viên lên form
			$('#txtEmployeeCode').val(employee.EmployeeCode);
			$('#txtFullName').val(employee.FullName);
			$('#txtEmail').val(employee.Email);
			$('#txtPhone').val(employee.Phone);
			$('#txtAddress').val(employee.Address);
		}).fail(function (response) {

		})
	}
	btnSaveOnClick() {
		// Validate dữ liệu nhập trên form
		var requiredInputs = $('[required]');
		var isValid = true;
		$.each(requiredInputs, function (index, input) {
			var valid = $(input).trigger('blur');
			if (isValid && valid.hasClass('required-error')) {
				isValid = false;
			}
		})
		if (!isValid) {
			return;
		}
		var self = this;
		var method = "POST";
		if (this.mode == "edit") {
			method = "PUT";
		}
		// Thu thập dữ liệu nhập trên form
		var employee = {};
		employee.EmployeeID = this.getID();
		employee.EmployeeCode = $('#txtEmployeeCode').val();
		employee.FullName = $('#txtFullName').val();
		employee.Email = $('#txtEmail').val();
		employee.Phone = $('#txtPhone').val();
		employee.Address = $('#txtAddress').val();
		// Lưu dữ liệu
		$.ajax({
			url: "/api/v1/employees",
			method: method,
			data: JSON.stringify(employee), // Tham số sẽ truyền qua body request
			contentType: "application/json",
			dataType: "json"
		}).done(function (response) {
			self.loadData();
			self.hideDialog();
			self.mode = null;
		}).fail(function (response) {

		})
	}
}