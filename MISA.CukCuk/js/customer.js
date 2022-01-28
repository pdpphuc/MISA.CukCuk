$(document).ready(function () {
	var customerJS = new CustomerJS();
	customerJS.loadData();
})

class CustomerJS {
	constructor() {
		//this.loadData();
	}
	loadData() {
		$.each(employees, function (index, item) {
			var trHTML = $(`<tr>
				<td>`+ item.CustomerCode + `</td>
				<td>`+ item.CustomerName + `</td>
				<td>`+ item.Email + `</td>
				<td>`+ item.Phone + `</td>
				<td>`+ item.Address + `</td>
			</tr>`);
			$('.grid tbody').append(trHTML);
		})
	}
}

var employees = [
	{
		CustomerCode: "NV001",
		CustomerName: "Phạm Đức Phú Phúc",
		Email: "phuphuc@gmail.com",
		Phone: "0929382283",
		Address: "Lagi, Bình Thuận"
	},
	{
		CustomerCode: "NV002",
		CustomerName: "Nguyễn Thị Liên",
		Email: "phuphuc@gmail.com",
		Phone: "0929382283",
		Address: "Cầu Giấy, Hà Nội"
	},
	{
		CustomerCode: "NV003",
		CustomerName: "Hà Tuấn Anh",
		Email: "phuphuc@gmail.com",
		Phone: "0929382283",
		Address: "Quận 9, TP.HCM"
	}
]